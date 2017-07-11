﻿//METHOD 1
using System;
using System.Collections.Generic;
using ASampleApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace ASampleApp
{
	public class DogListMVVMViewModel : BaseViewModel
	{

		ObservableCollection<Dog> _observableCollectionOfDogs;

		public ICommand DeleteDogFromListCommand { get; set; }

		public DogListMVVMViewModel ()
		{

			//			https://stackoverflow.com/questions/5561156/convert-listt-to-observablecollectiont-in-wp7
			var list = new List<Dog> { };
			list = App.DogRep.GetAllDogs ();

			_observableCollectionOfDogs = new ObservableCollection<Dog> ();
			foreach (var item in list)
				_observableCollectionOfDogs.Add (item);

			DeleteDogFromListCommand = new Command(DeleteDogFromListAction);

		}

		private void DeleteDogFromListAction(object obj)
		{
			Debug.WriteLine("DELETE DOG FROM LIST ACTION");

			var myItem = obj as Dog;
			_observableCollectionOfDogs.Remove(myItem);

		}

		public ObservableCollection<Dog> ObservableCollectionOfDogs {
			get { return _observableCollectionOfDogs; }
			set { SetProperty (ref _observableCollectionOfDogs, value); }
		}
	}
}



////METHOD 2 - using a IList - only works if you initalize with what you're looking for -- it doesn't update because IList is not observable
//using System;
//using System.Collections.Generic;
//using ASampleApp.Models;

//namespace ASampleApp
//{
//	public class DogListMVVMViewModel : BaseViewModel
//	{

//		IList<Dog> _listOfDogs;

//		public DogListMVVMViewModel()
//		{
//			//here do something where you initialize the IList to something.
//			_listOfDogs = App.DogRep.GetAllDogs ();

//		}

//		public IList<Dog> ListOfDogs
//		{
//			get { return _listOfDogs;}
//			set { SetProperty (ref _listOfDogs, value);}
//		}
//	}
//}

