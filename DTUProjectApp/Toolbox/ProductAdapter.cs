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
using RESTXama.Models;

namespace DTUProjectApp.Toolbox
{

    class DeleteEventArgs : EventArgs
    {

        public int ProductId { get; set; }

    }
    class ProductAdapter : BaseAdapter<string>
    {
        Context CurrentContext { get; set; }

        List<Prices> productList;
         public event EventHandler<DeleteEventArgs> DeleteHandler;
        public int ProductSelected { get; set; }
        public int TestCount { get; set; }
        private bool delegateAdded = false;

        public ProductAdapter(Context context, List<Prices> products) : base()
        {
            CurrentContext = context;
            productList = products;
            TestCount = 0;
        }

        public override string this[int position] => throw new NotImplementedException();

        public override int Count => productList.ToArray().Length;

        public override long GetItemId(int position)
        {
            return 1;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            Prices price = productList[position];
            if (row == null)
            {
                row = LayoutInflater.From(CurrentContext)
                    .Inflate(Resource.Layout.productrowlayout, null, false);
                TextView productName = row.FindViewById<TextView>(Resource.Id.rowProductTitle);
                TextView productPrice = row.FindViewById<TextView>(Resource.Id.rowProductPrice);
                Button deleteButton = row.FindViewById<Button>(Resource.Id.deleteProductButton);
                productName.Text = productList[position].Name;
                productPrice.Text = "" + productList[position].Price + " kr.";


                deleteButton.Click += (object s, EventArgs e) =>
                {
                    TestCount++;
                    //Toast.MakeText(row.Context, "Counts: " + TestCount, ToastLength.Short).Show();
                    DeleteHandler.Invoke(s, new DeleteEventArgs { ProductId = productList[position].ProductId });
                    delegateAdded = true;
                    
                };
            }

            return row;
        }

     
    }
}