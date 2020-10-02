using System;
using System.Collections.Generic;
using BusinessLogic.DataContracts;
using BusinessLogic.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Test_IBA_Kurets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordsServiceController : ControllerBase
    {
        private readonly IRecordsService _recordsService;
        private bool CheckTime()
        {
            return DateTime.Now.Hour > 9 && DateTime.Now.Hour < 18;
        }
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
        [Route("create")]
        public ActionResult Create(Record item)
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
        [Route("overspeed")]
        public ActionResult OverSpeed(DateTime date, double speed)
        {
            if (!CheckTime()) return new StatusCodeResult(StatusCodes.Status503ServiceUnavailable);
            return Ok(_recordsService.OverSpeed(date, speed));
        }

        /// <summary>
        /// Gets the maximum and minimum speed for a sampling date.
        /// </summary>
        /// <param name="date">Sampling date.</param>
        /// <returns>List of two speeds(min and max) for a sampling date.</returns>
        [HttpGet]
        [Route("minmaxspeed")]
        public ActionResult MinMaxSpeed(DateTime date)
        {
            if (!CheckTime()) return new StatusCodeResult(StatusCodes.Status503ServiceUnavailable);
            return Ok(_recordsService.MinMaxSpeed(date));
        }
    }
}
