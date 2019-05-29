# TwoWeekControl   /   ModernXamarinCalendar
A Nuget Package for Xamarin Forms. Interactive Xamarin Forms Calendar
<a href="https://www.nuget.org/packages/ModernXamarinCalendar/">https://www.nuget.org/packages/ModernXamarinCalendar/</a>

<img src="https://github.com/mattmorgan6/TwoWeekControl/blob/master/Images/ModernControlSnip.JPG">

## Documentation

### Set Up
#### Step 1
  Install the Nuget Package using Nuget Package Manager or in the Package Manager Console run command:
>  
    Install-Package ModernXamarinCalendar -Version 1.0.0 


#### Step 2
  In the XAML content page where you would like the Calendar to go (such as MainPage.xaml), write within the Content Page Tag
>   
    xmlns:control="clr-namespace:ModernXamarinCalendar;assembly=ModernXamarinCalendar"


#### Step 3
  Within your layout in the same XAML Page, place
>         
          <control:WeekControl x:Name="CalendarWeekControl"
                               HorizontalOptions="CenterAndExpand"
                               BackgroundColor="SteelBlue"/>
                             
#### Step 4
  In the c# code for your content page (such as MainPage.xaml.cs)
>           
        public void DateSelectedChanged(object sender, EventArgs e)
        {
            WeekControl calendar = sender as WeekControl;

            // insert code here that you want to use the date selected for...
            
            // control.DateSelected returns a DateTime for the selected day.

            Debug.WriteLine(calendar.DateSelected.ToString());
        }
        
        
#### Step 5
  In the same c# file, write within the constructor
 ```   
 CalendarWeekControl.DataSelectedChanged += DateSelectedChanged;   
 ```
 
#### Step 6
Download Images from 
>[GitHub - Images - Download this folder for icons for the nuget package](https://github.com/mattmorgan6/ModernXamarinCalendar/tree/master/Images%20-Download%20this%20folder%20for%20icons%20for%20nuget%20package)

and install them in your project
 
