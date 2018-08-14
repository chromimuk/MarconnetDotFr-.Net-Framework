using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarconnetDotFr_MVC.Helper
{
    public class DateHelper
    {
        public static int GetYearDifference(DateTime d1, DateTime d2)
        {
            DateTime older, newer;

            if (d1 < d2)
            {
                older = d1;
                newer = d2;
            }
            else if (d1 > d2)
            {
                older = d2;
                newer = d1;
            }
            else
            {
                return 0;
            }

            int age = newer.Year - older.Year;
            if (newer.Month < older.Month || (newer.Month == older.Month && newer.Day < older.Day))
                age--;

            return age;
        }
    }
}