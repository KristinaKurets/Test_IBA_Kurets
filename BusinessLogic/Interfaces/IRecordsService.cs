using BusinessLogic.DataContracts;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRecordsService<TSource>
    { 
        Task Create(TSource item);
        void CreateAll(IEnumerable<TSource> range);
        IQueryable<TSource> ReadAll();
        IQueryable<TSource> ReadAll(Func<TSource, bool> predicate);
        IEnumerable<TSource> OverSpeed(DateTime date, double speed);
        IEnumerable<TSource> MinMaxSpeed(DateTime date);
    }
}
