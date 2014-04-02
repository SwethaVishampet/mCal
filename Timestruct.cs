using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs2103_project_UI_logic
{
    class Time
    {
        int timeHour;
        int timeMin;
        int timeSec;
        string meridiem;

        public Time(string hour="00",string min="00",string sec="00",string mer="AM")
        {
            timeHour = int.Parse(hour);
            timeMin = int.Parse(min);
            timeSec = int.Parse(sec);
            meridiem = mer;

        }
        public Time(Time startTime)
        {
            if (startTime.timeHour == 23)
            {
                timeHour = 0;
                meridiem = "AM";
            }
            else
            timeHour = startTime.timeHour + 1;
            timeMin = startTime.timeMin;
            timeSec = startTime.timeSec;
            if (startTime.timeHour > 11)
            {
                meridiem = "PM";
            }
            else
                meridiem = "AM";
        }
        public int getHour()
        {
            return timeHour;
        }
        public int getMin()
        {
            return timeMin;
        }
        public int getSec()
        {
            return timeSec;
        }
        public string getMeridiem()
        {
            return meridiem;
        }
    }
}
