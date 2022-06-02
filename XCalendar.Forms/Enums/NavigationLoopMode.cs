using System;

namespace XCalendar.Forms.Enums
{
    [Flags]
    public enum NavigationLoopMode
    {
        DontLoop = 0,
        LoopMinimum = 1,
        LoopMaximum = 2,
        LoopMinimumAndMaximum = LoopMinimum | LoopMaximum
    }
}