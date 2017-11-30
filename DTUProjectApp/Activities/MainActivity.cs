
using Android.App;
using Android.Widget;
using Android.OS;
using RestSharp;
using System;
using Newtonsoft;
using RESTXama.Models;
using Newtonsoft.Json;
using DTUProjectApp.Toolbox;
using System.Threading;


namespace DTUProjectApp
{
    [Activity(Label = "DTUProjectApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        
        TextView debugView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);

       
        }
    }
}

