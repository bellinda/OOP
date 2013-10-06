using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSM
{
    public class Battery
    {
        public enum BatteryType
        {
            LiIon, NiMH, NiCd, LiPoly
        }

        private string model;
        private int hoursIdle;
        private int hoursTalk;
        private BatteryType batteryType = BatteryType.LiIon;

        public Battery():this(null, 0, 0, BatteryType.LiIon)
        {
        }

        public Battery(string model, int hoursIdle, int hoursTalk, BatteryType batteryType)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.batteryType = batteryType;
        }

        public Battery(BatteryType batteryType)
        {
            this.batteryType = batteryType;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException();
                }
                this.model = value;
            }
        }

        public int HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Negative number of hours!");
                }
                this.hoursIdle = value;
            }
        }

        public int HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value < 0)
                {
                    throw new NullReferenceException("Negative number of hours!");
                }
                this.hoursTalk = value;
            }
        }




        public override string ToString()
        {
            return string.Format("Battery model: {0}, Hours idle: {1}, Hours talk: {2}, Battery type: {3}", this.model, this.hoursIdle, this.hoursTalk, this.batteryType);
        }

    }
}
