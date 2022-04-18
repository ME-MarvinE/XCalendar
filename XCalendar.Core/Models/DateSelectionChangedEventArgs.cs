using System;
using System.Collections.Generic;

namespace XCalendar.Core.Models
{
    public class DateSelectionChangedEventArgs : EventArgs
    {
        #region Properties
        public IReadOnlyList<DateTime> PreviousSelection { get; }
        public IReadOnlyList<DateTime> CurrentSelection { get; }
        #endregion

        #region Constructors
        public DateSelectionChangedEventArgs(IList<DateTime> PreviousSelection, IList<DateTime> CurrentSelection)
        {
            this.PreviousSelection = new List<DateTime>(PreviousSelection ?? throw new ArgumentNullException(nameof(PreviousSelection)));
            this.CurrentSelection = new List<DateTime>(CurrentSelection ?? throw new ArgumentNullException(nameof(CurrentSelection)));
        }
        #endregion
    }
}

