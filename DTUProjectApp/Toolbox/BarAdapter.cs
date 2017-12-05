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
using RESTXama.Models;
using Java.Lang;

namespace DTUProjectApp.Toolbox
{
    class BarAdapter : BaseAdapter<Users>
    {
        Context CurrentContext { get; set; }

        List<Users> usersList;

        public BarAdapter(Context context, List<Users> users) : base()
        {
            CurrentContext = context;
            usersList = users;
        }


        public override Users this[int position] => throw new NotImplementedException();

        public override int Count => usersList.ToArray().Length;

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
                    .Inflate(Resource.Layout.mainrowlayout, null, false);
            }

           TextView titleText = row.FindViewById<TextView>(Resource.Id.rowTitle);
           TextView subText = row.FindViewById<TextView>(Resource.Id.rowSubTitle);
            titleText.Text = usersList[position].Name;
            subText.Text = usersList[position].Email;
            

            return row;
        }
    }
}