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

            // Switch from folder style architecture to Embedded Resource ID
            string source = string.Format("{0}.{1}", nameof(ModernXamarinCalendar),
                Source.Replace("/", ".").Replace("\\", "."));

            var imageSource = ImageSource.FromResource(source, 
                typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}