using Vehicle_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle_WebAPI.Helpers
{
    public interface IVehicleHub
    {
        
        Task VehicleStatusChange(List<Vehicle> vehicles);
    }
}
