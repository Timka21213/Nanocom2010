using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Nanocom
{
    public abstract class CounterValueProvider
    {
        public abstract double Value();
    }
    public class CounterValueSimulator : CounterValueProvider
    {
        public CounterValueSimulator(double min_, double max_, double interval_)
        {
            _min = min_;
            _max = max_;
            _interval = Convert.ToUInt32(interval_ * 1000);
            _watch = new System.Diagnostics.Stopwatch();
            _watch.Start();
        }
        public override double Value()
        {
            long elapsed = _watch.ElapsedMilliseconds;
            double x = Convert.ToDouble(elapsed % _interval)/Convert.ToDouble(_interval) * 2.0 * Math.PI;
            double sin01 = (1.0 + Math.Sin(x)) / 2.0;
            return _min + (sin01 * (_max - _min));
        }
        private double _min;
        private double _max;
        private long _interval;
        private Stopwatch _watch;
    }
    public class Counter
    {
        public static readonly string CategoryName = "Nanocom";
        
        private static readonly object _counterSetKey = new object();
        private static List<Counter> _counterSet = null;

        private PerformanceCounter  _pc;
        private double _factor;
        private double _offset;
        private string _format;
        private CounterValueProvider _vp;

        public enum Index : int
        {
            Status = 0,
            EngineSpeed = 1,
            IdleSpeed = 2,
            RoadSpeed = 3,
            Battery = 4,
            Pot1 = 5, 
            Pot2 = 6, 
            Pot3 = 7, 
            PotSupply = 8, 
            CoolantTemp = 9,
            FuelTemp = 10,
            AirInletTemp = 11, 
            AirFlow = 12, 
            AmbientPressure = 13,
            ManifoldPressure = 14, 
            EGRModulator = 15, 
            EGRInlet = 16, 
            WastegateModulator = 17, 
            Cylinder1 = 18, 
            Cylinder2 = 19, 
            Cylinder3 = 20, 
            Cylinder4 = 21, 
            Cylinder5 = 22
        };
        static public Counter With(Index idx_)
        {
            Instanziate();
            return _counterSet[(int)idx_];
        }
        /// <summary>
        /// The list of all Nanocom performance counters. 
        /// </summary>
        /// <returns>The array of all nanocom performance counters</returns>
        static public Counter[] CounterList()
        {
            Instanziate();
            return _counterSet.ToArray();
        }
        public static void Instanziate()
        {
            lock (_counterSetKey )
            {
                if( _counterSet == null )
                {
                    PerformanceCounterCategory category = new PerformanceCounterCategory( CategoryName );
                    PerformanceCounter[] counter = category.GetCounters();
                    _counterSet = new List<Counter>();
                    _counterSet.Add( new Nanocom.Counter( counter[0], "0",    1)); // "Connection Status", "Connection status:\\n 0: not connected\\n1: connected\\n2: open\\n3:initialized", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add( new Nanocom.Counter( counter[1], "###0", 1)); // "Engine Speed [rpm]", "Engine speed help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add( new Nanocom.Counter( counter[2], "###0", 1 )); // "Idle Speed [rpm]", "Idle Speed Help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add( new Nanocom.Counter( counter[3], "##0.0", 10 ) ); // "Road Speed [km/h]", "Road Speed help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add( new Nanocom.Counter( counter[4], "#0.000", 1000 ) ); // "Battery [mV]", "Battery Voltage", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add( new Nanocom.Counter(counter[5], "#0.000", 1000)); // "Accel. Way 1 [mV]", "Accel. Way 1 Help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add( new Nanocom.Counter(counter[6], "#0.000", 1000)); // "Accel. Way 2 [mv]", "Accel. Way 2 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add( new Nanocom.Counter(counter[7], "#0.000", 1000)); // "Accel. Way 3 [mv]", "Accel. Way 3 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add( new Nanocom.Counter(counter[8], "#0.000", 1000)); // "Accel. Way Supply [mv]", "Accel. Way Supply help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[9], "##0.0", 10)); // "Coolant Temperature [1/10 °C]", "Coolant Temperature help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[10], "##0.0", 10)); // "Fuel Temperature [1/10 °C]", "Fuel Temperature help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[11], "##0.0", 10)); // "Air Inlet Temperature [1/10 °C]", "Air Inlet Temperature help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[12], "##0.0", 10)); // "Air Flow [1/10 Kg/h]", "Air Flow Help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[13], "##0.0", 10)); // "Ambient Pressure [1/10 Kpa]", "Ambient Pressure help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[14], "##0.0", 10)); // "Manifold Pressure [1/10 Kpa]", "Manifold Pressure help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[15], "##0.0", 10)); // "EGR Modulator [1/10 %]", "EGR Modulator help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[16], "##0.0", 10)); // ("EGR Inlet [1/10 %]", "EGR Inlet help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[17], "##0.0", 10)); // Wastegate Modulator [1/10 %]", "Wastegate Modulator help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[18], "#0", 1, 50)); // "Cylinder 1 Balance [+50]", "Cylinder 1 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[19], "#0", 1, 50)); // "Cylinder 2 Balance [+50]", "Cylinder 2 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[20], "#0", 1, 50)); // "Cylinder 3 Balance [+50]", "Cylinder 3 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[21], "#0", 1, 50)); // "Cylinder 4 Balance [+50]", "Cylinder 4 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                    _counterSet.Add(new Nanocom.Counter(counter[22], "#0", 1, 50)); // "Cylinder 5 Balance [+50]", "Cylinder 5 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
                 }
            }
        }
        private Counter( PerformanceCounter pc_, string format_) : this( pc_, format_, 1, 0, null ) {}
        private Counter( PerformanceCounter pc_, string format_, double factor_ ) :this( pc_, format_, factor_, 0, null ) {}
        private Counter( PerformanceCounter pc_, string format_, double factor_, long offset_ ) : this( pc_, format_, factor_, offset_, null) { }
        private Counter( PerformanceCounter pc_, string format_, double factor_, long offset_, CounterValueProvider provider_)
        {
            _pc = pc_;
            _format = format_;
            _factor = factor_;
            _offset = offset_;
            _vp = provider_;
        }

        public string Name 
        {
            get
            {
                return _pc.CounterName;
            }
        }

        public CounterValueProvider ValueProvider
        {
            get
            {
                return _vp;
            }
            set
            {
                _vp = value;
                _pc.ReadOnly = value == null;
            }
        }

        public long RawValue
        {
            get
            {
                return _pc.RawValue;
            }
            set
            {
                _pc.RawValue = value;
            }
        }

        public double Factor
        {
            get
            {
                return _factor;
            }
        }

        public double Value
        {
            get
            {
                return (RawValue - Offset) / Factor;
            }
            set
            {
                _pc.RawValue = Convert.ToInt64( Math.Round( (value + Offset) * Factor ) );
            }
        }
        static public void UpdateValues()
        {
            Counter[] counters = CounterList();
            foreach (Counter c in counters)
            {
                c.Value = c._vp.Value();
            }
        }

        public double Offset
        {
            get
            {
                return _offset;
            }
            set
            {
                _offset = value;
            }
        }

        public string Format
        {
            get
            {
                return _format;
            }
            set
            {
                _format = value;
            }
        }
    }
}
