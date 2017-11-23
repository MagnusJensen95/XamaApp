using Android.App;
using Android.Widget;
using Android.OS;
using RestSharp;
using System;
using Newtonsoft;
using RESTXama.Models;
using Newtonsoft.Json;

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
            
            var request = new RestRequest("api/Users", Method.POST);
            Users jensen = new Users(3, "nusnus", "nusnus", "nusnus", "nusnus", DateTime.Today);
            
            //request.AddObject(jensen);
            var toAdd = JsonConvert.SerializeObject(jensen);
            

            request.AddParameter("application/json; charset=utf-8", toAdd, ParameterType.RequestBody);

          




            IRestResponse response = client.Execute(request);
            var content = response.Content;
            string debug = ("code: " + response.StatusCode);
            
            debugView.Text = debug;
            /*
            Users[] user = JsonConvert.DeserializeObject<Users[]>(content); 
            Console.WriteLine(user[0].Name);
            */
        }
    }
}

