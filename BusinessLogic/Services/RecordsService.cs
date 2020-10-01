using AutoMapper;
using BusinessLogic.DataContracts;
using BusinessLogic.Interfaces;
using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class RecordsService  : IRecordsService<Record>
    {
        private readonly RecordContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<RecordDto> set;

        public RecordsService(RecordContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            set = _context.Set<RecordDto>();

        }
        public async Task Create(Record item)
        {
            await _context.AddAsync(_mapper.Map<Record>(item));
            await _context.SaveChangesAsync();
        }

        public void CreateAll(IEnumerable<Record> items)
        {
            using (var context = new RecordContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Records] ON");
                    _context.Records.AddRange(_mapper.Map<Record>(items));
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Records] OFF");
                    transaction.Commit();
                }
            }
        }

        public IQueryable<Record> ReadAll()
        {
            return _mapper.Map<IQueryable<Record>>(set.AsQueryable());
        }
        public IQueryable<Record> ReadAll(Func<Record, bool> predicate)
        {
            return _mapper.Map<IQueryable<Record>>(set.AsParallel().Where((Func<RecordDto, bool>)predicate).AsQueryable());
        }

        public IEnumerable<Record> OverSpeed(DateTime date, double speed)
        {
            var result = ReadAll(x => x.Date == date && x.Speed > speed).ToList();
                return _mapper.Map<IEnumerable<Record>>(result); 
        }

        public IEnumerable<Record> MinMaxSpeed(DateTime date)
        {
            var list = ReadAll().Where(x => x.Date == date).AsQueryable();
            var resultMax = list.Aggregate((curMax, x) => curMax == null || x.Speed > curMax.Speed ? x : curMax);
            var resultMin = list.Aggregate((curMin, x) => curMin == null || x.Speed < curMin.Speed ? x : curMin);
            var result = new List<Record> { resultMin, resultMax };
            return _mapper.Map<IEnumerable<Record>>(result);
        }

    }
}
