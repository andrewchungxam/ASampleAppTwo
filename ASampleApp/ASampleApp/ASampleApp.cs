using System;
using ASampleApp.Data;
using Xamarin.Forms;

namespace ASampleApp
{
	public class App : Application
	{

        public static DogRepository DogRep { get; private set; }

		public App ()
		{

            string dbPath = FileAccessHelper.GetLocalFilePath("dog3.db3");
            DogRep = new DogRepository(dbPath);

			var applicationStartPage = new FirstPage ();

			//// The root page of your application
			//var content = new ContentPage {
			//	Title = "ASampleApp",
			//	Content = new StackLayout {
			//		VerticalOptions = LayoutOptions.Center,
			//		Children = {
			//			new Label {
			//				HorizontalTextAlignment = TextAlignment.Center,
			//				Text = "Welcome to Xamarin Forms!"
			//			}
			//		}
			//	}
			//};

			MainPage = new NavigationPage (applicationStartPage);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
