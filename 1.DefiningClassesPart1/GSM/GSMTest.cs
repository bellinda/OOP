using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSM
{
    public class GSMTest
    {
        public string TestGSMs()
        {
            GSM firstPhone = new GSM("Nokia 1251", "Nokia", 0.99M);
            GSM secondPhone = new GSM("Samsung Galaxy S4", "Samsung", 1249.99M, "Mr.Hiks", new Battery("standart", 370, 17, Battery.BatteryType.LiIon), new Display(5, 16000000), new Call());
            GSM thirdPhone = new GSM("LG Optimus L5", "LG", 1000.99M, "Ms.Collins", new Battery("standart", 900, 10, Battery.BatteryType.LiIon), new Display(4, 262144), new Call());

            GSM[] phones = new GSM[3] { firstPhone, secondPhone, thirdPhone };
            StringBuilder outputInfo = new StringBuilder();
            foreach (GSM phone in phones)
            {
                outputInfo.Append(phone + "\n");
            }
            return outputInfo.ToString();
        }
    }
}
