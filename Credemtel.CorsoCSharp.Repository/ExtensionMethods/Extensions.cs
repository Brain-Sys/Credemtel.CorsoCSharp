using Credemtel.CorsoCSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Repository.ExtensionMethods
{
    public static class Extensions
    {
        public static byte[] GetDump(this ILoader loader)
        {
            return new byte[100];
        }

        public static DateTime ToItaly(this DateTime dateTime)
        {
            TimeSpan timespan = TimeSpan.FromHours(1);
            var italianTimezone = TimeZoneInfo.GetSystemTimeZones()
            .Where(t => t.DisplayName.Contains("Amsterdam, Berlin"))
            .FirstOrDefault();

            if (italianTimezone != null)
            {
                timespan = italianTimezone.GetUtcOffset(DateTime.Now);
            }

            return dateTime.ToUniversalTime().Add(timespan);
        }
    }
}