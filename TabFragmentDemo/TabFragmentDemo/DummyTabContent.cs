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

namespace TabFragmentDemo
{
    class DummyTabContent : Java.Lang.Object,Android.Widget.TabHost.ITabContentFactory
    {
        private Context mContext; 
        public DummyTabContent(Context context)
        {
            mContext = context;
        }
        public View CreateTabContent(string tag)
        {
            View v = new View(mContext);
            return v;
        } 
    }
}