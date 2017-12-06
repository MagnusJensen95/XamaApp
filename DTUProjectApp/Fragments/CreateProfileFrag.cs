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
using DTUProjectApp.Model;

namespace DTUProjectApp
{

    class OnCreateProfileEvent : EventArgs
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public OnCreateProfileEvent() : base()
        {
           
        }

    }
        class CreateProfileFrag : DialogFragment
        {

            EditText username, password, email;
            Button createButton;
            public BasicUser[] Users { get; set; }

            public event EventHandler<OnCreateProfileEvent> CreateEventHandler;


            public CreateProfileFrag(BasicUser[] users)
            {
                Users = users;
            }


            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                View view = inflater.Inflate(Resource.Layout.NewProfileLayout, container);
            createButton = view.FindViewById<Button>(Resource.Id.createButtonConfirm);

            username = view.FindViewById<EditText>(Resource.Id.usernameEditCreate);
            password = view.FindViewById<EditText>(Resource.Id.passwordEditCreate);
            email = view.FindViewById<EditText>(Resource.Id.emaileCreateEdit);

            createButton.Click += CreateButton_Click;

                return view;
            }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (CheckUserValid())
            {
                if (username.Text == "" || password.Text == "" || email.Text == "")
                {
                    Toast.MakeText(this.Context, "You must fill out every field!", ToastLength.Short).Show();
                    return;
                }

                CreateEventHandler.Invoke(sender, new OnCreateProfileEvent
                {
                    Username = username.Text,
                    Password = password.Text,
                    Email = email.Text
                });

                Dismiss();
            }
            Toast.MakeText(this.Context, "Invalid Username or Password", ToastLength.Short).Show();
        }

        public bool CheckUserValid()
            {
                BasicUser tempUser = new BasicUser { Username = username.Text, Password = password.Text, Email = email.Text };
                foreach (BasicUser user in Users)
                {
                    if (tempUser.Username == user.Username || tempUser.Email == user.Email)
                    {
                        return false;
                    }

                }
                return true;
            }
        }
    }

