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
using RestSharp;
using DTUProjectApp.Toolbox;
using RESTXama.Models;
using System.Threading.Tasks;

namespace DTUProjectApp
{
    [Activity(Label = "EditProfileContent")]
    public class EditProfileContent : Activity
    {

        ListView optionsList;
        public int CurrentUserSignedInId;
      public Prices[] UserPrices { get; set; }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.EditLayout);

            this.GetPrices();
            optionsList = FindViewById<ListView>(Resource.Id.optionsList);

            List<string> options = new List<string> { "Add New Product", "Delete Product", "Delete Profile" };

            optionsList.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, options);

            optionsList.ItemClick += OptionsList_ItemClick;

            CurrentUserSignedInId = Int32.Parse(Intent.GetStringExtra("userId"));


        }

        public async void GetPrices()
        {
            var client = new RestClient("http://10.0.2.2:60408");
            RestReader reader = new RestReader();

            UserPrices = await  reader.GetPrices(client, CurrentUserSignedInId);
        }

        private void OptionsList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            

            switch (e.Position)
            {
                case 0:
                    {
                        //Add product


                        AddProductFrag addFrag = new AddProductFrag(CurrentUserSignedInId);

                        addFrag.ProductHandler += AddFrag_ProductHandler;
                        FragmentTransaction transaction = FragmentManager.BeginTransaction();
                        addFrag.Show(transaction, "CreateProductFrag");

                        break;
                    }
                case 1:
                    {

                        //Delete product 
                        Toast.MakeText(this.ApplicationContext, "CLicked; !" + 2, ToastLength.Short).Show();
                        break;
                    }
                case 2:
                    {

                        //Delete profile
                        break;
                    }


            }
        }

        private async void AddFrag_ProductHandler(object sender, OnCreateProductEvent e)
        {
            var client = new RestClient("http://10.0.2.2:60408");
            RestInserter inserter = new RestInserter();
            

            

            Prices price = new Prices { Id = CurrentUserSignedInId, ProductId = UserPrices.Length, Name = e.Name, Price = e.Price, Picture = null };
            await inserter.InsertPrice(price, client, CurrentUserSignedInId);


        }
    }
}