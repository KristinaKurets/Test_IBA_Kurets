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
    public class RecordsService  : IRecordsService
    {
        private readonly RecordContext _context;
        private readonly IMapper _mapper;
        

        public RecordsService(RecordContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            

        }
        public async Task Create(Record item)
        {
            await _context.AddAsync(_mapper.Map<Record>(item));
            await _context.SaveChangesAsync();
        }

        public IQueryable<Record> ReadAll()
        {
            return _context.Records.AsQueryable();
        }
        public IQueryable<Record> ReadAll(Func<Record, bool> predicate)
        {
            return _context.Records.AsParallel().Where(predicate).AsQueryable();
        }

        public IEnumerable<RecordDto> OverSpeed(DateTime date, double speed)
        {
            var result = ReadAll(x => x.Date == date && x.Speed > speed).ToList();
                return _mapper.Map<IEnumerable<RecordDto>>(result); 
        }

        public IEnumerable<RecordDto> MinMaxSpeed(DateTime date)
        {
            var list = ReadAll().Where(x => x.Date == date).AsQueryable();
            var resultMax = list.Aggregate((curMax, x) => curMax == null || x.Speed > curMax.Speed ? x : curMax);
            var resultMin = list.Aggregate((curMin, x) => curMin == null || x.Speed < curMin.Speed ? x : curMin);
            var result = new List<Record> { resultMin, resultMax };
            return _mapper.Map<IEnumerable<RecordDto>>(result);
        }

    }
}
