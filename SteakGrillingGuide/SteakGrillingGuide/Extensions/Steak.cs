using EnumsNET;
using SteakGrillingGuide.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteakGrillingGuide.Extensions
{
    public static class Steak
    {
        public static double GetFirstSidePercentage(this Steaks steak, int counter, double totalTime)
        {
            double percentage = 0;
            //steak is not ready for the grill yet
            if (counter > steak.GetSideOneStartTime(totalTime))
            {
                percentage = 100;
            }
            //everything is done, yay!
            else if (counter <= steak.GetSideTwoStartTime(totalTime))
            {
                percentage = 0;
            }
            else
            {
                percentage = Math.Round(((counter - (steak.DurationSetting.SecondSide * 60)) / (steak.DurationSetting.FirstSide * 60)) * 100, MidpointRounding.AwayFromZero);
            }
            return percentage;
        }

        public static double GetSecondSidePercentage(this Steaks steak, int counter, double totalTime)
        {
            double percentage = 0;
            //steak is not ready for the grill yet
            if (counter > steak.GetSideTwoStartTime(totalTime))
            {
                percentage = 100;
            }
            //everything is done, yay!
            else if(counter == totalTime)
            {
                percentage = 0;
            }
            else
            {
                percentage = Math.Round((counter / (steak.DurationSetting.SecondSide * 60)) * 100, MidpointRounding.AwayFromZero);
            }
            return percentage;
        }
    }
}
