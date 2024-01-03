﻿using System.Globalization;

namespace LogForU.Core.Utilities
{
    public static class DateTimeValidator
    {
        private static readonly ISet<string> formats =
            new HashSet<string> { "M/dd/yyyy h:mm:ss tt" };

        public static void AddFormat(string format) 
            => formats.Add(format);

        internal static bool ValidateDateTime(string dateTime)
        {
            foreach (var format in formats)
            {
                if (DateTime.TryParseExact(dateTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
