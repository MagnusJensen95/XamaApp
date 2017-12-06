    
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using RestSharp;
using System;
using Newtonsoft;
using RESTXama.Models;
using Newtonsoft.Json;
using DTUProjectApp.Toolbox;
using System.Threading.Tasks;
using DTUProjectApp.Model;
using System.Linq;



namespace DTUProjectApp
{
    [Activity(Label = "DTUProjectApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        
       
        EditText usernameEdit, passwordEdit;
        Users[] users;
        RestReader reader;
        RestInserter inserter;
        ProgressBar bar;

        Button signIn, createProfile, signInGuest;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.Main);

            usernameEdit = FindViewById<EditText>(Resource.Id.userNameTextEdit);
            passwordEdit = FindViewById<EditText>(Resource.Id.passwordTextEdit);
            signIn = FindViewById<Button>(Resource.Id.signInButton);
            createProfile = FindViewById<Button>(Resource.Id.createProfileButton);
            signInGuest = FindViewById<Button>(Resource.Id.signInAsGuestButton);
            bar = FindViewById<ProgressBar>(Resource.Id.loadingBarMain);
            bar.Visibility = Android.Views.ViewStates.Invisible;

            reader = new RestReader();
            inserter = new RestInserter();

            signIn.Click += SignIn_Click;
            createProfile.Click += CreateProfileClick;
            signInGuest.Click += SignInGuest_Click;

        }

        private async void SignInGuest_Click(object sender, EventArgs e)
        {
            //Take the user to content window whithout toolbar access
            var nextUp = new Intent(this, typeof(MainContentActivity));
            nextUp.PutExtra("LegitUser", false);
            var client = new RestClient("http://10.0.2.2:60408");
            bar.Visibility = Android.Views.ViewStates.Visible;
            users = await reader.GetUsers(client);
            bar.Visibility = Android.Views.ViewStates.Invisible;
            string serializedUsers = JsonConvert.SerializeObject(users);
            nextUp.PutExtra("userString", serializedUsers);
            StartActivity(nextUp);

        }

        private async void CreateProfileClick(object sender, EventArgs e)
        {
            // open fragment for profile creation - should support eventhandling and navigation to main content page
            var client = new RestClient("http://10.0.2.2:60408");
            bar.Visibility = Android.Views.ViewStates.Visible;
            users = await reader.GetUsers(client);
            bar.Visibility = Android.Views.ViewStates.Invisible;

            BasicUser[] baseUsers =  new BasicUser[users.Length];
            var convertedUsers = (from tempUser in users select new { Username = tempUser.Username,
                Password = tempUser.Password, Email = tempUser.Email });

            int count = 0;
            foreach (var element in convertedUsers)
            {
                baseUsers[count] = new BasicUser {Username = element.Username,  Password = element.Password,  Email = element.Email };
                count++;
            }
            

         
            CreateProfileFrag frag = new CreateProfileFrag(baseUsers);
            frag.CreateEventHandler += Frag_createEventHandler;
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            frag.Show(transaction, "CreateProfileFrag");
            
        }

        private void Frag_createEventHandler(object sender, OnCreateProfileEvent e)
        {
            var client = new RestClient("http://10.0.2.2:60408");
            Users newUser = new Users(users[users.Length-1].Id + 1 , e.Username, e.Username, e.Password, e.Email, DateTime.Today);
            inserter.InsertUser(newUser, client);
            Toast.MakeText(this.ApplicationContext, "User created succesfully!", ToastLength.Short).Show();


        }

        private async void SignIn_Click(object sender, EventArgs e)
        {
            bar.Visibility = Android.Views.ViewStates.Visible;
            bool boolTest = await  IsUserLegit(usernameEdit.Text, passwordEdit.Text);
            bar.Visibility = Android.Views.ViewStates.Invisible;
            //get the user to the main content page with toolbar
            if (boolTest)
            {
                var nextUp = new Intent(this, typeof(MainContentActivity));
                nextUp.PutExtra("LegitUser", true);
                
                nextUp.PutExtra("Username", usernameEdit.Text);
                string serializedUsers = JsonConvert.SerializeObject(users);
                nextUp.PutExtra("userString", serializedUsers);

                StartActivity(nextUp);
            }

            else
            {
                Toast.MakeText(this.ApplicationContext, "Wrong Username or Password", ToastLength.Short).Show();
            }
            

        }

        public async Task<bool> IsUserLegit(string username, string password)
        {

            var client = new RestClient("http://10.0.2.2:60408");
            users = await reader.GetUsers(client);

            foreach (Users user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

