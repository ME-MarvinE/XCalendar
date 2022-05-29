using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using XCalendar.Core.Models;

namespace XCalendarFormsSample.Models
{
    public class Event : BaseObservableModel
    {
        #region Properties
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Today;
        public Color Color { get; set; }
        #endregion
    }
}
