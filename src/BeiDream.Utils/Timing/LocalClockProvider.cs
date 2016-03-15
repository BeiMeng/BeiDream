using System;

namespace BeiDream.Utils.Timing
{
    /// <summary>
    /// Implements <see cref="IClockProvider"/> to work with local times.
    /// </summary>
    public class LocalClockProvider : IClockProvider
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        /// �淶�������� <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dateTime">Ҫ�淶����ʱ��</param>
        /// <returns>�淶����ʱ��</returns>
        public DateTime Normalize(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                return DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
            }

            if (dateTime.Kind == DateTimeKind.Utc)
            {
                return dateTime.ToLocalTime();
            }

            return dateTime;
        }
    }
}