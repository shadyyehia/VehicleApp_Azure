using Vehicle_WebAPI.Controllers;
using Vehicle_WebAPI.Helpers;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest_VehiclesWebAPI
{
    public class VehicleControllerTest
    {
        private readonly Mock<IDataManager> _mockDataManager;
        private readonly Mock<ITimerManager> _mockTimeManager;
        private readonly Mock<IHubContext<VehicleHub,IVehicleHub>> _mockVehicleHub;
        private readonly VehicleController _controller;
        int savedPeriod;
        public VehicleControllerTest() {
            _mockDataManager = new Mock<IDataManager>();
            _mockTimeManager = new Mock<ITimerManager>();
          
            _mockTimeManager.Setup(w => w.Configure(It.IsAny<Action>(), It.IsAny<int>(), It.IsAny<int>()))
                .Callback<Action, int, int>((i, obj, period) => savedPeriod = period);
            _mockVehicleHub = new Mock<IHubContext<VehicleHub, IVehicleHub>>();
            _controller = new VehicleController(_mockVehicleHub.Object, _mockDataManager.Object,_mockTimeManager.Object);
        }
        [Fact]
        public void Monitor_returnsIActionResult()
        {
           var result = _controller.Monitor();
           Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void Monitor_CheckSignalRPeriod60Seconds()
        {
            var result = _controller.Monitor();
            _mockTimeManager.Verify(m => m.Configure(It.IsAny<Action>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once());
            // Assert about saveObject
            Assert.Equal(50000, savedPeriod);

        }
       


    }
}
