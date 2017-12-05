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
    [Activity(Label = "EditProfileContent")]
    public class EditProfileContent : Activity
    {

        ListView optionsList;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditLayout);


        }
    }
}