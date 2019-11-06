using System.Collections.Generic;
using Vehicle_WebAPI.Models;

namespace Vehicle_WebAPI.Helpers
{
    public interface IDataManager
    {
        List<Customer> GetCustomers();
        List<Vehicle> GetData_SignalR();
        List<Vehicle> GetData_NoSignalR();
        List<Vehicle> FilterData(dynamic filter);
        bool isConnected(int vid);
    }
}