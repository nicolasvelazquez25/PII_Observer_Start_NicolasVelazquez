using System;

namespace Observer
{
    public class TemperatureReporter : IObserver
    {
        private bool first;
        private Temperature last;
        private IObservable provider;

        public void StartReporting(IObservable provider)
        {
            this.provider = provider;
            this.first = true;
            this.provider.Subscribe(this);
        }

        public void StopReporting()
        {
            this.provider.Unsubscribe(this);
        }

        public void Update(Temperature temp)
        {
            Console.WriteLine($"The temperature is {temp.Degrees}°C at {temp.Date:g}");
            if (first)
            {
                last = temp;
                first = false;
            }
            else
            {
                Console.WriteLine($"   Change: {temp.Degrees - last.Degrees}° in " +
                    $"{temp.Date.ToUniversalTime() - last.Date.ToUniversalTime():g}");
            }
        }
    }
}