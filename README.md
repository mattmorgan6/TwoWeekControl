# TwoWeekControl / ModernXamarinCalendar

A Nuget Package for Xamarin Forms. Interactive Xamarin Forms Calendar
[https://www.nuget.org/packages/ModernXamarinCalendar/](https://www.nuget.org/packages/ModernXamarinCalendar/)

![Modern Xamarin Calendar Control](https://github.com/mattmorgan6/TwoWeekControl/blob/master/Images/ModernControlSnip.JPG)

## Documentation

### Set Up

#### Step 1

Install the Nuget Package using Nuget Package Manager or in the Package Manager
Console run command:

``` powershell
Install-Package ModernXamarinCalendar -Version 1.0.4
```

#### Step 2

In the XAML content page where you would like the Calendar to go (such as
`MainPage.xaml`), write within the Content Page Tag

``` xml
xmlns:control="clr-namespace:ModernXamarinCalendar;assembly=ModernXamarinCalendar"
```

#### Step 3

Within your layout in the same XAML Page, place

``` xml
<control:WeekControl x:Name="CalendarWeekControl"
                     HorizontalOptions="CenterAndExpand"
                     BackgroundColor="SteelBlue" />
```

#### Step 4

In the C# code for your content page (such as `MainPage.xaml.cs`)

``` csharp
public void SelectedDateChanged(object sender, EventArgs e)
{
    var calendar = sender as WeekControl;

    // Insert code here that you want to use the date selected for...

    // control.SelectedDate returns a DateTime for the selected day.

    Debug.WriteLine(calendar.SelectedDate.ToString());
}
```

#### Step 5

In the same C# file, write within the constructor

``` csharp
CalendarWeekControl.SelectedDateChanged += SelectedDateChanged;
```
 
#### Step 6

Download Images from
> [GitHub - Images - Download this folder for icons for the nuget package](https://github.com/mattmorgan6/ModernXamarinCalendar/tree/master/Images%20-Download%20this%20folder%20for%20icons%20for%20nuget%20package)

and install them in your project

## Options

### Show labels for the days of the week (**SUN MON TUE WED THU FRI SAT**)

In the XAML page, set this property for the `WeekControl`:

``` xml
ShowDayName="True"
```

or in the C# code:

``` csharp
CalendarWeekControl.ShowDayName = true;
```

(The default value for `ShowDayName` is false, so not specifying it means the
days will not show up).

### Change the color of the calendar and its text
  In the XAML page, set this property for the WeekControl:
```       
   ForegroundColor="White"
```

(The default value for `ForegroundColor` is Black).
