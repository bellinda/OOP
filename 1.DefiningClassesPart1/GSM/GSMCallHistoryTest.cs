using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSM
{
    class GSMCallHistoryTest
    {
        public string TestCallHistory()
        {
            GSM gsm = new GSM("Alcatel 210", "Alcatel Industry");
            gsm.AddCalls(new Call("01.12.2014", "05:30:21", "0887999888", 460));
            gsm.AddCalls(new Call("12.12.2012", "12:12:12", "0898888999", 780));
            gsm.AddCalls(new Call("09.09.2013", "03:10:57", "0887654321", 1234));
            StringBuilder outputHistory = new StringBuilder();
            
            //printing the whole call history:
            outputHistory.AppendLine("CallHistory:");
            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                outputHistory.AppendLine(gsm.CallHistory[i].ToString());
            }

            //total price of the calls:
            decimal totalPrise = gsm.TotalPriceOfCalls(0.37M);
            string temp = String.Format("TotalPriceOfCalls = {0}", totalPrise);
            outputHistory.AppendLine(temp);

            //finding the index of the longest call:
            long maxDuration = gsm.CallHistory[0].DurationSecs;
            int index=0;
            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                if (maxDuration < gsm.CallHistory[i].DurationSecs)
                {
                    maxDuration = gsm.CallHistory[i].DurationSecs;
                    index = i;
                }
            }

            //printing the number of the longest call:
            temp = String.Format("Longest call -> number {0}", index + 1);
            outputHistory.AppendLine(temp);

            //deleting the history of the longest call:
            gsm.DeleteCalls(gsm.CallHistory[index]);

            //printing the total price without the price for the longest call:
            temp = String.Format("Total price without the longest cal: {0}", gsm.TotalPriceOfCalls(0.37M));
            outputHistory.AppendLine(temp);

            //deleting the whole call history:
            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                gsm.DeleteCalls(gsm.CallHistory[i]);
            }
            return outputHistory.ToString();
        }
    }
}
