# XCalendar

A plugin for Xamarin Forms and .NET MAUI providing a completely customisable calendar control with complex functionality.

Features include:
* Templates for NavigationView, MonthView, DayView, DayNamesView, and DayNameView with exposed commands.
* Ability to set the number of rows shown or have it be automatic.
* Ability to specify your own custom order of days of week at any length, with support for duplicates and non-chronological orders.
* Ability to change the start of the week to any day of the week.
* Ability to select single, multiple or a range of dates.
* Ability to specify a range of allowed dates, and whether to restrict navigation to them or not.
* And more! View guides and a full list of available properties on the [Wiki](https://github.com/ME-MarvinE/XCalendar/wiki).


<img src="https://user-images.githubusercontent.com/73718829/150847171-290910bf-1751-409d-a622-39d3e14687b4.jpg" width="45%"> <img src="https://user-images.githubusercontent.com/73718829/150847175-e03ca411-3d94-48d0-a53f-6fd8562ceac1.jpg" width="45%"> <img src="https://user-images.githubusercontent.com/73718829/150847218-c1cc3faf-1860-4914-b84b-207c1145cc87.jpg" width="45%"> <img src="https://user-images.githubusercontent.com/73718829/150847183-11043f0b-9de5-434d-8e8b-f93b8c07c003.jpg" width="45%"> <img src="https://user-images.githubusercontent.com/73718829/150847188-809994a2-dc3e-4789-965b-b8237875ba3b.jpg" width="45%"> <img src="https://user-images.githubusercontent.com/73718829/150847213-fa0e9379-7ca1-475e-aeb5-accef9b7b6e8.jpg" width="45%">

## Sample App
Take a look at the sample app, it has a page where you can modify every single non-cosmetic property. Perfect for a quick look, tests and experiments!

<img src="https://user-images.githubusercontent.com/73718829/150314241-53fe89fa-6275-4ae8-aec3-2178cba84b14.jpg" width="45%"> <img src="https://user-images.githubusercontent.com/73718829/150314247-380cad1d-3a33-48f8-b38d-b2e3e913923a.jpg" width="45%">

## Usage

### Xamarin Forms

#### Install the NuGet package
* https://www.nuget.org/packages/XCalendar.Forms/

#### Add the following xmlns to your page or view
```xaml
xmlns:xcViews="clr-namespace:XCalendar.Forms.Views;assembly=XCalendar.Forms"
```

#### Now you can start using the CalendarView
```xaml
<ContentPage 
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    x:Class="XCalendarFormsSample.Views.PlaygroundPage"
    xmlns:xcViews="clr-namespace:XCalendar.Forms.Views;assembly=XCalendar.Forms">

    <xcViews:CalendarView/>

</ContentPage>
```

### .NET MAUI

#### Install the NuGet package
* https://www.nuget.org/packages/XCalendar.Maui/

#### Add the following xmlns to your page or view
```xaml
xmlns:xcViews="clr-namespace:XCalendar.Maui.Views;assembly=XCalendar.Maui"
```

#### Now you can start using the CalendarView
```xaml
<ContentPage 
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    x:Class="XCalendarMauiSample.Views.PlaygroundPage"
    xmlns:xcViews="clr-namespace:XCalendar.Maui.Views;assembly=XCalendar.Maui">

    <xcViews:CalendarView/>

</ContentPage>
```

## Wiki
View guides and a full list of available properties on the [Wiki](https://github.com/ME-MarvinE/XCalendar/wiki).
