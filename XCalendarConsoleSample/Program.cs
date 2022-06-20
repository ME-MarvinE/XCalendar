using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XCalendar.Core.Enums;
using XCalendar.Core.Interfaces;
using XCalendar.Core.Models;

namespace XCalendarConsoleSample
{
    public class Program
    {
        public static ICalendar<CalendarDay> Calendar = new Calendar<CalendarDay>()
        {
            SelectedDates = new ObservableRangeCollection<DateTime>(),
            NavigatedDate = DateTime.Today,
            NavigationLowerBound = DateTime.Today.AddYears(-2),
            NavigationUpperBound = DateTime.Today.AddYears(2),
            StartOfWeek = DayOfWeek.Monday,
            CustomDayNamesOrder = new ObservableRangeCollection<DayOfWeek>()
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            },
            SelectionAction = SelectionAction.Modify,
            NavigationLoopMode = NavigationLoopMode.LoopMinimumAndMaximum,
            SelectionType = SelectionType.Single,
            NavigationTimeUnit = NavigationTimeUnit.Month,
            PageStartMode = PageStartMode.FirstDayOfMonth,
            Rows = 2,
            AutoRows = true,
            AutoRowsIsConsistent = true,
            UseCustomDayNamesOrder = false,
            TodayDate = DateTime.Today,
            ForwardsNavigationAmount = 1,
            BackwardsNavigationAmount = -1
        };
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                WriteCalendar();
                PerformCalendarAction(Console.ReadKey().Key);
            }
        }
        public static void WriteCalendar()
        {
            Console.WriteLine($"----------{Calendar.NavigatedDate:MMMM yyyy}----------");

            WriteWeek(Calendar.DayNamesOrder, " ");

            for (int i = 0; i < Calendar.Days.Count; i++)
            {
                ICalendarDay Day = Calendar.Days[i];

                if (i % 7 == 0)
                {
                    Console.WriteLine();
                }

                WriteDay(Day);

                Console.Write("  ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
        public static void WriteWeek(IEnumerable<DayOfWeek> DaysOfWeek, string WhiteSpace)
        {
            if (DaysOfWeek == null) { throw new ArgumentNullException(nameof(DaysOfWeek)); }

            foreach (var DayOfWeek in DaysOfWeek)
            {
                Console.Write($"{DayOfWeek}".Substring(0, 3));
                if (DayOfWeek != DaysOfWeek.Last())
                {
                    Console.Write(WhiteSpace);
                }
            }
        }
        public static void WriteDay(ICalendarDay Day)
        {
            DayState DayState = EvaluateDayState(Day);

            switch (DayState)
            {
                case DayState.CurrentMonth:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case DayState.OtherMonth:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;

                case DayState.Today:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case DayState.Selected:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;

                case DayState.Invalid:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.Write(Day.DateTime == null ? "   "  : Day.DateTime.Value.ToString("dd"));
        }
        public static void PerformCalendarAction(ConsoleKey Key)
        {
            switch (Key)
            {
                case ConsoleKey.Escape:
                    return;

                case ConsoleKey.LeftArrow:
                    Calendar.NavigateCalendar(-1);
                    break;

                case ConsoleKey.RightArrow:
                    Calendar.NavigateCalendar(1);
                    break;
                case ConsoleKey.UpArrow:
                    Calendar.Rows += 1;
                    break;
                case ConsoleKey.DownArrow:
                    Calendar.Rows -= 1;
                    break;
                case ConsoleKey.R:
                    Calendar.AutoRows = !Calendar.AutoRows;
                    break;
                case ConsoleKey.C:
                    Calendar.AutoRowsIsConsistent = !Calendar.AutoRowsIsConsistent;
                    break;
                case ConsoleKey.S:
                    Console.WriteLine("Write the date to be selected in the format dd/mm/yyyy");
                    string Input = Console.ReadLine();
                    if (DateTime.TryParse(Input, out DateTime DateToSelect))
                    {
                        Calendar.ChangeDateSelection(DateToSelect);
                        Console.WriteLine($"Selection Successful. Press any key to continue.");
                    }
                    else
                    {
                        Console.WriteLine("Could not parse input to DateTime. Press any key to continue.");
                    }
                    Console.ReadLine();
                    break;
            }
        }
        public static DayState EvaluateDayState(ICalendarDay Day)
        {
            bool DayIsOtherMonth = !Day.IsCurrentMonth;

            if (Day.IsInvalid)
            {
                return DayState.Invalid;
            }
            else if (Day.IsSelected && Day.IsCurrentMonth)
            {
                return DayState.Selected;
            }
            else if (Day.IsToday && Day.IsCurrentMonth)
            {
                return DayState.Today;
            }
            else if (DayIsOtherMonth)
            {
                return DayState.OtherMonth;
            }
            else if (Day.IsCurrentMonth)
            {
                return DayState.CurrentMonth;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public static bool IsDateTimeCurrentMonth(DateTime DateTime, DateTime NavigatedDate)
        {
            return DateTime.Month == NavigatedDate.Month && DateTime.Year == NavigatedDate.Year;
        }
        public static bool IsDateTimeInvalid(DateTime DateTime, DateTime LowerBound, DateTime UpperBound)
        {
            return DateTime.Date < LowerBound.Date || DateTime.Date > UpperBound.Date;
        }
        public static bool IsDateTimeToday(DateTime DateTime, DateTime TodayDate)
        {
            return DateTime.Date == TodayDate.Date;
        }
        public static bool IsDateTimeSelected(DateTime DateTime, IEnumerable<DateTime> SelectedDates)
        {
            return SelectedDates.Any(x => x.Date == DateTime.Date) == true;
        }
    }
}
