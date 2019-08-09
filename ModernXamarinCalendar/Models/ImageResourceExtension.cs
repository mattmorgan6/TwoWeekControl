using System;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernXamarinCalendar.Models
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        //* Public Properties
        public string Source { get; set; }

        //* Interface Implementation
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source, 
                typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}