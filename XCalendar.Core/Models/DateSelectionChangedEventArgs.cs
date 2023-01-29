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
        public DateSelectionChangedEventArgs(IList<DateTime> previousSelection, IList<DateTime> currentSelection)
        {
            PreviousSelection = new List<DateTime>(previousSelection ?? throw new ArgumentNullException(nameof(previousSelection)));
            CurrentSelection = new List<DateTime>(currentSelection ?? throw new ArgumentNullException(nameof(currentSelection)));
        }
        #endregion
    }
}

