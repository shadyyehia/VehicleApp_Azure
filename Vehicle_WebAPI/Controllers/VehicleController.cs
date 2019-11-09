using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_WebAPI.Helpers;
using Vehicle_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Vehicle_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IHubContext<VehicleHub, IVehicleHub> hubContext;
        ITimerManager currentTimeManager;
        IDataManager datamanager;
        
        public VehicleController(IHubContext<VehicleHub, IVehicleHub> vehicleHub, IDataManager datamanager,ITimerManager timermanager )
        {
            this.datamanager = datamanager;
            this.hubContext = vehicleHub;
            currentTimeManager = timermanager;
        }
        // Post: api/Vehicles
        [HttpGet]
        [ActionName("monitor")]
        public IActionResult Monitor()
        {
            try
            {
                currentTimeManager.Configure(() =>
                hubContext.Clients.All.VehicleStatusChange(this.datamanager.GetData_SignalR()), 3000, 60000);
                return Ok(new { Message = "Request Completed" });
            } catch (Exception ex)
            {
             
                //Logging 
                throw;
            }
        }


        [HttpGet]
        [ActionName("monitor_noSignalR")]
        public List<Vehicle> GetData_Polling()
        {
            return this.datamanager.GetData_NoSignalR();

        }

        // GET: api/Vehicles
        [HttpGet]
        [ActionName("getCustomers")]
        public IEnumerable<Customer> getCustomers()
        {
            try
            {
                return datamanager.GetCustomers();
            }
            catch {
                //logging
                throw;
                
            }
        }


        /// <summary>
        /// Ping vehicle to check it's connection state
        /// </summary>
        /// <param name="vid"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ActionName("ping")]
        public bool IsConnected(int id)
        {
            try
            {
                return this.datamanager.isConnected(id);
            }
            catch {
                //Logging 
                throw;
            }
            
        }
        //[HttpGet]
        //[ActionName("updateV")]
        //public void updateV()
        //{
        //    callClient().Wait();
        //}
        //public async Task callClient() {
        //    await this.hubContext.Clients.All.VehicleStatusChange(1, true);
        //}

    }
}