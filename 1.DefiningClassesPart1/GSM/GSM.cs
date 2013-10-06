using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSM
{
    public class GSM
    {
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery batteryCharacteristics = new Battery();
        private Display displayCharacteristics = new Display();
        private static GSM iPhone4S;
        private List<Call> callHistory = new List<Call>();

        public GSM(string model, string manufacturer) : this(model, manufacturer, 0M, null, new Battery(), new Display(), new Call())
        {
        }

        public GSM(string model, string manufacturer, decimal price, Battery batteryCharacteristics) : this(model, manufacturer, price, null, batteryCharacteristics, new Display(), new Call())
        {
        }

        public GSM(string model, string manufacturer, Battery batteryCharacteristics, Display displayCharacteristics) : this(model, manufacturer, 0M, null, batteryCharacteristics, displayCharacteristics, new Call())
        {
        }

        public GSM(string model, string manufacturer, decimal price) : this(modle, manufacturer, price, null, new Battery(), new Display(), new Call())
        {
        }

        public GSM(string model, string manufacturer, decimal price, string owner) : this(model, manufacturer, price, owner, new Battery(), new Display(), new Call())
        {
        }

        public GSM(string model, string manufacturer, decimal price, string owner, Battery batteryCharacteristics, Display displayCharacteristics, Call call)
        {
            if (model == null || manufacturer == null || owner == null)
            {
                throw new NullReferenceException();
            }
            if (price < 0)
            {
                throw new ArgumentException("Negative price was entered!");
            }
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.batteryCharacteristics = batteryCharacteristics;
            this.displayCharacteristics = displayCharacteristics;
            callHistory.Add(call);
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

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException();
                }
                this.manufacturer = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price should be positive number or equal to 0");
                }
                this.price = value;
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException();
                }
                this.owner = value;
            }
        }

        public Battery BatteryCharacteristics
        {
            get { return this.batteryCharacteristics; }
            set { this.batteryCharacteristics = value; }
        }

        public Display DisplayCharacteristics
        {
            get { return this.displayCharacteristics; }
            set { this.displayCharacteristics = value; }
        }

        public static GSM IPhone4S
        {
            get { return new GSM("iPhone4S", "Apple", 1200, "Mr.Angelov", new Battery("built-in", 200, 14, Battery.BatteryType.LiIon), new Display(3.5f, 10000000), new Call()); }
        }

        public List<Call> CallHistory
        {
            get { return this.callHistory; }
            set { this.callHistory = value; }
        }

        public override string ToString()
        {
            return String.Format("Model: {0}, Manufacturer: {1}, Price: {2}, Owner: {3}, Battery characteristics: {4}, Display characteristics: {5}", this.model, this.manufacturer, this.price, this.owner, this.batteryCharacteristics, this.displayCharacteristics);
        }

        public void AddCalls(Call newCall)
        {
            this.callHistory.Add(newCall);
        }

        public void DeleteCalls(Call oldCall)
        {
            this.callHistory.Remove(oldCall);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public decimal TotalPriceOfCalls(decimal singlePricePerMinute)
        {
            decimal totalPrice = 0M;
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                if (callHistory[i].DurationSecs % 60 != 0)
                {
                    totalPrice += (callHistory[i].DurationSecs / 60 + 1) * singlePricePerMinute;
                }
                else
                {
                    totalPrice += (callHistory[i].DurationSecs / 60) * singlePricePerMinute;
                }
            }
            return totalPrice;
        }

        static void Main()
        {
            //GSM one = new GSM("abc", "me");
            //Console.WriteLine(one);
            GSMTest test = new GSMTest();
            string output = test.TestGSMs();
            Console.WriteLine(output);
            Console.WriteLine(GSM.IPhone4S);
            GSMCallHistoryTest testingHistory = new GSMCallHistoryTest();
            Console.WriteLine(testingHistory.TestCallHistory());
            Console.WriteLine();
            
        }
    }
}
