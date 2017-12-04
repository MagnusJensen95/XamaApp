using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DTUProjectApp
{
    [Activity(Label = "MainContentActivity")]
    public class MainContentActivity : Activity
    {
        

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.MainContent);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            bool amISignedInQuestionMark = Intent.GetBooleanExtra("LegitUser", false);

            if (amISignedInQuestionMark)
            {
                //Only apply toolbar if the user is signed in 
                string userSignedIn = Intent.GetStringExtra("Username");

                SetActionBar(toolbar);

                ActionBar.Title = userSignedIn;
            }

           
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {

            MenuInflater.Inflate(Resource.Menu.toolbaritems, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            switch (item.ItemId)
            {


                case Resource.Id.menu_edit:
                    {
                        break;
                    }


                case Resource.Id.menu_LogOut:
                    {
                        StartActivity(typeof(MainActivity));
                        break;
                    }
            }
            return base.OnOptionsItemSelected(item);
        }


    }
}