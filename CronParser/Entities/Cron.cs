using System;
using System.Collections.Generic;
using System.Text;

namespace CronParser.Entities
{
    public class Cron
    {
        public string Minute { get; private set; }
        public string Hour { get; private set; }
        public string DayOfMonth { get; private set; }
        public string Month { get; private set; }
        public string DayOfWeek { get; private set; }

        public Cron(string minute, string hour, string dayOfMonth, string month, string dayOfWeek)
        {
            SetMinute(minute);
            SetHour(hour);
            SetDayOfMonth(dayOfMonth);
            SetMonth(month);
            SetDayOfWeek(dayOfWeek);
        }

        private void SetMinute(string minute)
        {
            Minute = minute;
        }

        private void SetHour(string hour)
        {
            Hour = hour;
        }

        private void SetDayOfMonth(string dayOfMonth)
        {
            DayOfMonth = dayOfMonth;
        }

        private void SetMonth(string month)
        {
            Month = month;
        }

        private void SetDayOfWeek(string dayOfWeek)
        {
            DayOfWeek = dayOfWeek;
        }
    }
}
