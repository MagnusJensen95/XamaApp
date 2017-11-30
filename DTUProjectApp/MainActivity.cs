
using Android.App;
using Android.Widget;
using Android.OS;
using RestSharp;
using System;
using Newtonsoft;
using RESTXama.Models;
using Newtonsoft.Json;
using DTUProjectApp.Toolbox;


namespace DTUProjectApp
{
    [Activity(Label = "DTUProjectApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        
        TextView debugView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            debugView = FindViewById<TextView>(Resource.Id.debugText);

            var client = new RestClient("http://10.0.2.2:60408");
            
           
            Users jensen = new Users(1, "jensen", "jensen", "jensen", "jensen", DateTime.Today);

            RestUpdater updater = new RestUpdater();
            
            string debug = updater.UpdateUser(1, jensen, client);

            debugView.Text = debug;
            /*
            Users[] user = JsonConvert.DeserializeObject<Users[]>(content); 
            Console.WriteLine(user[0].Name);
            */
        }
    }
}

