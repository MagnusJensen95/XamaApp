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
    class MainBarContentAdapter : BaseAdapter<Prices>
    {


        private Context CurrentContext { get; set; }

        private List<Prices> productList;

        public MainBarContentAdapter(Context context, List<Prices> prices) : base()
        {
            CurrentContext = context;
            productList = prices;
        }


        public override Prices this[int position] => throw new NotImplementedException();

        public override int Count => productList.ToArray().Length;

        public override long GetItemId(int position)
        {
            return 1;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(CurrentContext)
                    .Inflate(Resource.Layout.mainbarcontentrowlayout, null, false);
            }

            TextView titleText = row.FindViewById<TextView>(Resource.Id.mainBarRowProductTitle);
            TextView subText = row.FindViewById<TextView>(Resource.Id.mainBarRowProductPrice);
            titleText.Text = productList[position].Name;
            subText.Text = "" + productList[position].Price + " kr.";


            return row;
        }
    }
}