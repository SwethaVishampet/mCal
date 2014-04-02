using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs2103_project_UI_logic
{
   
   public class Task
    {
        
        private string taskName;
        private DateTime systemdate;
        private string date;
        private Time startTime;
        private Time endTime;
        private bool markAsDone;
        private bool starred;
        private int taskID;
       
        //private Time timeObj;
        public Task()
        {
            taskName = null;
            systemdate = DateTime.Now;
            string[] tempDate = systemdate.ToString().Split(' ');
            date = tempDate[0];
            string[] tempTime = tempDate[1].Split(':');
            startTime = new Time(tempTime[0], tempTime[1], tempTime[2], tempDate[2]);
            endTime = new Time(startTime);
            markAsDone = false;
            starred = false;
            taskID = 0;
            
        }
        public bool writeTaskName(string passedtaskname)
        {
            taskName = passedtaskname;
            return true;
        }
        public bool writeDate(string passedDate)
        {
            date = passedDate;
            return true;
        }
        private Time writeTime(string passedTime)
        {
            Time time=new Time();
            string[] tempTimeWithMeridiem = passedTime.Split(' ');
            string[] tempTime = tempTimeWithMeridiem[0].Split(':');

            if (tempTime.Count() == 3 && tempTimeWithMeridiem.Count() > 1)       //time given is 06:00:00 pm
                time = new Time(tempTime[0], tempTime[1], tempTime[2], tempTimeWithMeridiem[1]);
            else if (tempTime.Count() == 2 && tempTimeWithMeridiem.Count() > 1)     //time given is 6:00 pm
                time = new Time(tempTime[0], tempTime[1], "00", tempTimeWithMeridiem[1]);
            else if (tempTime.Count() == 1 && tempTimeWithMeridiem.Count() > 1) //time given is 6 pm
                time = new Time(tempTime[0], "00", "00", tempTimeWithMeridiem[1]);
            else
                time = new Time("00", "00", "00", "AM");   //default time

            return time;
        }
        public void writeStartTime(string passedTime)
        {
            startTime=writeTime(passedTime);
        }
        public void writeEndTime(string passedTime)
        {
            endTime = writeTime(passedTime);
        }
        public void writeMarkAsDone(bool mark)
        {
            markAsDone = mark;
        }
        public void writeStarred(bool star)
        {
            starred = star;
        }
        public void writeTaskID(int id=1)
        {
            taskID=id;
        }
        public string getTaskName()
        {
            return taskName;
        }

        public string getTaskDate()
        {
            return date;
        }
        public int getTaskID()
        {
            return taskID;
        }
       public string  getstartTime()
        {
            string Time = startTime.getHour().ToString() + ":" + startTime.getMin().ToString() + ":" + startTime.getSec().ToString() + " " + startTime.getMeridiem();
            return Time;
        }

       public string getendTime()
       {
           string Time = endTime.getHour().ToString() + ":" + endTime.getMin().ToString() + ":" + endTime.getSec().ToString() + " " + endTime.getMeridiem();
           return Time;
       }
    }
    
}
