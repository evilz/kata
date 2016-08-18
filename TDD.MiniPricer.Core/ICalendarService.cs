using System;

namespace TDD.MiniPricer.Core
{
    public interface ICalendarService
    {
        Boolean IsOpenDay(DateTime dateTime);
    }
}