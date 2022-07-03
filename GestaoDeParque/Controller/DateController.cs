using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoDeParque.Controller
{
    public class DateController
    {
        public static DateTime GetWithHour(DateTime data)
        {
            return new DateTime(data.Year, data.Month, data.Day);
        }

        public static DateTime GetWithDay(DateTime data)
        {
            return new DateTime(data.Hour, data.Minute, data.Second);
        }

    }
}
