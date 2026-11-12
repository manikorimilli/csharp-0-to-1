namespace Ep07.Solutions;

public static class S06_Sensor
{
    class ThresholdEventArgs(double value, double threshold) : EventArgs
    {
        public double Value { get; } = value;
        public double Threshold { get; } = threshold;
    }

    class TemperatureSensor
    {
        public double Threshold { get; set; } = 30;
        public event EventHandler<ThresholdEventArgs>? ThresholdExceeded;

        public void Record(double value)
        {
            Console.WriteLine($"recorded {value}");
            if (value > Threshold)
                ThresholdExceeded?.Invoke(this, new ThresholdEventArgs(value, Threshold));
        }
    }

    public static void Run()
    {
        var sensor = new TemperatureSensor { Threshold = 25 };

        EventHandler<ThresholdEventArgs> logger = (_, e) => Console.WriteLine($"  [log] {e.Value} > {e.Threshold}");
        EventHandler<ThresholdEventArgs> alarm = (_, e) => Console.WriteLine("  [ALARM] too hot!");

        sensor.ThresholdExceeded += logger;
        sensor.ThresholdExceeded += alarm;

        sensor.Record(20);
        sensor.Record(27);

        sensor.ThresholdExceeded -= alarm;   // same instance, so it is removed
        sensor.Record(31);
    }
}
