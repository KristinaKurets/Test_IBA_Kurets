using BusinessLogic.DataContracts;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRecordsService
    {
        Record Create(Record item);
        IEnumerable<RecordDto> OverSpeed(DateTime date, double speed);
        IEnumerable<RecordDto> MinMaxSpeed(DateTime date);
    }
}
