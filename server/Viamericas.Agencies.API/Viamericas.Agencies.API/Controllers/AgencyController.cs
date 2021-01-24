using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using Viamericas.Agencies.Business.Interfaces;
using Viamericas.Agencies.Entity;

namespace Viamericas.Agencies.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        #region Properties
        private readonly IAgencyBusiness _business;
        #endregion
        #region Constructor
        public AgencyController(IAgencyBusiness business)
        {
            _business = business;
        }
        #endregion
        #region Methods
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        public ActionResult<List<string>> GetCities()
        {
            try
            {
                return Ok(_business.GetAllCities());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        public ActionResult<List<Agency>> GetAgencies(string city)
        {
            try
            {
                return Ok(_business.GetAllAgenciesByCity(city));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());
            }
        }
        #endregion
    }
}