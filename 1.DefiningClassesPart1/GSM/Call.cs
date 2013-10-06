using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GSM
{
    public class Call
    {
        private string date;
        private string time;
        private string dialedPhoneNum;
        private long durationSecs;

        public Call() : this("01.01.2013", "00:00:00", "0000000000", 0)
        {
        }

        public Call(string date, string time) : this(date, time, "0000000000", 0)
        {
        }

        public Call(string date, string time, string dialedPhoneNum) : this(date, time, dialedPhoneNum, 0)
        {
        }

        public Call(string date, string time, string dialedPhoneNum, long durationSecs)
        {
            this.date = date;
            this.time = time;
            this.dialedPhoneNum = dialedPhoneNum;
            this.durationSecs = durationSecs;
        }

        public string Date
        {
            get { return this.date; }
            set
            {
                if (!Regex.IsMatch(value, "[0-9]{2}.[0-9]{2}.[0-9]{4}"))
                {
                    throw new ArgumentException("Incorrect input!");
                }
                else
                {
                    this.date = value;
                }
            }
        }

        public string Time
        {
            get { return this.time; }
            set
            {
                if (!Regex.IsMatch(value, "[0-9]{2}:[0-9]{2}:[0-9]{2}"))
                {
                    throw new ArgumentException("Incorrect input!");
                }
                else
                {
                    this.time = value;
                }
            }
        }

        public string DialedPhoneNum
        {
            get { return this.dialedPhoneNum; }
            set
            {
                if (!Regex.IsMatch(value, "[0-9]{10}"))
                {
                    throw new ArgumentException("Incorrect input!");
                }
                else
                {
                    this.dialedPhoneNum = value;
                }
            }
        }

        public long DurationSecs
        {
            get { return this.durationSecs; }
            set { this.durationSecs = value; }
        }

        public override string ToString()
        {
            return string.Format("Date of the call: {0}, Time of the call: {1}, Dialed phone number: {2}, Duration of the call in seconds: {3}", this.date, this.time, this.dialedPhoneNum, this.durationSecs);
        }
    }
}
