using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleService.Models;
using System.Runtime.Caching;

namespace VehicleService.Services
{
    public class VehicleRepository : IVehicleRepository
    {
        private const string CacheKey = "VehicleStore";
        ObjectCache cache = MemoryCache.Default;

        /// <summary>
        /// Creates a default vehicles cache 
        /// </summary>
        public VehicleRepository()
        {
            if (cache[CacheKey] == null)
                cache[CacheKey] = GetDefaultVehicles();

        }

        /// <summary>
        /// Gets all vehicles from cache
        /// </summary>
        /// <returns>List of Vehicles</returns>
        public List<Vehicle> GetAllVehicles()
        {
            return (List<Vehicle>)cache[CacheKey];            
        }


        /// <summary>
        /// Gets a vehicle for corresponding vehicleid
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public Vehicle GetVehicleById(int vehicleId)
        {

            return ((List<Vehicle>)cache[CacheKey]).FirstOrDefault(x => x.Id == vehicleId);

        }

        /// <summary>
        /// Deletes a vehicle from cache
        /// </summary>
        /// <param name="vehicleId"></param>
        public void DeleteVehicleById(int vehicleId)
        {
            List<Vehicle> currentVehicles = GetAllVehicles();
            currentVehicles.RemoveAll(x => x.Id == vehicleId);
            cache[CacheKey] = currentVehicles;

        }

        /// <summary>
        /// Updates/Adds vehicle to cache
        /// </summary>
        /// <param name="vehicle"></param>
        public void SaveVehicle(Vehicle vehicle)
        {
            var currentData = ((List<Vehicle>)cache[CacheKey]);
            if (vehicle.Id == 0)
            {
                vehicle.Id = currentData.Max(x => x.Id) + 1;
                currentData.Add(vehicle);
            }
            else
            {
                var index = currentData.FindIndex(x => x.Id == vehicle.Id);
                currentData[index] = vehicle;
            }

            cache[CacheKey] = currentData;
        }

        /// <summary>
        /// Gets filtered vehicles based on input criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns>List of Vehicles</returns>
        public List<Vehicle> GetFilteredVehicles(FilterCriteria criteria)
        {
            var query = GetAllVehicles().AsQueryable();

            if (criteria.Make != null)
                query = query.Where(d => d.Make == criteria.Make);

            if (criteria.Model != null)
                query = query.Where(d => d.Model == criteria.Model);

            if (criteria.Year > 0)
                query = query.Where(d => d.Year == criteria.Year);
            return query.ToList();
        }

        /// <summary>
        /// Get default vehicle list
        /// </summary>
        /// <returns>List of Vehicles</returns>
        private List<Vehicle> GetDefaultVehicles()
        {
            return new List<Vehicle>
                    {
                        new Vehicle { Id = 1, Model = "Accord", Year = 1957, Make="Honda" },
                        new Vehicle { Id = 2, Model = "Camry", Year = 1999, Make = "Toyota" }

                 };
        }
    }
}