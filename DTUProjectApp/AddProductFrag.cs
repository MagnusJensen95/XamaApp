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

namespace DTUProjectApp
{

    public class OnCreateProductEvent : EventArgs
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int userId { get; set; }

        public OnCreateProductEvent() : base()
        {

        }

    }
    public class AddProductFrag : DialogFragment
    {

        Button addProductButton;

        public event EventHandler<OnCreateProductEvent> ProductHandler;

        EditText name, price;
        public int UserId { get; set; }

        public AddProductFrag(int userID)
        {
            UserId = userID;

        }
      
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.AddProductLayout, container);
            addProductButton = view.FindViewById<Button>(Resource.Id.addProductConfirm);

            name = view.FindViewById<EditText>(Resource.Id.addProductNameTextEdit);
            price = view.FindViewById<EditText>(Resource.Id.priceTextEdit);
            

            addProductButton.Click += AddProductButton_Click;

            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {

            if (name.Text == "" || price.Text == "")
            {
                Toast.MakeText(this.Context, "You must fill out every field!", ToastLength.Short).Show();
                return;
            }
            ProductHandler.Invoke(sender, new OnCreateProductEvent {Name = name.Text, Price = Int32.Parse(price.Text), userId = UserId});
            Dismiss();
        }
    }
}