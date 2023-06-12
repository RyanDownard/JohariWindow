using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteakGrillingGuide.Data
{
    public class Steaks
    {
        public string Name { get; set; }
        public bool OnGrill { get; set; } = false;
        public bool Flipped { get; set; } = false;
        public double Thickness { get; set; }
        public CookingStyle CookingStyle { get; set; }
        public DurationSettings DurationSetting { get; set; }


        public double GetSideOneStartTime(double LongestTime)
        {
            if(LongestTime * 60 == DurationSetting.TotalTime * 60)
            {
                return LongestTime * 60;
            }
            else
            {
                return (DurationSetting.TotalTime * 60) % (LongestTime * 60);
            }
        } 

        public double GetSideTwoStartTime(double LongestTime)
        {
            if (LongestTime * 60 == DurationSetting.TotalTime * 60)
            {
                return (DurationSetting.TotalTime * 60) - (DurationSetting.FirstSide * 60);
            }
            else
            {
                var offset = (DurationSetting.TotalTime * 60) % (LongestTime * 60);
                return offset - (DurationSetting.FirstSide * 60);
            }
        }
    }
}
