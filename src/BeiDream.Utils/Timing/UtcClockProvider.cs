using System;

namespace BeiDream.Utils.Timing
{
    /// <summary>
    /// ʵ�ֽӿ� <see cref="IClockProvider"/>�����ṩUTCʱ��.
    /// </summary>
    public class UtcClockProvider : IClockProvider
    {
        /// <summary>
        /// ��ȡ��ǰʱ��
        /// </summary>
        public DateTime Now
        {
            get { return DateTime.UtcNow; }
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
                return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            }

            if (dateTime.Kind == DateTimeKind.Local)
            {
                return dateTime.ToUniversalTime();
            }

            return dateTime;
        }
    }
}