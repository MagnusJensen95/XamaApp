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
using System;
using DTUProjectApp.Model;
using RESTXama.Models;
using Java.Lang;

namespace DTUProjectApp.Toolbox
{
    class BarAdapter : BaseAdapter<Users>
    {
        public override Users this[int position] => throw new NotImplementedException();

        public override int Count => throw new NotImplementedException();

   

        public override long GetItemId(int position)
        {
            throw new NotImplementedException();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            throw new NotImplementedException();
        }
    }
}