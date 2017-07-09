using System;
using System.Collections.Generic;
using System.Diagnostics;
using ASampleApp.Models;
using Xamarin.Forms;
namespace ASampleApp
{
    public class DogListPage : BaseContentPage<DogListViewModel> //: BaseContentPage<DogListViewModel>
    {

        ListView _dogListView;

        public DogListPage()
        {
            _dogListView = new ListView();

            var myTemplate = new DataTemplate(typeof(TextCell));

            _dogListView.ItemTemplate = myTemplate;

            var _myListOfDogs = App.DogRep.GetAllDogs();
            _dogListView.ItemsSource = _myListOfDogs;




            myTemplate.SetBinding(TextCell.TextProperty, "Name");
            myTemplate.SetBinding(TextCell.DetailProperty, "FurColor");

            Content = new StackLayout()
            {
                Children = {
                    _dogListView
                }

            };


        }
    }

	public class DogViewCell : ViewCell
	{
        public DogViewCell()
        {


            var moreAction = new MenuItem { Text = "More" };
            moreAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            moreAction.Clicked += async (sender, e) =>
            {
                var mi = ((MenuItem)sender);
                Debug.WriteLine("More Context Action clicked: " + mi.CommandParameter);
            };

            var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
            deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            deleteAction.Clicked += async (sender, e) =>
            {
                var mi = ((MenuItem)sender);
                Debug.WriteLine("Delete Context Action clicked: " + mi.CommandParameter);
            };
            // add to the ViewCell's ContextActions property
            ContextActions.Add(moreAction);
            ContextActions.Add(deleteAction);
        }
    }






}
