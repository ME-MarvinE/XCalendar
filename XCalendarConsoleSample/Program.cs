using System;
using System.Collections.Generic;
using System.Linq;
using XCalendar.Core.Enums;
using XCalendar.Core.Interfaces;
using XCalendar.Core.Models;
using XCalendar.Core.Extensions;

namespace XCalendarConsoleSample
{
    public class Program
    {
        public static Calendar<CalendarDay> Calendar = new Calendar<CalendarDay>()
        {
            SelectedDates = new ObservableRangeCollection<DateTime>(),
            NavigatedDate = DateTime.Today,
            NavigationLowerBound = DateTime.Today.AddYears(-2),
            NavigationUpperBound = DateTime.Today.AddYears(2),
            StartOfWeek = DayOfWeek.Monday,
            SelectionAction = SelectionAction.Modify,
            NavigationLoopMode = NavigationLoopMode.LoopMinimumAndMaximum,
            SelectionType = SelectionType.Single,
            PageStartMode = PageStartMode.FirstDayOfMonth,
            Rows = 2,
            AutoRows = true,
            AutoRowsIsConsistent = true,
            TodayDate = DateTime.Today
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
                ICalendarDay day = Calendar.Days[i];

                if (i % 7 == 0)
                {
                    Console.WriteLine();
                }

                WriteDay(day);

                Console.Write("  ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
        public static void WriteWeek(IEnumerable<DayOfWeek> daysOfWeek, string whiteSpace)
        {
            if (daysOfWeek == null) { throw new ArgumentNullException(nameof(daysOfWeek)); }

            foreach (var dayOfWeek in daysOfWeek)
            {
                Console.Write($"{dayOfWeek}".Substring(0, 3));
                if (dayOfWeek != daysOfWeek.Last())
                {
                    Console.Write(whiteSpace);
                }
            }
        }
        public static void WriteDay(ICalendarDay day)
        {
            DayState dayState = EvaluateDayState(day);

            switch (dayState)
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

            Console.Write(day.DateTime.ToString("dd"));
        }
        public static void PerformCalendarAction(ConsoleKey Key)
        {
            TimeSpan timeSpanToNavigateBy;
            DateTime addMonthsDateTime;

            switch (Key)
            {
                case ConsoleKey.Escape:
                    return;

                case ConsoleKey.LeftArrow:
                    if (Calendar.NavigatedDate.TryAddMonths(-1, out addMonthsDateTime))
                    {
                        timeSpanToNavigateBy = addMonthsDateTime - Calendar.NavigatedDate;
                    }
                    else
                    {
                        timeSpanToNavigateBy = TimeSpan.MinValue;
                    }

                    Calendar.Navigate(timeSpanToNavigateBy);
                    break;

                case ConsoleKey.RightArrow:
                    if (Calendar.NavigatedDate.TryAddMonths(1, out addMonthsDateTime))
                    {
                        timeSpanToNavigateBy = addMonthsDateTime - Calendar.NavigatedDate;
                    }
                    else
                    {
                        timeSpanToNavigateBy = TimeSpan.MaxValue;
                    }

                    Calendar.Navigate(timeSpanToNavigateBy);
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
                    string input = Console.ReadLine();
                    if (DateTime.TryParse(input, out DateTime dateToSelect))
                    {
                        Calendar.ChangeDateSelection(dateToSelect);
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
        public static DayState EvaluateDayState(ICalendarDay day)
        {
            bool dayIsOtherMonth = !day.IsCurrentMonth;

            if (day.IsInvalid)
            {
                return DayState.Invalid;
            }
            else if (day.IsSelected && day.IsCurrentMonth)
            {
                return DayState.Selected;
            }
            else if (day.IsToday && day.IsCurrentMonth)
            {
                return DayState.Today;
            }
            else if (dayIsOtherMonth)
            {
                return DayState.OtherMonth;
            }
            else if (day.IsCurrentMonth)
            {
                return DayState.CurrentMonth;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public static bool IsDateTimeCurrentMonth(DateTime dateTime, DateTime navigatedDate)
        {
            return dateTime.Month == navigatedDate.Month && dateTime.Year == navigatedDate.Year;
        }
        public static bool IsDateTimeInvalid(DateTime dateTime, DateTime lowerBound, DateTime upperBound)
        {
            return dateTime.Date < lowerBound.Date || dateTime.Date > upperBound.Date;
        }
        public static bool IsDateTimeToday(DateTime dateTime, DateTime todayDate)
        {
            return dateTime.Date == todayDate.Date;
        }
        public static bool IsDateTimeSelected(DateTime dateTime, IEnumerable<DateTime> selectedDates)
        {
            return selectedDates.Any(x => x.Date == dateTime.Date) == true;
        }
    }
}
