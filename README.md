# XCalendar [![](https://img.shields.io/static/v1?label=Sponsor&message=%E2%9D%A4&logo=GitHub&color=%23fe8e86)](https://github.com/sponsors/Me-MarvinE)
A cross-platform plugin for .NET providing a Calendar API and DateTime extensions.

UI controls are available for Xamarin Forms and .NET MAUI, able to run on any platform the respective framework supports.

* **[Getting Started](https://github.com/ME-MarvinE/XCalendar/wiki/Getting-Started)**
* **[Sample App](https://github.com/ME-MarvinE/XCalendar/wiki/Sample-App)**
* **[Wiki](https://github.com/ME-MarvinE/XCalendar/wiki)**
* **[Roadmap](https://github.com/ME-MarvinE/XCalendar/wiki/Roadmap)**
* [Nuget Package (.NET)](https://www.nuget.org/packages/XCalendar.Core) [![NuGet](https://img.shields.io/nuget/v/XCalendar.Core.svg?label=NuGet)](https://www.nuget.org/packages/XCalendar.Core/)
* [Nuget Package (Xamarin Forms)](https://www.nuget.org/packages/XCalendar.Forms) [![NuGet](https://img.shields.io/nuget/v/XCalendar.Forms.svg?label=NuGet)](https://www.nuget.org/packages/XCalendar.Forms/)
* [Nuget Package (.NET MAUI)](https://www.nuget.org/packages/XCalendar.Maui) [![NuGet](https://img.shields.io/nuget/v/XCalendar.Maui.svg?label=NuGet)](https://www.nuget.org/packages/XCalendar.Maui/)

## Features
* Ability to use the Calendar from code without referencing a UI framework.
* Ability to use and reference your own models by implementing interfaces like `ICalendar`, `ICalendarDay`, or `IEvent`.
* Ability to set the number of rows/weeks shown or have it be automatic.
* Ability to change the start of the week to any day of the week.
* Ability to select single, multiple or a range of dates.
* Ability to specify a selection direction, for example restricting range selection from start to finish or finish to start
* Ability to restrict navigation to a range of dates and define how the calendar loops.
* Ability to specify your own custom order of days of week, with support for duplicates and non-chronological orders.
* Fully customisable CalendarView with custom controls, templates, and exposed default styles and commands.
* Support for localising text (such as days of the week and day numbers).
* And more!

## Roadmap
### Features (Xamarin Forms/MAUI)
* Default calendar control that exposes many customisation properties, making the calendar easier to use out-of-the-box instead of requiring usage of templates and styles.
* Default implementation of selection and navigation commands, making the calendar easier to use out-of-the-box.
* Default feature-based calendar controls such as "EventCalendar"/"AppointmentCalendar".
* Some type of time schedule control [Discussion 153](https://github.com/ME-MarvinE/XCalendar/discussions/153)
* `Culture`/`Locale` property for CalendarView
* YearView
* DecadeView
* CenturyView
* Day, Month, and year properties as an alternative to NavigatedDate.

### Maui Community Toolkit
Follow the discussion for moving XCalendar into the Maui Community Toolkit [here](https://github.com/CommunityToolkit/Maui/discussions/265).

## Images
#### Standard Calendar
<img src="https://user-images.githubusercontent.com/73718829/181294940-a12bfe05-6caa-473f-9cb4-a862927931e9.jpg" width="45%">

#### Custom Days Of Week (Unordered/Duplicates)
<img src="https://user-images.githubusercontent.com/73718829/181294949-1bd0e011-c0b4-4641-a779-e0f4215f4317.jpg" width="45%">

#### Custom Days Of Week (3 Days Of Week)
<img src="https://user-images.githubusercontent.com/73718829/181294956-50c49fa6-bcd4-4409-8504-7edd08cb5b52.jpg" width="45%">

#### Custom Week Amount (1 Week)
<img src="https://github.com/user-attachments/assets/a7b3a9ad-2941-45d3-9e1e-caee88e09d03" width="45%">

#### Custom Week Amount (2 Weeks)
<img src="https://github.com/user-attachments/assets/a2527e06-c925-42bd-aa7f-86871f88c0bf" width="45%">

#### Day Styles
<img src="https://user-images.githubusercontent.com/73718829/181294977-bcb4c74c-8ae5-4289-b841-efec946d87d5.jpg" width="45%">


# Sample App


The sample app has a flyout menu where you can access the following pages:

## Playground Page
A page where you can modify almost every single property of the CalendarView. Perfect for a quick look, showcases, tests and experiments!

<img src="https://user-images.githubusercontent.com/73718829/181289378-28512c2b-e3b4-415a-b720-24b8130866ef.jpg" width="45%">
<br/>
<img src="https://user-images.githubusercontent.com/73718829/181290783-3655cf46-2275-467c-8507-8a31553ef36f.jpg" width="45%">
<br/>
<img src="https://user-images.githubusercontent.com/73718829/181290789-a56b2517-f6cf-4cbc-a140-568707750e39.jpg" width="45%">
<br/>
<img src="https://user-images.githubusercontent.com/73718829/181290791-1ebb26b2-24e7-4dc4-b086-5295a4b14ab0.jpg" width="45%">
<br/>
<img src="https://user-images.githubusercontent.com/73718829/181291657-9c4570d8-37a2-4909-9a68-4d833279ebba.jpg" width="45%">

## Examples Page
A page where you can search for examples of how to use XCalendar.  

<img src="https://user-images.githubusercontent.com/73718829/209573500-f96f9d88-2e58-43c0-9cdd-cf1cd94fd3ce.png" width="45%">

Examples include: 

### Event Calendar
 
<img src="https://user-images.githubusercontent.com/73718829/181292097-ada95992-e480-44c2-aec6-a3f48813ea01.jpg" width="45%">

### Custom DatePicker Dialog
<img src="https://user-images.githubusercontent.com/73718829/181292138-35f29f2f-877a-4245-a87d-9c7d7ecd1383.jpg" width="45%">
<img src="https://user-images.githubusercontent.com/73718829/181292154-a4db3661-ece5-4cac-8ee6-76542d6ef34f.jpg" width="45%">

### Selection
<img src="https://user-images.githubusercontent.com/73718829/181292178-517627b1-2603-4b95-94e4-3232ef1961d5.jpg" width="45%">

### Using DayView

<img src="https://user-images.githubusercontent.com/73718829/209572305-294451f5-b62f-44bb-b330-5ba44309d1ae.png" width="45%">

### Customising A Day

<img src="https://user-images.githubusercontent.com/73718829/209572332-b78a457e-7c1c-44d8-9d48-1124efe837c1.png" width="45%">

### Animated Swipable Calendar

https://user-images.githubusercontent.com/73718829/209573341-b506e399-631b-4cdd-b840-d17bb5ddfb85.mp4

### Connecting Selected Days
<img src="https://user-images.githubusercontent.com/73718829/231608640-2ab28bb0-d802-4fdb-b84d-bc5e00da571a.png" width="45%">

### Duolingo Streak Calendar

| Official App | Sample App |
| ------------ | ---------- |
| <img src="https://github.com/ME-MarvinE/XCalendar/assets/73718829/1663a8df-9c7e-4e23-8a5d-3c981bcc030d" width="100%"> | <img src="https://github.com/ME-MarvinE/XCalendar/assets/73718829/276d2a66-ef58-4425-af45-791d3100decb" width="100%"> |

# Basic Usage

## .NET

#### Install the NuGet package
* https://www.nuget.org/packages/XCalendar.Core [![NuGet](https://img.shields.io/nuget/v/XCalendar.Core.svg?label=NuGet)](https://www.nuget.org/packages/XCalendar.Core/)

#### Now you can use the Calendar
```C#
public Calendar MyCalendar { get; set; } = new Calendar();
```

## Xamarin Forms

#### Install the NuGet package
* https://www.nuget.org/packages/XCalendar.Forms [![NuGet](https://img.shields.io/nuget/v/XCalendar.Forms.svg?label=NuGet)](https://www.nuget.org/packages/XCalendar.Forms/)

#### Create a Calendar in your ViewModel
```C#
public Calendar MyCalendar { get; set; } = new Calendar();
```

#### Add the following xmlns to your page or view
```xaml
xmlns:xc="clr-namespace:XCalendar.Forms.Views;assembly=XCalendar.Forms"
```

#### Bind to the properties of your Calendar
```xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    x:Class="App1.MainPage"
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:xc="clr-namespace:XCalendar.Forms.Views;assembly=XCalendar.Forms">
    
        <xc:CalendarView
            Days="{Binding MyCalendar.Days}"
            DaysOfWeek="{Binding MyCalendar.DayNamesOrder}"
            NavigatedDate="{Binding MyCalendar.NavigatedDate}"/>

</ContentPage>

```

*Alternatively, these properties can be set directly from code-behind without the use of MVVM.*

#### Youtube Tutorial (Outdated - Uses version 1.2.1 for Xamarin Forms)
[![Beautiful, Extensive and FREE Calendar Control for Xamarin.Forms](https://img.youtube.com/vi/aw7b_Xt1fng/0.jpg)]([https://www.youtube.com/watch?v=bmkizbS4jb4](https://www.youtube.com/watch?v=aw7b_Xt1fng))

## .NET MAUI

#### Install the NuGet package
* https://www.nuget.org/packages/XCalendar.Maui [![NuGet](https://img.shields.io/nuget/v/XCalendar.Maui.svg?label=NuGet)](https://www.nuget.org/packages/XCalendar.Maui/)

#### Create a Calendar in your ViewModel
```C#
public Calendar MyCalendar { get; set; } = new Calendar();
```

#### Add the following xmlns to your page or view
```xaml
xmlns:xc="clr-namespace:XCalendar.Maui.Views;assembly=XCalendar.Maui"
```

#### Bind to the properties of your Calendar
```xaml
<ContentPage
    x:Class="MauiApp1.MainPage"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:xc="clr-namespace:XCalendar.Maui.Views;assembly=XCalendar.Maui">
    
        <xc:CalendarView
            Days="{Binding MyCalendar.Days}"
            DaysOfWeek="{Binding MyCalendar.DayNamesOrder}"
            NavigatedDate="{Binding MyCalendar.NavigatedDate}"/>

</ContentPage>
```

*Alternatively, these properties can be set directly from code-behind without the use of MVVM.*

# Navigation Overview
## Calendar

Navigation can be performed by setting the `NavigatedDate` property of the Calendar.

Alternatively, navigation can be performed using the `Navigate` method; it takes a parameter specifying the `TimeSpan` to navigate by. The Calendar can handle exceptions caused by non-representable dates such as `DateTime.MaxValue.AddDays(1)`.

Variable time units such as months can be obtained by using the'AddMonths' method on a `DateTime` and subtracting the result from the current date. The 'TryAdd' and 'TrySubtract' methods in `DateTimeExtensions` are useful if you ever plan to navigate to the bounds of the `DateTime` struct.

### Limiting

Navigation can be limited to a specific range of dates by changing the `NavigationLowerBound` and `NavigationUpperBound` properties of the Calendar.

### Looping
You can specify the behaviour of the CalendarView when trying to navigate outside the bounds defined by `NavigationLowerBound` and `NavigationUpperBound` by changing the `NavigationLoopMode` property.

## CalendarView

The CalendarView does not have navigation built into it by default. Instead, it exposes the `BackwardsArrowCommand`, `BackwardsArrowCommandParameter`, `ForwardsArrowCommand`, and `ForwardsArrowCommandParameter` which can be used to implement this functionality.

The CalendarView displays its navigation bar using a `NavigationView`. Its appearance can be changed using the `NavigationViewTemplate` property of the CalendarView.

# Displaying Dates Overview

## Calendar

### Start of the Week

You can specify what day of the week should be considered as the start by setting the `StartOfWeek` property of the Calendar.

For Example:
* When `StartOfWeek` is `DayOfWeek.Monday`, the first row of February 2022 would be 1st Feb - 7th Feb.
* When `StartOfWeek` is `DayOfWeek.Wednesday`, the first row of February 2022 would be 26th Jan - 1st Feb
* When `StartOfWeek` is `DayOfWeek.Sunday`, the first row of February 2022 would be 31st Jan - 6th Feb

### Rows

You can set how many rows you want to display by changing the `Rows` property of the Calendar.

Alternatively, the Calendar can automatically set the `Rows` value to the minimum amount needed to display every week of the `NavigatedDate`'s month. This can be done by setting the `AutoRows` property of the Calendar to `true`. You can ensure that `AutoRows` always uses the highest `Rows` value required in the year by setting the `AutoRowsIsConsistent` property of the Calendar to `true`.

For example, when the start of the week is Monday, these are the values that will be calculated using `AutoRows`:
| Date | Value | Value (AutoRowsIsConsistent) |
| ----- | -------- | -------------------------------- |
| January 2021 | 5 | 6 |
| February 2021 | 4 | 6 |
| March 2021 | 5 | 6 |
| April 2021 | 5 | 6 |
| May 2021 | 6 | 6 |
| June 2021 | 5 | 6 |
| July 2021 | 5 | 6 |
| August 2021 | 6 | 6 |
| September 2021 | 5 | 6 |
| Ocotober 2021 | 5 | 6 |
| November 2021 | 5 | 6 |
| December 2021 | 5 | 6 |

### Day Of Week Order

The displayed dates are stored in the `DayNamesOrder` property.

The value of the `DayNamesOrder` is automatically calculated by the Calendar based on the values of its `StartOfWeek` and `CustomDayNamesOrder`: 

* First, the Calendar determines the default order of the days of the week using the value of the `StartOfWeek` property of the Calendar.
* Then, the Calendar creates a default list of dates based on the days of week in the calculated order.
* If the `CustomDayNamesOrder` property of the Calendar **is** `null`, these default dates will be shown. 
* If the `CustomDayNamesOrder` property of the Calendar **is not** `null`, the Calendar will cherry-pick values from these default dates, mapping their DayOfWeek to the values specified in the `CustomDayNamesOrder` property and shows the result.

The `CustomDayNamesOrder` property supports duplicates and non-chronological orders, but must contain at least one value. 

<details>

<summary>

#### CustomDayNamesOrder Examples

</summary>

| StartOfWeek | DayNamesOrder | Resulting Row (January 2023 Week 1) |
|------------ | ------------- | ----------------------------------- |
| Monday | Mon, Tue, Wed, Thu, Fri, Sat, Sun | 26th Dec, 27th Dec, 28th Dec, 29th Dec, 30th Dec, 31st Dec, 1st Jan |
| Monday | Sun, Sat, Fri, Thu, Wed, Tue, Mon | 1st Jan, 31st Dec, 30th Dec, 29th Dec, 28th Dec, 27th Dec, 26th Dec |
| Monday | Wed, Fri, Mon, Thu, Sat, Sun, Tue | 28th Dec, 30th Dec, 26th Dec, 29th Dec, 31st Dec, 1st Jan, 27th Dec |
| Monday | Mon, Thu, Sun | 26th Dec, 29th Dec, 1st Jan |
| Monday | Mon, Sun, Tue Tue, Mon | 26th Dec, 1st Jan, 27th Dec, 27th Dec, 26th Dec |

| StartOfWeek | DayNamesOrder | Resulting Row (January 2023 Week 1) |
|------------ | ------------- | ----------------------------------- |
| Tuesday | Mon, Tue, Wed, Thu, Fri, Sat, Sun | 27th Dec, 28th Dec, 29th Dec, 30th Dec, 31st Dec, 1st Jan, 2nd Jan |
| Tuesday | Sun, Sat, Fri, Thu, Wed, Tue, Mon | 1st Jan, 31st Dec, 30th Dec, 29th Dec, 28th Dec, 27th Dec, 2nd Jan |
| Tuesday | Wed, Fri, Mon, Thu, Sat, Sun, Tue | 28th Dec, 30th Dec, 2nd Jan, 29th Dec, 31st Dec, 1st Jan, 27th Dec |
| Tuesday | Mon, Thu, Sun | 2nd Jan, 29th Dec, 1st Jan |
| Tuesday | Mon, Sun, Tue Tue, Mon | 2nd Jan, 1st Jan, 27th Dec, 27th Dec, 2nd Jan |

| StartOfWeek | DayNamesOrder | Resulting Row (January 2023 Week 1) |
|------------ | ------------- | ----------------------------------- |
| Wednesday | Sun, Sat, Fri, Thu, Wed, Tue, Mon | 1st Jan, 31st Dec, 30th Dec, 29th Dec, 28th Dec, 3rd Jan, 2nd Jan |
| Wednesday | Mon, Tue, Wed, Thu, Fri, Sat, Sun | 28th Dec, 29th Dec, 30th Dec, 31st Dec, 1st Jan, 2nd Jan, 3rd Jan |
| Wednesday | Wed, Fri, Mon, Thu, Sat, Sun, Tue | 28th Dec, 30th Dec, 2nd Jan, 29th Dec, 31st Dec, 1st Jan, 3rd Jan |
| Wednesday | Mon, Thu, Sun | 2nd Jan, 29th Dec, 1st Jan |
| Wednesday | Mon, Sun, Tue Tue, Mon | 2nd Jan, 1st Jan, 3rd Jan, 3rd Jan, 2nd Jan |

| StartOfWeek | DayNamesOrder | Resulting Row (January 2023 Week 1) |
|------------ | ------------- | ----------------------------------- |
| Thursday | Mon, Tue, Wed, Thu, Fri, Sat, Sun | 29th Dec, 30th Dec, 31st Dec, 1st Jan, 2nd Jan, 3rd Jan, 4th Jan |
| Thursday | Sun, Sat, Fri, Thu, Wed, Tue, Mon | 1st Jan, 31st Dec, 30th Dec, 29th Dec, 4th Jan, 3rd Jan, 2nd Jan |
| Thursday | Wed, Fri, Mon, Thu, Sat, Sun, Tue | 4th Jan, 30th Dec, 2nd Jan, 29th Dec, 31st Dec, 1st Jan, 3rd Jan |
| Thursday | Mon, Thu, Sun | 2nd Jan, 29th Dec, 1st Jan |
| Thursday | Mon, Sun, Tue Tue, Mon | 2nd Jan, 1st Jan, 3rd Jan, 3rd Jan, 2nd Jan |

| StartOfWeek | DayNamesOrder | Resulting Row (January 2023 Week 1) |
|------------ | ------------- | ----------------------------------- |
| Friday | Mon, Tue, Wed, Thu, Fri, Sat, Sun | 30th Dec, 31st Dec, 1st Jan, 2nd Jan, 3rd Jan, 4th Jan, 5th Jan |
| Friday | Sun, Sat, Fri, Thu, Wed, Tue, Mon | 1st Jan, 31st Dec, 30th Dec, 5th Jan, 4th Jan, 3rd Jan, 2nd Jan |
| Friday | Wed, Fri, Mon, Thu, Sat, Sun, Tue | 4th Jan, 30th Dec, 2nd Jan, 5th Jan, 31st Dec, 1st Jan, 3rd Jan |
| Friday | Mon, Thu, Sun | 2nd Jan, 5th Jan, 1st Jan |
| Friday | Mon, Sun, Tue Tue, Mon | 2nd Jan, 1st Jan, 3rd Jan, 3rd Jan, 2nd Jan |

| StartOfWeek | DayNamesOrder | Resulting Row (January 2023 Week 1) |
|------------ | ------------- | ----------------------------------- |
| Saturday | Mon, Tue, Wed, Thu, Fri, Sat, Sun | 31st Dec, 1st Jan, 2nd Jan, 3rd Jan, 4th Jan, 5th Jan, 6th Jan |
| Saturday | Sun, Sat, Fri, Thu, Wed, Tue, Mon | 1st Jan, 31st Dec, 6th Jan, 5th Jan, 4th Jan, 3rd Jan, 2nd Jan |
| Saturday | Wed, Fri, Mon, Thu, Sat, Sun, Tue | 4th Jan, 6th Jan, 2nd Jan, 5th Jan, 31st Dec, 1st Jan, 3rd Jan |
| Saturday | Mon, Thu, Sun | 2nd Jan, 5th Jan, 1st Jan |
| Saturday | Mon, Sun, Tue Tue, Mon | 2nd Jan, 1st Jan, 3rd Jan, 3rd Jan, 2nd Jan |

| StartOfWeek | DayNamesOrder | Resulting Row (January 2023 Week 1) |
|------------ | ------------- | ----------------------------------- |
| Sunday | Mon, Tue, Wed, Thu, Fri, Sat, Sun | 1st Jan, 2nd Jan, 3rd Jan, 4th Jan, 5th Jan, 6th Jan, 7th Jan |
| Sunday | Sun, Sat, Fri, Thu, Wed, Tue, Mon | 1st Jan, 7th Jan, 6th Jan, 5th Jan, 4th Jan, 3rd Jan, 2nd Jan |
| Sunday | Wed, Fri, Mon, Thu, Sat, Sun, Tue | 4th Jan, 6th Jan, 2nd Jan, 5th Jan, 7th Jan, 1st Jan, 3rd Jan |
| Sunday | Mon, Thu, Sun | 2nd Jan, 5th Jan, 1st Jan |
| Sunday | Mon, Sun, Tue Tue, Mon | 2nd Jan, 1st Jan, 3rd Jan, 3rd Jan, 2nd Jan |

</details>
  
### Page Start Mode

You can set the date that the page starts on relative to the `NavigatedDate` by setting the `PageStartMode` property of the Calendar.

For Example:  
  
* If `Rows` is set to 1, `PageStartMode.FirstDayOfMonth` would only ever display the first week of the `NavigatedDate`'s month.
* If `Rows` is set to 6, `PageStartMode.FirstDayOfYear` would only ever display the first 6 weeks of the `NavigatedDate`'s year.

### Events/Appointments
To add events to the calendar use the calendar's `events` property. The calendar will add indicators on days that are within the start date and end date of an event. The position and shape of the indicators can be modified by using various properties and templates of a DayView inside the `DayTemplate` property of the CalendarView.

### Localisation

The calendar uses `CultureInfo.CurrentCulture` for its logic. For example if `StartOfWeek` has not been set, it will default to `CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek`.

## CalendarView

The bare minimum needed to get the CalendarView working is to set the `NavigatedDate`, `DayNamesOrder`, and `Days` properties of the CalendarView.

### Customising days
A day can be customised by setting the CalendarView's `DayTemplate` property. 

If using a DayView, the essential properties you need to set to replicate existing functionality are the `IsSelected`, `IsToday`, `IsCurrentMonth`, and `IsInvalid` properties. You can view more info on how these states work as well as all the properties in the DayView at the [DayView Properties](https://github.com/ME-MarvinE/XCalendar/wiki/DayView-Properties) wiki page.

### Customising the days container

The container for days can be customised by setting the CalendarView's `DaysViewTemplate` property.

### Customising the days of the week

To customise the look of each day of the week, the `DayNameTemplate` property of the CalendarView can be used. It is a `DataTemplate` with a BindingContext of `DayOfWeek`. 

To change the TextColor for example you would put a `Label` in a `DataTemplate` and change the `Label`'s `TextColor` property.

### Customising the days of week container

There is also the `DayNamesTemplate` which lets you modify the container for the days of the week. This is a `ControlTemplate`.

### Localisation

To change the displayed days of the week, change `CultureInfo.CurrentUICulture`. <br/>
To change the displayed month names, change `CultureInfo.CurrentCulture`.

Best to do this before `InitializeComponent()` in App.xaml.cs. In the future I may add a `culture` property to `Calendar` or `CalendarView` so that you don't have to set the culture for the entire application.

# Date Selection Overview

## Calendar

Selection can be performed by changing/modifying the `SelectedDates` collection.

Alternatively, selection can be performed by calling the `ChangeDateSelection` method. 

Selection can also be performed by setting the `RangeSelectionStart` and `RangeSelectionEnd` properties to non-null values. If they are both not null, `CommitRangeSelection` will be called and they will be set back to null. This mimicks what the `ChangeDateSelection` method does when the Calendar's `SelectionType` property is set to `SelectionType.Range`.

The way in which dates are selected can be changed by setting the Calendar's `SelectionType` property.

The action taken when calling the `ChangeDateSelection` or `CommitRangeSelection` methods can be changed by setting the `SelectionAction` property.  

Different combinations of the `SelectionType` and `SelectionAction` result in different behaviours when calling the `ChangeDateSelection` method.
 

For example:  
* `SelectionType.Single` + `SelectionAction.Replace` will achieve traditional single selection.
* `SelectionType.Single` + `SelectionAction.Modify` will achieve traditional multiple selection.
* `SelectionType.Range` + `SelectionAction.Replace` will achieve traditional range selection.

Additionally, the calendar's `SelectionDirection` property can be used to control what order dates must be selected in.


For example:
* `SelectionType.Range` + `SelectionAction.Replace` + `SelectionDirection.StartToEnd` will cause the range selection to only be changed by selecting the earlier, then later date.
* `SelectionType.Range` + `SelectionAction.Replace` + `SelectionDirection.EndToStart` will cause the range selection to only be changed by selecting the later, then earlier date.
* `SelectionType.Single` + `SelectionAction.Modify` + `SelectionDirection.Confined` will cause the selected date to require being in between the earliest and latest selected dates.

## CalendarView

The CalendarView does not implement selection by default. The easiest way to implement this is to set the CalendarView's `DayTemplate` to a DayView and set its `CurrentMonthCommand`, `TodayComand`, and `SelectedCommand` to a command that will select the underlying `ICalendarDay`'s date. 

To make it easier to replicate default behaviour of calendar days, there is a default style for each state of the DayView in the `XCalendar.[Forms/Maui].Styles.DefaultStyles` namespace which can be used via a namespace reference in XAML and the `{x:Static }` markup extension. These styles can also be inherited from to easily customise the look and behaviour of a day in a specific state.

# Tips
| Reference | Tip |
| --------- | --- |
| [Displaying Dates](https://github.com/ME-MarvinE/XCalendar/wiki/Displaying-Dates) | A general rule to follow is that your `PageStartMode` should always be smaller than or equal to the time unit the calendar is navigating. |
| [Displaying Dates](https://github.com/ME-MarvinE/XCalendar/wiki/Displaying-Dates) | If the amount of rows does not initialise correctly, try setting the `AutoRows` property before the `Rows` property. |
| None | When setting the value of `DayNameTemplate`, in some cases, the `DataTemplate`'s `x:DataType` property needs to be set in order for Converters or DataTriggers to work. |
| [Sample App](https://github.com/ME-MarvinE/XCalendar/wiki/Sample-App) | When copying code from the sample app, watch out for copy-paste errors.<br/><br/>Common issues:<ul><li>Copied code references a style defined in the sample app but not your app.</li><li>Copied code references something in the ViewModel that isn't present in your app's ViewModel.</li><li>Copied code relies on nuget packages installed in the sample app which aren't present in your app.</li></ui> |

# Documentation (4.6.1)

## Calendar

### Properties

| Property | Type | Description |
| ---------| -----| ----------- |
| <h4>NavigatedDate</h4> | `DateTime` | The date the Calendar is currently navigated to.  |
| <h4>TodayDate</h4> | `DateTime` | The date the Calendar will treat as 'Today'.  |
| <h4>NavigationLowerBound</h4> | `DateTime` | The inclusive lower bound of the range of dates the [`NavigatedDate`](Calendar-Properties#NavigatedDate) can be set to. |
| <h4>NavigationUpperBound</h4>| `DateTime` | The inclusive upper bound of the range of dates the [`NavigatedDate`](Calendar-Properties#NavigatedDate) can be set to. |
| <h4>NavigationLoopMode</h4> | `NavigationLoopMode` | The behaviour of the calendar when navigating outside the allowed range.<br/><br/><ul><li>`NavigationLoopMode.DontLoop`: Don't loop.</li><li>`NavigationLoopMode.LoopMinimum`: Loop to the upper bound when navigating past the lower bound.</li><li>`NavigationLoopMode.LoopMaximum`: Loop to the lower bound when navigating past the upper bound.</li><li>`NavigationLoopMode.LoopMiniumAndMaximum`: Loop as defined in both `LoopMinimum` and `LoopMaximum`.</li></ul> |
| <h4>SelectionType</h4> | `SelectionType` | Defines how the `ChangeDateSelection` method processes the selected date.<br/><br/><ul><li>`SelectionType.None`: Nothing happens.</li><li>`SelectionType.Single`: The `SelectionAction` is performed on the date.</li><li>`SelectionType.Range`: Sets the calendar's `RangeSelectionStart` property to the date if it's null, otherwise sets the calendar's `RangeSelectionEnd` property if it isn't null, otherwise performs the `SelectionAction` on the dates between `RangeSelectionStart` and `RangeSelectionEnd` inclusive.</li></ul> |
| <h4>SelectionAction</h4> | `SelectionAction` | Defines what happens when a date is selected via the `ChangeDateSelection` or `CommitRangeSelection` methods.<br/><br/><ul><li>`SelectionAction.Add`: The dates will be added to the selection if not already present.</li><li>`SelectionAction.Remove`: The dates will be removed from the selection if present.</li><li>`SelectionAction.Modify`: Performs both `SelectionAction.Add` and `SelectionAction.Remove` on the selection.</li><li>`SelectionAction.Replace`: Will replace the current selection with the dates if they are not the same.</li></ul> |
| <h4>SelectionDirection</h4> | `SelectionDirection` | Defines where the newly selected date must be in relation to the earliest and latest selected dates when changing the date selection via the `ChangeDateSelection` method. If it isn't in the correct place, nothing happens.<br/><br/><ul><li>`SelectionDirection.StartToEnd`: The newly selected date must be later than or equal to the earliest selected date.</li><li>`SelectionDirection.EndToStart`: The newly selected date must be earlier than or equal to the latest selected date.</li><li>`SelectionDirection.Confined`: The newly selected date must be in between or equal to the earliest and latest selected date.</li><li>`SelectionDirection.ConfinedReverse`: The newly selected date must be outside or equal to the earliest selected date and latest selected date.</li></ul> |
| <h4>RangeSelectionStart</h4> | `DateTime?` | The start of the range of dates to perform selection on inclusive.<br/><br/>If `RangeSelectionStart` and [`RangeSelectionEnd`](Calendar-Properties#RangeSelectionEnd) are not null, `CommitRangeSelection` will be called and their values will be set back to null. |
| <h4>RangeSelectionEnd</h4> | `DateTime?` | The end of the range of dates to perform selection on inclusive.<br/><br/>If [`RangeSelectionStart`](Calendar-Properties#RangeSelectionStart) and `RangeSelectionEnd` are not null, `CommitRangeSelection` will be called and their values will be set back to null. |
| <h4>Rows</h4> | `int` | The number of rows to display. Each row represents one week.  |
| <h4>AutoRows</h4> | `bool` | Whether the calendar should automatically determine the minimum number of [`Rows`](Calendar-Properties#Rows)needed to display the month or not. |
| <h4>AutoRowsIsConsistent</h4> | `bool` | Determines if the [`AutoRows`](Calendar-Properties#AutoRows) property should display the same number of rows throughout each month in the year.  |
| <h4>StartOfWeek</h4> | `DayOfWeek` | The day of the week that will be considered as the start of the week. |
| <h4>DayNamesOrder</h4> | `ObservableRangeCollection<DayOfWeek>` | The order that the days of the week are currently displayed in. If [`CustomDayNamesOrder`](Calendar-Properties#CustomDayNamesOrder) is not null, this value is set to it. |
| CustomDayNamesOrder</h4> | `ObservableRangeCollection<DayOfWeek>` | When this value is not null, [`DayNamesOrder`](Calendar-Properties#DayNamesOrder) is set to this. |
| <h4>PageStartMode</h4> | `PageStartMode` | How the calendar will use the [`NavigatedDate`](Calendar-Properties#NavigatedDate) to generate the first date in the page (and therefore the subsequent sequence of dates).<br/><br/>`PageStartMode.FirstDayOfWeek` Use the first date in [`NavigatedDate`](Calendar-Properties#NavigatedDate)'s Week.<br/> `PageStartMode.FirstDayOfMonth` Use the first date in the first week of [`NavigatedDate`](Calendar-Properties#NavigatedDate)'s Month.<br/> `PageStartMode.FirstDayOfYear` Use the first date in the first week of [`NavigatedDate`](Calendar-Properties#NavigatedDate)'s Year.<br/>  |
| <h4>Days</h4> | `ObservableRangeCollection<T>` | The days currently being displayed by the calendar.<br/><br/>**Note:** Displayed days != displayed dates.<br/> For example if [`DayNamesOrder`](Calendar-Properties#DayNamesOrder) is "Monday, Monday, Monday Tuesday" and the row is displaying the week of 10th January 2022 - 16th January 2022, there would be 4 **days** displayed but only 2 **dates** displayed: 10th January 2022 and 11th January 2022. |
| <h4>Days</h4> | `ObservableRangeCollection<TEvent> where TEvent : IEvent`  | The events/appointments of the calendar.<br/><br/>The default class and interface for events have 4 properties: <ul><li>`Title` (`string`)</li><li>`Description` (`string`)</li><li>`Start Date` (`DateTime`)</li><li> `EndDate`(`DateTime?`)</li></ul>The event will be passed to any `ICalendarDay`'s `Events` property when their `DateTime` falls between the `StartDate` and `EndDate`. If `EndDate` is `null`, any day after the `StartDate` will have that event.  |


### Events

| Event | Description |
| ----- | ----------- |
| DateSelectionChanged | This is raised when the [`SelectedDates`](CalendarView#SelectedDates) collection is changed or modified.<br/> It uses the `DateSelectionChangedEventArgs` class to provide the `PreviousSelection` and `CurrentSelection` properties.<br/><br/>**Note:** `DateSelectionChanged` will still be called if the collection contains the same elements but in a different order. Having duplicates may also cause unexpected behaviour. |
| DaysUpdating | Raised at the start of the 'UpdateDays' method. |
| DaysUpdated | Raised at the end of the 'UpdateDays' method. |

## CalendarView

### Properties

| Property | Type | Description |
| ---------| -----| ----------- |
| <h4>NavigatedDate</h4> | `DateTime` | The date used to generate the days that are currently being displayed. |
| <h4>Days</h4> | `IEnumerable<object>`<br/> | The days currently being displayed by the calendar. The objects should implement the `ICalendarDay` interface. |
| <h4>DaysOfWeek</h4> | `IList<DayOfWeek>`<br/> | The days of the week currently being displayed by the calendar. |
| <h4>LeftArrowCommand</h4> | `ICommand`<br/> | The `LeftArrowCommand` of the [NavigationView](https://github.com/ME-MarvinE/XCalendar/wiki/NavigationView-Properties). |
| <h4>LeftArrowCommandParameter</h4> | `object`<br/> | The `LeftArrowCommandParameter` of the [NavigationView](https://github.com/ME-MarvinE/XCalendar/wiki/NavigationView-Properties). |
| <h4>RightArrowCommand</h4> | `ICommand`<br/> | The `RightArrowCommand` of the [NavigationView](https://github.com/ME-MarvinE/XCalendar/wiki/NavigationView-Properties).|
| <h4>RightArrowCommandParameter</h4> | `object`<br/> | The `RightArrowCommandParameter` of the [NavigationView](https://github.com/ME-MarvinE/XCalendar/wiki/NavigationView-Properties). |
| <h4>DayTemplate</h4> | `DataTemplate` | How an individual day in [`Days`](CalendarView-Properties#Days) should be displayed. The `DataTemplate`'s `BindingContext` will be an `object` which should implement `ICalendarDay`.|
| <h4>NavigationViewTemplate</h4> | `ControlTemplate` | How the navigation bar is displayed. |
| <h4>DayNamesTemplate</h4> | `ControlTemplate` | How the [`DaysOfWeek`](CalendarView-Properties#DaysOfWeek) should be displayed. |
| <h4>DayNamesHeightRequest</h4> | `double`| The `HeightRequest` of the DayNamesView. |
| <h4>DayNameTemplate</h4> | `DataTemplate` | How an individual `DayOfWeek` in the [`DaysOfWeek`](CalendarView-Properties#DaysOfWeek) should be displayed. The `DataTemplate`'s `BindingContext` will be an `ICalendarDay`. |
| <h4>DayNameVerticalSpacing</h4> | `double`| The vertical spacing between the DayNames in the DayNamesView. |
| <h4>DayNameHorizontalSpacing</h4> | `double`| The horizontal spacing between the day names in the days of week. |
| <h4>DaysViewTemplate</h4> | `ControlTemplate` | How [`Days`](CalendarView-Properties#Days) should be displayed. |
| <h4>DaysViewHeightRequest</h4> | `double`| The `HeightRequest` of the DaysView.|

## NavigationView

### Properties

NavigationView contains all of the properties of a [Label](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/label).

| Property | Type | Description |
| ---------| -----| ----------- |
| <h4>DateTime</h4> | `DateTime`<br/> | The `DateTime` to be shown. |
| <h4>LeftArrowCommand</h4> | `ICommand`<br/> | The command to execute when the left arrow is pressed. |
| <h4>LeftArrowCommandParameter</h4> | `object`<br/> | The command parameter used for `LeftArrowCommand` |
| <h4>RightArrowCommand</h4> | `ICommand`<br/> | The command to execute when the right arrow is pressed. |
| <h4>RightArrowCommandParameter</h4> | `object`<br/> | The command parameter used for `RightArrowCommand` |
| <h4>ArrowColor</h4> | `Color`| The colour of the arrows. |
| <h4>ArrowBackgroundColor</h4> | `Color` | The `BackgroundColor` of the arrows. |
| <h4>ArrowCornerRadius</h4> | `float`| The `CornerRadius` of the arrows. |

## DaysView

### Properties

| Property | Type | Description |
| ---------| -----| ----------- |
| <h4>Days</h4> | `IEnumerable<object>` | The days currently being displayed by the view. The objects should implement the `ICalendarDay` interface. |
| <h4>DaysOfWeek</h4> | `IList<DayOfWeek>` | The days of the week currently being displayed by the view. |
| <h4>DayTemplate</h4> | `DataTemplate` | How an individual day in [`Days`](DaysView-Properties#Days) should be displayed. |

## DayView

### Properties
The `DayView` contains all the properties of a [Label](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/label).

| Property | Type | Description |
| ---------| -----| ----------- |
| <h4>DateTime</h4> | `DateTime`| The date the view represents. |
| <h4>Command</h4> | `ICommand`| The command to execute when pressed. |
| <h4>CommandParameter</h4> | `object`| The command parameter of the command used when pressed. |
| <h4>IsCurrentMonth</h4> | `bool`| The value used to determine if the CalendarDayView can be in the DayState.CurrentMonth or `DayState.OtherMonth` [DayState](#DayState). |
| <h4>IsToday</h4> | `bool`| The value used to determine if the CalendarDayView can be in the `DayState.Today` [DayState](#DayState). |
| <h4>IsSelected</h4> | `bool`| The value used to determine if the CalendarDayView can be in the `DayState.Selected` [DayState](#DayState). |
| <h4>IsInvalid</h4> | `bool`| The value used to determine if the CalendarDayView can be in the `DayState.Invalid` [DayState](#DayState). |  
| <h4>DayState</h4> | `DayState `| The exclusive state the CalendarDayView is in. |
| <h4>AutoSetStyleBasedOnDayState</h4> | `bool`| When set to `true` (which is its default value), the DayView will update its active style based on any properties that may change the [`DayState`](#DayState). For example `DateTime` or `IsCurrentMonth` |
| <h4>IsDayStateCurrentMonth</h4> | `bool`| Indicates if the CalendarDayView's [`DayState`](#DayState) is `DayState.CurrentMonth`. |
| <h4>IsDayStateOtherMonth</h4> | `bool`| Indicates if the CalendarDayView's [`DayState`](#DayState) is `DayState.OtherMonth`. |
| <h4>IsDayStateToday</h4> | `bool`| Indicates if the CalendarDayView's [`DayState`](#DayState) is `DayState.Today`. |
| <h4>IsDayStateSelected</h4> | `bool`| Indicates if the CalendarDayView's [`DayState`](#DayState) is `DayState.Selected`. |
| <h4>IsDayStateInvalid</h4> | `bool`| Indicates if the CalendarDayView's [`DayState`](#DayState) is `DayState.Invalid`. |
| <h4>CurrentMonthStyle</h4> | `Style`| The style to apply to the control when it is in the `DayState.CurrentMonth` [`DayState`](#DayState). The default value for this can be accessed in the `XCalendar.[Forms/Maui].Styles.DefaultStyles` class which can also be referenced in XAML using the `{x:Static}` markup extension. |
| <h4>OtherMonthStyle</h4> | `Style`| The style to apply to the control when it is in the `DayState.OtherMonth` [`DayState`](#DayState). The default value for this can be accessed in the `XCalendar.[Forms/Maui].Styles.DefaultStyles` class which can also be referenced in XAML using the `{x:Static}` markup extension. |
| <h4>TodayStyle</h4> | `Style`| The style to apply to the control when it is in the `DayState.Today` [`DayState`](#DayState). The default value for this can be accessed in the `XCalendar.[Forms/Maui].Styles.DefaultStyles` class which can also be referenced in XAML using the `{x:Static}` markup extension. |
| <h4>SelectedStyle</h4> | `Style`| The style to apply to the control when it is in the `DayState.Selected` [`DayState`](#DayState). The default value for this can be accessed in the `XCalendar.[Forms/Maui].Styles.DefaultStyles` class which can also be referenced in XAML using the `{x:Static}` markup extension. 
| <h4>InvalidStyle</h4> | `Style`| The style to apply to the control when it is in the `DayState.Invalid` [`DayState`](#DayState). The default value for this can be accessed in the `XCalendar.[Forms/Maui].Styles.DefaultStyles` class which can also be referenced in XAML using the `{x:Static}` markup extension. |
| <h4>Events</h4> | `IEnumerable<IEvent>`| The events to be shown. The default look is an indicator, the default indicator look only works with events that have a `Color` property such as the `ColoredEvent` classes in `XCalendar.Forms.Models` and `XCalendar.Maui.Models`. |
| <h4>EventsTemplate</h4> | `ControlTemplate`| The template used to display the events of the `Events` property. |
| <h4>EventTemplate</h4> | `DataTemplate`| The template used to display an event. |
| <h4>EventWidthRequest</h4> | `double`| The `WidthRequest` of a displayed event. |
| <h4>EventHeightRequest</h4> | `double`| The `HeightRequest` of a displayed event. |
| <h4>EventsSpacing</h4> | `double`| The spacing of displayed events. |
| <h4>EventsOrientation</h4> | `StackOrientation`| The orientation of the events. This can either be vertical or horizontal. |
| <h4>AutoEventsViewVisibility</h4> | `bool`| When this is `true`, the view for events is only shown if there is at least one event. If there are no events, the view is collapsed.<br/>When this is `false`, the view for events is always shown. This is useful if you're using templates and want to use custom logic that depends on the events view always being shown. |
  
### DayStates
There are 5 DayStates a CalendarDayView can be in:
* `CurrentMonth`
* `OtherMonth`
* `Today`
* `Selected`
* `Invalid`
<img src="https://user-images.githubusercontent.com/73718829/172160136-866ab333-636d-49e8-9630-963f5e950a09.png" width="45%">

Using the above screenshot as an example:
* The dates from 30th May - 2nd June are `Invalid`,
* 6th June is `Today`
* 15th June, 17th June, 18th June are `Selected`
* 1st July - 10th July are `OtherMonth`
* The rest are `CurrentMonth`.

## Extensions

### DateTimeExtensions (Unfinished)
  
Very useful [`DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netstandard-2.0) extension methods for acquiring collections of dates related to a Calendar.  
  
### DayOfWeekExtensions
  
[`DayOfWeek`](https://docs.microsoft.com/en-us/dotnet/api/system.dayofweek?view=netstandard-2.0) extension methods for getting different orders of the days of the week.

| Method Name | Return Type | Description |
| ----------- | ----------- | ----------- |
| GetWeekAsFirst | `List<DayOfWeek>` | Gets the days of the week using the specified `DayOfWeek` as the first day of the week. |
| GetWeekAsLast | `List<DayOfWeek>` | Gets the days of the week using the specified `DayOfWeek` as the last day of the week. |

### StringsExtensions
  
[`string`](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netstandard-2.0) extension methods making it easier to display calendar content.

| Method Name | Return Type | Description |
| ----------- | ----------- | ----------- |
| TruncateStringToMaxLength | `string` | Truncates the `string` to the specified number of characters. |
| ToTitleCase | `string` | Converts the `string` to title case using the specified `CultureInfo`.  |

## Converters

### StringCharLimitConverter  
  
Truncates the end of the binded string until its length is equal to the `int` specified in the `ConverterParameter`. Useful for displaying days of the week.

Cannot convert back.

In this example (Xamarin Forms):
```xaml
<ContentPage 
    xmlns="http://xamarin.com/schemas/2014/forms" 
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
    x:Class="XCalendarSample.Views.MainPage"
    xmlns:xcConverters="clr-namespace:XCalendar.Converters;assembly=XCalendar">

    <ContentPage.Resources>
        <xcConverters:StringCharLimitConverter x:Key="StringCharLimitConverter"/>
    </ContentPage.Resources>

    <Label Text="{Binding MyString, Converter={StaticResource StringCharLimitConverter}, ConverterParameter=3}"/>

</ContentPage>
``` 
* "Monday" would give "Mon"
* "Tuesday" would give "Tue"
* "Wednesday" would give "Wed"
* "Thu" would give "Thu"
* "Fr" would give "Fr"
  
### IsNullOrEmptyConverter
  
Determines if the binded value is null or empty.

Returns true if the binded value is null or empty, otherwise, false.

Cannot convert back.

### LocalizeDayOfWeekAndCharLimitConverter

Localises a `DayOfWeek` and truncates the result to the specified length.
