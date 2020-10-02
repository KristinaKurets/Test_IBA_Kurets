using System;
using System.Collections.Generic;
using BusinessLogic.DataContracts;
using BusinessLogic.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Test_IBA_Kurets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordsServiceController : ControllerBase
    {
        private readonly IRecordsService _recordsService;

        public RecordsServiceController(IRecordsService recordsService)
        {
            _recordsService = recordsService;

        }
        /// <summary>
        ///Adding a new record to the database.
        /// </summary>
        /// <param name="item">Added record.</param>
        /// <returns>On success returns 204 status code.</returns>
        [HttpPost]
        [Route("/service/create")]
        public ActionResult Create(RecordDto item)
        {
            _recordsService.Create(item);
            return NoContent();
            
        }
        /// <summary>
        ///Gets a list of cars that have exceeded the speed limit on the selected date.
        /// </summary>
        /// <param name="date">Sampling date.</param>
        /// <param name="speed">Speed trashold</param>
        /// <returns>A list of cars that have exceeded the speed limit on the selected date.</returns>
        [HttpGet]
        [Route("/service/overspeed/{date}/{speed}")]
        public IEnumerable<RecordDto> OverSpeed(DateTime date, double speed)
        {
            return (IEnumerable<RecordDto>)_recordsService.OverSpeed(date, speed);
        }

        /// <summary>
        /// Gets the maximum and minimum speed for a sampling date.
        /// </summary>
        /// <param name="date">Sampling date.</param>
        /// <returns>List of two speeds(min and max) for a sampling date.</returns>
        [HttpGet]
        [Route("/service/minmaxspeed/{date}")]
        public IEnumerable<RecordDto> MinMaxSpeed(DateTime date)
        {
            return (IEnumerable<RecordDto>)_recordsService.MinMaxSpeed(date);
        }
    }
}
