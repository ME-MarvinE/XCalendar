# XCalendar

A plugin for Xamarin Forms providing a highly flexible calendar control with complex behaviour and complete customisability.
(Only Tested On Android)


<img src="https://user-images.githubusercontent.com/73718829/150314185-1e7b6f81-df01-4d94-abbd-3fc85496ad0b.jpg" alt="drawing" width="25%" height="25%"> <img src="https://user-images.githubusercontent.com/73718829/150314204-8ae9610d-73fc-418c-9df9-12b8739e0118.jpg" width="25%" height="25%"> <img src="https://user-images.githubusercontent.com/73718829/150316592-5c40b433-be94-4168-8601-971f9af56758.jpg" width="25%" height="25%"> <img src="https://user-images.githubusercontent.com/73718829/150314210-db0ecc73-4462-45ef-b5f1-be359382464c.jpg" width="25%" height="25%"> <img src="https://user-images.githubusercontent.com/73718829/150314220-175e918f-fe8d-4b77-938c-9ffed3065c31.jpg" width="25%" height="25%"> <img src="https://user-images.githubusercontent.com/73718829/150314225-98de87f7-dba8-43ec-925a-e64e72c0b899.jpg" width="25%" height="25%">

## Sample App
Take a look at the sample app, it has a page where you can modify every single non-cosmetic property. Perfect for a quick look, tests and experiments!

<img src="https://user-images.githubusercontent.com/73718829/150314241-53fe89fa-6275-4ae8-aec3-2178cba84b14.jpg" width="25%" height="25%">|<img src="https://user-images.githubusercontent.com/73718829/150314247-380cad1d-3a33-48f8-b38d-b2e3e913923a.jpg" width="25%" height="25%">

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
All properties are backed by a BindableProperty unless stated otherwise.

#### `NavigatedDate`
The date the calendar is currently navigated to.

#### `TodayDate`
The date the calendar will treat as 'Today'.

#### `StartOfWeek`
The day of the week that will be considered as the start of the week. Used for internal logic.

#### `StartOfWeekDayNamesOrder` *(ReadOnly BindableProperty)*
The order that the days of week are in based on the `StartOfWeek` property.

#### `CustomDayNamesOrder`
A custom list of days of the week to display when `UseCustomDayNamesOrder` is set to true.

#### `UseCustomDayNamesOrder`
Determines if the calendar should display the `CustomDayNamesOrder` or the `StartOfWeekDayNamesOrder`.

#### `DayNamesOrder` *(ReadOnly BindableProperty)*
The order that the days of the week are currently displayed in. This can either be the value of `StartOfWeekDayNamesOrder` or `CustomDayNamesOrder`. Purely Visual.

#### `Rows`
The number of rows to display. Each row represents one week.

#### `AutoRows`
Whether the calendar should automatically determine the minimum number of rows needed to display the month or not.

#### `AutoRowsIsConsistent`
Determines if the `AutoRows` property should display the same number of rows throughout each month in the year.

#### `NavigationTimeUnit`
The time unit the `NavigatedDate` will change by when navigating.
* `None` Do nothing when navigating.
* `Week` Add/subtract 7 days when navigating.
* `Month` Add/subtract 1 month when navigating.
* `Year` Add/subtract 1 year when navigating.
* `Page` Add/subtract by `Rows` * 7 - Each row represents one week and each week has 7 days.

#### `DayRangeMinimumDate`
The lower bound of the dates the calendar considers as 'In Range'. Inclusive.

#### `DayRangeMaximumDate`
The upper bound of the dates the calendar considers as 'In range'. Inclusive.

#### `NavigationLoopMode`
The behaviour of the calendar when navigating outside the allowed range.
* `DontLoop` Don't loop when navigating outside the allowed range.
* `LoopMinimum` Loop to the upper bound of the allowed range when navigating past the lower bound of the allowed range.
* `LoopMaximum` Loop to the lower bound of the allowed range when navigating past the upper bound of the allowed range.
* `LoopMiniumAndMaximum` Loop as defined in both `LoopMinimum` and `LoopMaximum`.

#### `ClampNavigatedDateToDayRange`
Whether to clamp the navigation to between `DayRangeMinimumDate` and `DayRangeMaximumDate` or not.

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

#### `Days` *(ReadOnly BindableProperty)*
The days displayed by the current page. Note that displayed days != displayed dates.
For example if `DayNamesOrder` is "Monday, Monday, Monday Tuesday" and the row is displaying the week of 10th January 2022 - 16th January 2022, there would be 4 days displayed but only 2 dates displayed: 10th January 2022 and 11th January 2022.

#### `NavigateCalendarCommand` *(ReadOnly Property)*
Takes a parameter of type `bool` indicating whether to navigate forwards (true) or backwards (false).

#### `ChangeDateSelectionCommand` *(ReadOnly Property)*
Takes a parameter of type `DateTime` indicating what date to select/unselect.

## Templates and Customisation Properties
All customisation properties are backed by a BindableProperty unless stated otherwise.
If you define a template, you may need to implement their associated properties too depending on if you plan to use them from the calendar or not.
You can access the properties of a control inside a DataTemplate by setting its ControlTemplate to a ContentPresenter, then using RelativeSource bindings. This is done in the sample.

#### `NavigationTemplate`
Control what the view displaying the navigation should be.
##### Associated Control Properties
* `NavigateCalendarCommand`
* `NavigatedDate`
##### Associated Customisation Properties
* `NavigationHeightRequest`
* `NavigationTextColor`
* `NavigationArrowColor`
* `NavigationArrowBackgroundColor`
* `NavigationArrowCornerRadius`

#### `DayNamesTemplate`
Control what the view displaying the `DayNamesOrder` should be.
##### Associated Control Properties
* `DayNamesOrder`
##### Associated Customisation Properties
* `DayNamesHeightRequest`
* `DayNameTemplate`
* `DayNameVerticalSpacing`
* `DayNameHorizontalSpacing`

#### `DayNameTemplate`
Control how an individual `DayOfWeek` should be displayed.
##### Associated Control Properties
##### Associated Customisation Properties
* `DayNameTextColor`

#### `MonthViewTemplate`
Control what the view displaying the `Days` should be.
##### Associated Control Properties
`Days`
##### Associated Customisation Properties
* `MonthViewHeightRequest`
* `DayTemplate`

#### `DayTemplate`
Control how an individual `CalendarDay` should be displayed.
##### Associated Control Properties
* `ChangeDateSelectionCommand`
##### Associated Customisation Properties
* `DateTime` (From the CalendarDay in the BindingContext of the DataTemplate)
* `DayHeightRequest`
* `DayCurrentMonthTextColor`
* `DayTodayTextColor`
* `DayOtherMonthTextColor`
* `DayOutOfRangeTextColor`
* `DaySelectedTextColor`
