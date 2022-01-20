# XCalendar

A plugin for Xamarin Forms providing a completely customisable calendar control with complex functionality.
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

## Wiki
View a full list of available properties on the <a href="https://github.com/ME-MarvinE/XCalendar/wiki">Wiki</a>
