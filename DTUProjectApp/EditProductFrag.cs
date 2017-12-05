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
    public class EditProductFrag : DialogFragment
    {

        ListView productList;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.currentpricesfrag, container);
            productList = view.FindViewById<ListView>(Resource.Id.currentPricesList);

            

            return view;
        }
    }
}