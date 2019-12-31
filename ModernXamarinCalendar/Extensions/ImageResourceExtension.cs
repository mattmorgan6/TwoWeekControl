using System;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernXamarinCalendar.Extensions
{
	[ContentProperty(nameof(FileName))]
	public class ImageResourceExtension : IMarkupExtension
	{
		//* Public Properties
		public string FileName { get; set; }
		public string FolderName { get; set; }

		//* Static Methods
		public static ImageSource GetImageSource(string fileName, string folderName = null) =>
			ImageSource.FromResource(getFilePath(fileName, folderName),
				typeof(ImageResourceExtension).GetTypeInfo().Assembly);

		//* Interface Implementation
		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (FileName == null)
				return null;

			// Concantenate FileName & FolderName
			string filePath = getFilePath(FileName, FolderName);

			var imageSource = ImageSource.FromResource(filePath,
				typeof(ImageResourceExtension).GetTypeInfo().Assembly);

			return imageSource;
		}

		//* Private Methods
		private static string getFilePath(string fileName, string folderName) =>
			string.Format("{0}.Assets.{1}{2}", nameof(ModernXamarinCalendar),
				string.IsNullOrWhiteSpace(folderName) ? "" : $"{folderName}.",
				fileName);
	}
}