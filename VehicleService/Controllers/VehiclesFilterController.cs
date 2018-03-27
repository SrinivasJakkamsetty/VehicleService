using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using VehicleService.Models;
using VehicleService.Services;
using System.Web.Http.Cors;

namespace VehicleService.Controllers
{
    [EnableCors(origins: "https://estimate-dev.mymitchell.com", headers: "*", methods: "*")]
    public class VehiclesFilterController : ApiController
    {
        private IVehicleRepository _vehicleRepository;

        public VehiclesFilterController()
        {
            this._vehicleRepository = new VehicleRepository();
        }
        [HttpGet]
        [Route("api/v2/vehicles")]
        public IEnumerable<Vehicle> Get([FromBody]FilterCriteria filterCriteria)
        {
            if (filterCriteria != null)
            {
                return _vehicleRepository.GetFilteredVehicles(filterCriteria);
            }
            else
            {
                return _vehicleRepository.GetAllVehicles();
            }

        }    

        // GET: api/Vehicles/5
        [HttpGet]
        [Route("api/v2/vehicles/{vehicleId}")]
        public IHttpActionResult Get(int vehicleId)
        {
            var vehicle = _vehicleRepository.GetVehicleById(vehicleId);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        // POST: api/Vehicles
        [HttpPost]
        [Route("api/v2/vehicles")]
        public void Post([FromBody]Vehicle value)
        {
            _vehicleRepository.SaveVehicle(value);
        }

        // PUT: api/Vehicles/5
        [HttpPut]
        [Route("api/v2/vehicles")]
        public void Put([FromBody]Vehicle value)
        {
            if (value != null)
                _vehicleRepository.SaveVehicle(value);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete]
        [Route("api/v2/vehicles/{vehicleId}")]
        public void Delete(int vehicleId)
        {
            _vehicleRepository.DeleteVehicleById(vehicleId);
        }
    }
}
