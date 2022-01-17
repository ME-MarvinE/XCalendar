# XCalendar

A plugin for Xamarin Forms providing a highly flexible calendar control with complex behaviour.

## Sample
Take a look at the sample app, it has a page where you can modify every single non-cosmetic property. Perfect for a quick look, tests and experiments!

## Warning
BindableProperty.CoerceValue is broken in the recent versions of Xamarin Forms. This control may not display changes to some properties until navigating after the change.

## Usage

### Install the NuGet package
  * https://www.nuget.org/packages/Plugin.XCalendar/
  
### Add the following xmlns to your page
```xaml
xmlns:xc="clr-namespace:XCalendar;assembly=XCalendar"
```
### Now you can start using the CalendarView
```xaml
<ContentPage 
    xmlns="http://xamarin.com/schemas/2014/forms" 
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
    x:Class="XCalendarSample.Views.MainPage"
    xmlns:xc="clr-namespace:XCalendar;assembly=XCalendar">

    <xc:CalendarView/>

</ContentPage>
```

## Control Properties
Every single control property can be modified within the sample app. If a property doesn't seem to make sense, try experimenting with it!
All control properties (Except `Days`) are backed by a BindableProperty.

#### `NavigatedDate`
The date the calendar is currently navigated to.

#### `TodayDate`
The date the calendar will treat as 'Today'.

#### `StartOfWeek`
The day of the week that will be considered as the start of the week. Used for internal logic.

#### `DayNamesOrder`
The configuration in which the row dates should be displayed in. There must be at least one `DayOfWeek` in the list. Purely visual.

#### `DayNamesOrderUsesStartOfWeek`
Determines if the calendar should shift the elements in `DayNamesOrder` to the left until the first element is equal to the `StartOfWeek`.

#### `Rows`
The number of rows to display. Each row represents one week.

#### `AutoRows`
Whether the calendar should automatically determine the minimum number of rows needed to display the month or not.

#### `AutoRowsIsConsistent`
Determines if the `AutoRows` property should display the same number of rows throughout each month in the year.

#### `NavigationMode`
The time unit the `NavigatedDate` will change by when navigating.
* `ByWeek` Add/subtract 7 days when navigating.
* `ByMonth` Add/subtract 1 month when navigating.
* `ByYear` Add/subtract 1 year when navigating.
* `ByPage` Add/subtract by `Rows` * 7. Each row represents one week and each week has 7 days.

#### `DayRangeMinimumDate`
The lower bound of the dates the calendar considers as 'In Range'. Inclusive.

#### `DayRangeMaximumDate`
The upper bound of the dates the calendar considers as 'In range'. Inclusive.

#### `NavigationLimitMode`
The behaviour of the calendar when navigating to an unrepresenable `DateTime` or outside the bounds of `DayRangeMinimumDate` and `DayRangeMaximumDate`.
(Yes I'm aware of the length of some of these)
* `DontLoop` Don't loop when navigating to an unrepresentable `DateTime`
* `LoopMinimum` Loop to DateTime.MaxValue when trying to navigate past DateTime.MinValue.
* `LoopMaximum` Loop to DateTime.MinValue when trying to navigate past DateTime.MaxValue.
* `LoopMiniumAndMaximum` Loop to DateTime.MaxValue when trying to navigate past DateTime.MinValue, loop to DateTime.MinValue when trying to navigate past DateTime.MaxValue.
* `ClampToDayRangeAndDontLoop` Don't loop when navigating past `DayRangeMinimumDate` or `DayRangeMaximumDate`.
* `ClampToDayRangeAndLoopMinimum` Loop to `DayRangeMaximumDate` when trying to navigate past `DayRangeMinimumDate`.
* `ClampToDayRangeAndLoopMaximum` Loop to `DayRangeMinimumDate` when trying to navigate past `DayRangeMaximumDate`.
* `ClampToDayRangeAndLoopMinimumAndMaximum` Loop to `DayRangeMaximumDate` when trying to navigate past `DayRangeMinimumDate`, loop to `DayRangeMinimumDate` when trying to navigate past `DayRangeMaximumDate`.

#### `SelectionMode`
How the calendar implements date selection.
* `None` No dates can be selected.
* `Single` One date can be selected.
* `Multiple` Multiple dates can be selected.

#### `SelectedDate`
The date that has been selected when `SelectionMode` is set to `Single`. This is not cleared when `SelectionMode` changes to something else.
#### `SelectedDates`
The dates that have been selected when `SelectionMode` is set to `Multiple`. This is not cleared when `SelectionMode` changes to something else.

#### `PageStartMode`
How the calendar will use the `NavigatedDate` to generate the first date in the page (and therefore the subsequent sequence of dates).
* `FirstDayOfWeek` Use the first date in `NavigatedDate`'s Week.
* `FirstDayOfMonth` Use the first date in the first week of `NavigatedDate`'s Month.
* `FirstDayOfYear` Use the first date in the first week of `NavigatedDate`'s Year.

#### `Days`
The days displayed by the current page. Note that displayed days != displayed dates.
For example if `DayNamesOrder` is "Monday, Monday, Monday Tuesday" and the row is displaying the week of 10th January 2022 - 16th January 2022, there would be 4 days displayed but only 2 dates displayed: 10th January 2022 and 11th January 2022.

## Customisation Properties
All customisation properties are backed by a BindableProperty.

#### `NavigationTemplate`
Control what the view displaying the navigation should look like.
#### `DayNamesTemplate`
Control what the view displaying the `DayNamesOrder` should look like.
#### `DayNameTemplate`
Control how an individual `DayOfWeek` in the `DayNamesOrder` should be displayed.
#### `MonthViewTemplate`
Control what the view displaying the `Days` should look like.
#### `DayTemplate`
Control how an individual `CalendarDay` in `Days` should be displayed.

#### And More
