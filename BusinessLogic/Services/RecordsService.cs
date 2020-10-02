using AutoMapper;
using BusinessLogic.DataContracts;
using BusinessLogic.Interfaces;
using Data.Context;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Host;
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
        private bool CheckTime()
        {
            return DateTime.Now.Hour > 9 && DateTime.Now.Hour < 18;
        }
        public async Task Create(RecordDto item)
        {
            await _context.AddAsync(_mapper.Map<Record>(item));
            await _context.SaveChangesAsync();
        }


        public ActionResult OverSpeed(DateTime date, double speed)
        {
            if (!CheckTime())
                return new StatusCodeResult(StatusCodes.Status503ServiceUnavailable);
            var result = _context.Records.Where(x => x.Date.Date == date && x.Speed > speed).ToList();
                return (ActionResult)_mapper.Map<IEnumerable<RecordDto>>(result); 
        }

        public ActionResult MinMaxSpeed(DateTime date)
        {
            if (!CheckTime())
                return new StatusCodeResult(StatusCodes.Status503ServiceUnavailable);
            var list = _context.Records.Where(x => x.Date.Date == date).AsQueryable();
            var resultMax = list.Aggregate((curMax, x) => curMax == null || x.Speed > curMax.Speed ? x : curMax);
            var resultMin = list.Aggregate((curMin, x) => curMin == null || x.Speed < curMin.Speed ? x : curMin);
            var result = new List<Record> { resultMin, resultMax };
            return (ActionResult)_mapper.Map<IEnumerable<RecordDto>>(result);
            
        }

    }
}
