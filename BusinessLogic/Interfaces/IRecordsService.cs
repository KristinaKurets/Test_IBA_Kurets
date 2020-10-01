using BusinessLogic.DataContracts;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRecordsService
    { 
        Task Create(Record item);
        IQueryable<Record> ReadAll();
        IQueryable<Record> ReadAll(Func<Record, bool> predicate);
        IEnumerable<RecordDto> OverSpeed(DateTime date, double speed);
        IEnumerable<RecordDto> MinMaxSpeed(DateTime date);
    }
}
