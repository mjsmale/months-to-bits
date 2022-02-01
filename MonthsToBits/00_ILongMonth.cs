namespace MonthsToBits
{
    internal interface ILongMonth
    {
        /// <summary>
        /// This is what defines our first requirement
        /// to determine if a months is long or not
        /// </summary>
        /// <param name="month">Number of month</param>
        /// <returns>true if long month, else false</returns>
        public bool IsLongMonth(int month);
    }
}
