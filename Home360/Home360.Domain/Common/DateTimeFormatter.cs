namespace Home360.Domain.Common
{
    public static class DateTimeFormatter
    {
        public static DateTime GetISTTime(DateTime dt)
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dt, TimeZoneInfo.Local.Id, "India Standard Time");
        }
    }
}
