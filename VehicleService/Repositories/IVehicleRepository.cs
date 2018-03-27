using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleService.Models;

namespace VehicleService.Services
{
    interface IVehicleRepository
    {
        List<Vehicle> GetAllVehicles();
        void SaveVehicle(Vehicle vehicle);
        Vehicle GetVehicleById(int vehicleId);
        List<Vehicle> GetFilteredVehicles(FilterCriteria criteria);
        void DeleteVehicleById(int vehicleId);
    }
}
