using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddyModels.Extensions
{
    public static class DateTimeExtensions
    {

        public static string GetFormattedPostedTime(this DateTime dt)
        {
            var timeSpan = DateTime.Now - dt;
            if ((int)timeSpan.TotalDays > 0)
            {
                return $"{timeSpan.Days}d";
            }
            else if ((int)timeSpan.TotalHours > 0)
            {
                return $"{timeSpan.Hours}h";
            }
            else if ((int)timeSpan.TotalMinutes > 0)
            {
                return $"{timeSpan.Minutes}min";
            }
            else
            {

                return "just now";
            }
        }
    }
}
