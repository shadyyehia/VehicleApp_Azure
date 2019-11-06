using System;

namespace Vehicle_WebAPI.Helpers
{
    public interface ITimerManager
    {
        DateTime TimerStarted { get; }

        void Configure(Action action, int firstdelayByMilliSeconds, int period);
        void Dispose();
        void Execute(object stateInfo);
    }
}