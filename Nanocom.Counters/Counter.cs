using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Nanocom.Counters
{
    public class Counter
    {
        public static readonly string CategoryName = "Nanocom";
        
        private static readonly object _counterSetKey = new object();
        private static List<Counter> _counterSet = null;

        private PerformanceCounter  _pc;
        private float _factor;
        private float _offset;
        private string _format;
        private string _unit;

        public enum Index : int
        {
            Status = 0,
            EngineSpeed = 1,
            RoadSpeed = 2,
            IdleSpeed = 3,
            Pot1 = 4, 
            Pot2 = 5, 
            Pot3 = 6, 
            PotSupply = 7,
            Battery = 8,
            AirFlow = 9,
            AmbientPressure = 10,
            ManifoldPressure = 11,
            AirInletTemp = 12,
            CoolantTemp = 13,
            FuelTemp = 14,
            EGRInlet = 15,
            EGRModulator = 16, 
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
        /// The list of all Nanocom.Counters performance counters. 
        /// </summary>
        /// <returns>The array of all nanocom performance counters</returns>
        static public Counter[] CounterList()
        {
            Instanziate();
            return _counterSet.ToArray();
        }
        public static void Instanziate()
        {
            Trace.WriteLine( "Counter.Instanziate enter");
            //lock (_counterSetKey )
            {
                if( _counterSet == null )
                {
                    try
                    {
                        _counterSet = new List<Counter>();
                        Trace.WriteLine("Counter.Instanziate List<Counter> created");
                        PerformanceCounterCategory category = new PerformanceCounterCategory(CategoryName);
                        Trace.WriteLine(String.Format("Counter.Instanziate category {0} created", CategoryName));
                        PerformanceCounter[] counter = category.GetCounters();
                        Trace.WriteLine("Counter.Instanziate counters created");
                        _counterSet.Add(new Counter(counter[(int)Index.Status], "0"));
                        _counterSet.Add(new Counter(counter[(int)Index.EngineSpeed], "###0", "[rpm]")); 
                        _counterSet.Add(new Counter(counter[(int)Index.RoadSpeed], "##0.0", "[km/h]", 10)); 
                        _counterSet.Add(new Counter(counter[(int)Index.IdleSpeed], "###0", "[rpm]", 1, 5000)); 
                        _counterSet.Add(new Counter(counter[(int)Index.Pot1], "#0.000", "[V]", 1000)); 
                        _counterSet.Add(new Counter(counter[(int)Index.Pot2], "#0.000", "[V]", 1000)); 
                        _counterSet.Add(new Counter(counter[(int)Index.Pot3], "#0.000", "[V]", 1000)); 
                        _counterSet.Add(new Counter(counter[(int)Index.PotSupply], "#0.000", "[V]", 1000));
                        _counterSet.Add(new Counter(counter[(int)Index.Battery], "#0.000", "[V]", 1000)); 
                        _counterSet.Add(new Counter(counter[(int)Index.AirFlow], "##0.0", "[Kg/h]", 10)); 
                        _counterSet.Add(new Counter(counter[(int)Index.AmbientPressure], "##0.0", "[kPa]", 10)); 
                        _counterSet.Add(new Counter(counter[(int)Index.ManifoldPressure], "##0.0", "[kPa]", 10)); 
                        _counterSet.Add(new Counter(counter[(int)Index.AirInletTemp], "##0.0", "[°C]", 10, 50)); 
                        _counterSet.Add(new Counter(counter[(int)Index.CoolantTemp], "##0.0", "[°C]", 10, 50)); 
                        _counterSet.Add(new Counter(counter[(int)Index.FuelTemp], "##0.0", "[°C]", 10, 50)); 
                        _counterSet.Add(new Counter(counter[(int)Index.EGRInlet], "##0.0", "[%]", 10)); 
                        _counterSet.Add(new Counter(counter[(int)Index.EGRModulator], "##0.0", "[%]", 10)); 
                        _counterSet.Add(new Counter(counter[(int)Index.WastegateModulator], "##0.0", "[%]", 10)); 
                        _counterSet.Add(new Counter(counter[(int)Index.Cylinder1], "#0", string.Empty, 1, 50)); 
                        _counterSet.Add(new Counter(counter[(int)Index.Cylinder2], "#0", string.Empty, 1, 50)); 
                        _counterSet.Add(new Counter(counter[(int)Index.Cylinder3], "#0", string.Empty, 1, 50)); 
                        _counterSet.Add(new Counter(counter[(int)Index.Cylinder4], "#0", string.Empty, 1, 50)); 
                        _counterSet.Add(new Counter(counter[(int)Index.Cylinder5], "#0", string.Empty, 1, 50)); 
                     }
                     catch( Exception e )
                     {
                         Trace.WriteLine(String.Format("Counter.Instanziate exception {0}", e)); 
                     }
                 }
            }
            Trace.WriteLine("Counter.Instanziate leave");
        }

        public static string StatusText( int state_ )
        {
            switch(state_)
            {
            case 0: return "Stopped";
            case 1: return "Disconnected";
            case 2: return "Connected";
            case 3: return "Synchronized";
            case 4: return "Initializing";
            case 5: return "Ready";
            case 6: return "Active";
            case 9: return "Paused";
            case 10: return "Error";
            case 11: return "NotReady";
            default:
                 return state_.ToString("State({0}");
            }
        }
    
        private Counter(PerformanceCounter pc_, string format_ ) : this(pc_, format_, string.Empty, 1, 0) { }
        private Counter(PerformanceCounter pc_, string format_, string unit_) : this(pc_, format_, unit_, 1, 0) { }
        private Counter( PerformanceCounter pc_, string format_, string unit_, float factor_ ) :this( pc_, format_, unit_, factor_, 0 ) {}
        private Counter( PerformanceCounter pc_, string format_, string unit_, float factor_, float offset_ )
        {
            _pc = pc_;
            _format = format_;
            _unit = unit_;
            _factor = factor_;
            _offset = offset_;
        }

        public string Name 
        {
            get
            {
                return _pc.CounterName;
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

        public float Factor
        {
            get
            {
                return _factor;
            }
        }

        public float Value
        {
            get
            {
                return (RawValue / Factor) - Offset;
            }
            set
            {
                _pc.RawValue = Convert.ToInt64( Math.Round( (value + Offset) * Factor ) );
            }
        }

        public float Offset
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

        public PerformanceCounter PC
        {
            get
            {
                return _pc;
            }
        }

        public string Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
            }
        }
    }
}
