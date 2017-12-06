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
        private Prices[] userPrices;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.EditLayout);


            optionsList = FindViewById<ListView>(Resource.Id.optionsList);

            List<string> options = new List<string> { "Add New Product", "Delete Product", "Delete Profile" };

            optionsList.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, options);

            optionsList.ItemClick += OptionsList_ItemClick;

            CurrentUserSignedInId = Intent.GetIntExtra("userId", 0);
            Toast.MakeText(this, "User is there" + CurrentUserSignedInId, ToastLength.Short).Show();



        }

     
        public async void OptionsList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {


            switch (e.Position)
            {
                case 0:
                    {
                        //Add product
                        var client = new RestClient("http://10.0.2.2:60408");
                        RestReader reader = new RestReader();
                        userPrices = await reader.GetPrices(client);
                        AddProductFrag addFrag = new AddProductFrag(CurrentUserSignedInId);
                        
                        addFrag.ProductHandler += AddFrag_ProductHandler;
                        FragmentTransaction transaction = FragmentManager.BeginTransaction();
                        addFrag.Show(transaction, "CreateProductFrag");

                        break;
                    }
                case 1:
                    {

                        //Delete product 
                        var client = new RestClient("http://10.0.2.2:60408");
                        RestReader reader = new RestReader();
                        userPrices = await reader.GetPrices(client, CurrentUserSignedInId);

                        EditProductFrag deleteFrag = new EditProductFrag(userPrices); 
                        FragmentTransaction transaction = FragmentManager.BeginTransaction();
                        deleteFrag.Show(transaction, "CreateProductFrag");

                        break;
                    }
                case 2:
                    {

                        //Delete profile
                        break;
                    }


            }
        }

        private void AddFrag_ProductHandler(object sender, OnCreateProductEvent e)
        {
            var client = new RestClient("http://10.0.2.2:60408");
            RestReader reader = new RestReader();
            RestInserter inserter = new RestInserter();


            
      
            Toast.MakeText(this, "Userprices might be null " + userPrices.Length, ToastLength.Short).Show();
            
            Prices price = new Prices
            {
                Id = CurrentUserSignedInId,
                ProductId =  (userPrices.Length == 0) ? 0 : userPrices[userPrices.Length-1].ProductId + 1,
                Name = e.Name,
                Price = e.Price,
                Picture = "none",
                IdNavigation = null,
                Ingredients = null  };
            try
            {
                 inserter.InsertPrice(price, client, CurrentUserSignedInId);
            }

            catch (Exception)
            {
                Toast.MakeText(this.ApplicationContext, "Exception at insertion attempt! (activity)", ToastLength.Short).Show();
            }
            


        }
    }
}