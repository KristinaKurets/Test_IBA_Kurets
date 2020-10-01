using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Data.Model;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BuisinessLogic.Services.Test
{
    public class Tests
    {
        private RecordsService _service; 

        public void SetUp()
        {
            var mock = new Mock<IRecordsService<Record>>();
            mock.Setup(x=>x.ReadAll()).Returns(new List<Record>() { new Record()}.AsQueryable);
            _service = (RecordsService)mock.Object;
        }

        [Test, TestCase(typeof(TestCases), nameof(TestCases.ReadAllTestCase))]
        public int ReadAllTest()
        {
            SetUp();
            var result = _service.ReadAll().Count();
            return result;
        }
    }

    public class TestCases
    {

        protected static readonly IList<Record> records = new List<Record>
        {
           new Record
           {
               ID = 1,
               Speed = 70
           },
           new Record
           {
               ID = 2,
               Speed = 45
           }
        };

        public IEnumerable<TestCaseData> ReadAllTestCase
        {
            get
            {
                yield return new TestCaseData(records).Returns(records.Count);
                yield return new TestCaseData(null).Returns(0);
            }
        }
    }
}