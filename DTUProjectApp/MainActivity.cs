
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
        EditText usernameEdit, passwordEdit;
        Users[] users;

        Button signIn, createProfile, signInGuest;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.Main);

            signIn = FindViewById<Button>(Resource.Id.signInButton);
            createProfile = FindViewById<Button>(Resource.Id.createProfileButton);
            signInGuest = FindViewById<Button>(Resource.Id.signInAsGuestButton);

            RestReader reader = new RestReader();
            RestClient client = new RestClient("10.0.2.2:60408");

            users = reader.GetUsers(client);


            signIn.Click += SignIn_Click;

        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            //get the user to the main content page


        }
    }
}

