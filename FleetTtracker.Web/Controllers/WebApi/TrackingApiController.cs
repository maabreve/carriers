using FleetTracker.Data.Contract;
using FleetTracker.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FleetTracker.Web.Controllers.WebApi
{
    public class TrackingApiController : BaseApiController
    {
        public TrackingApiController(IUow uow)
        {
            Uow = uow;
        }

        // GET: api/tracking
        [HttpGet]
        [Route("api/tracking")]
        public async Task<List<TrackingCurrentPosition>> Get()
        {
            return await Task.Run(() => Uow.TrackingCurrentPositions.GetAll().ToList());
        }

    }
}