using System;

namespace BeiDream.Utils.Timing
{
    /// <summary>
    /// ����ִ��һЩ�����date-time����
    /// </summary>
    public static class Clock
    {
        /// <summary>
        /// �����������ִ�����е�<see cref="Clock"/>����
        /// Default value: <see cref="LocalClockProvider"/>.
        /// </summary>
        public static IClockProvider Provider
        {
            get { return _provider; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Can not set Clock to null!");
                }

                _provider = value;
            }
        }
        private static IClockProvider _provider;

        /// <summary>
        /// ���캯��
        /// </summary>
        static Clock()
        {
            Provider = new LocalClockProvider();
        }

        /// <summary>
        /// ʹ�� <see cref="Provider"/>��ȡ��ǰʱ��.
        /// </summary>
        public static DateTime Now
        {
            get { return Provider.Now; }
        }

        /// <summary>
        /// ʹ�õ�ǰ�� <see cref="Provider"/>���淶�������� <see cref="DateTime"/>
        /// </summary>
        /// <param name="dateTime">Ҫ�淶����ʱ��</param>
        /// <returns>�淶�����ʱ��</returns>
        public static DateTime Normalize(DateTime dateTime)
        {
            return Provider.Normalize(dateTime);
        }
    }
}