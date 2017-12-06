using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using RESTXama.Models;
using DTUProjectApp.Toolbox;
using RestSharp;

namespace DTUProjectApp
{

 
    public class EditProductFrag : DialogFragment
    {



        public Prices[] _Users { get; set; }

        public EditProductFrag(Prices[] users)
        {
            _Users = users;
        }



        ListView productList;

       
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.currentpricesfrag, container);
            productList = view.FindViewById<ListView>(Resource.Id.currentPricesList);

            ProductAdapter adapter = new ProductAdapter(view.Context, _Users.ToList<Prices>());
            adapter.DeleteHandler += Adapter_DeleteHandler;

            productList.Adapter = adapter;
            
            return view;
        }

        private void Adapter_DeleteHandler(object sender, DeleteEventArgs e)
        {
            var client = new RestClient("http://10.0.2.2:60408");
            RestDeleter deleter = new RestDeleter();

            deleter.DeletePrice(e.ProductId, client);
            Dismiss();
        }
    }
}