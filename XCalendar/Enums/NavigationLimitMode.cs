using System;

namespace XCalendar.Enums
{
    [Flags]
    public enum NavigationLimitMode
    {
        None = 0,
        LoopMinimum = 1,
        LoopMaximum = 2,
        LoopMinimumAndMaximum = LoopMinimum | LoopMaximum
    }
}