using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestSharp;
using DTUProjectApp.Toolbox;
using RESTXama.Models;

namespace DTUProjectApp
{
    [Activity(Label = "BarContent")]
    public class BarContent : Activity
    {

        private ListView listView;

        private Prices[] userPrices;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.BarContent);

            listView = FindViewById<ListView>(Resource.Id.mainBarContentListview);

          
            userPrices  = JsonConvert
                .DeserializeObject<Prices[]>(Intent.GetStringExtra("priceString"));

            MainBarContentAdapter adapter = new MainBarContentAdapter(this, userPrices.ToList<Prices>());

            listView.Adapter = adapter;
            // Create your application here
        }
    }
}