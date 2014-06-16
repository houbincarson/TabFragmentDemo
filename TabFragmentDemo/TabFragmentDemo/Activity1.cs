using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;

namespace TabFragmentDemo
{
    [Activity(Label = "TabFragmentDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : FragmentActivity,Android.Widget.TabHost.IOnTabChangeListener
    {
        TabHost tabHost;
        LayoutInflater inflater;
        int[] tab_btn = new int[]{
			Resource.Drawable.tab_home_btn,
			Resource.Drawable.tab_message_btn,
			Resource.Drawable.tab_selfinfo_btn,
			Resource.Drawable.tab_more_btn
	    };
        string[] tab_String = new string[]{
			"首页","消息","我们","更多"
	};
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            //初始化组件		
            InitiView();
            tabHost.AddTab(tabHost.NewTabSpec("Fragment1").SetIndicator(getTabItemView(0)).SetContent(new DummyTabContent(BaseContext)));
            tabHost.AddTab(tabHost.NewTabSpec("Fragment2").SetIndicator(getTabItemView(1)).SetContent(new DummyTabContent(BaseContext)));
            tabHost.AddTab(tabHost.NewTabSpec("Fragment3").SetIndicator(getTabItemView(2)).SetContent(new DummyTabContent(BaseContext)));
            tabHost.AddTab(tabHost.NewTabSpec("Fragment4").SetIndicator(getTabItemView(3)).SetContent(new DummyTabContent(BaseContext)));

        }

        private void InitiView()
        {
            tabHost = (TabHost)this.FindViewById(Android.Resource.Id.TabHost);
            tabHost.Setup();
            tabHost.SetOnTabChangedListener(this);

           
            //TabHost.TabSpec tSpec_fragment1 = tabHost.NewTabSpec("Fragment1");
            ////为Tab按钮设置图标、文字和内容			
            //tSpec_fragment1.SetIndicator(getTabItemView(0));
            //tSpec_fragment1.SetContent(new DummyTabContent(BaseContext));
            //tabHost.AddTab(tSpec_fragment1);

            //TabHost.TabSpec tSpec_fragment2 = tabHost.NewTabSpec("Fragment2");
            ////为Tab按钮设置图标、文字和内容			
            //tSpec_fragment2.SetIndicator(getTabItemView(1));
            //tSpec_fragment2.SetContent(new DummyTabContent(BaseContext));
            //tabHost.AddTab(tSpec_fragment2);

            //TabHost.TabSpec tSpec_fragment3 = tabHost.NewTabSpec("Fragment3");
            ////为Tab按钮设置图标、文字和内容			
            //tSpec_fragment3.SetIndicator(getTabItemView(2));
            //tSpec_fragment3.SetContent(new DummyTabContent(BaseContext));
            //tabHost.AddTab(tSpec_fragment3);

            //TabHost.TabSpec tSpec_fragment4 = tabHost.NewTabSpec("Fragment4");
            ////为Tab按钮设置图标、文字和内容			
            //tSpec_fragment4.SetIndicator(getTabItemView(3));
            //tSpec_fragment4.SetContent(new DummyTabContent(BaseContext));
            //tabHost.AddTab(tSpec_fragment4);
        }

        private View getTabItemView(int i)
        {
            inflater = LayoutInflater.From(this);
            View view = inflater.Inflate(Resource.Layout.tab_items_view, null); 
            ImageView imageView = (ImageView)view.FindViewById(Resource.Id.tab_imageview);
            imageView.SetImageResource(tab_btn[i]);
            TextView textView = (TextView)view.FindViewById(Resource.Id.tab_textview);
            textView.SetText(tab_String[i],TextView.BufferType.Normal);
            return view;
        }

        public void OnTabChanged(string tabId)
        {
            FragmentManager fm = SupportFragmentManager;
            Fragment1 fragment1 = (Fragment1)fm.FindFragmentByTag("Fragment1");
            Fragment2 fragment2 = (Fragment2)fm.FindFragmentByTag("Fragment2");
            Fragment3 fragment3 = (Fragment3)fm.FindFragmentByTag("Fragment3");
            Fragment4 fragment4 = (Fragment4)fm.FindFragmentByTag("Fragment4");
            FragmentTransaction ft = fm.BeginTransaction();

            if (fragment1 != null)
                ft.Detach(fragment1);
            if (fragment2 != null)
                ft.Detach(fragment2);
            if (fragment3 != null)
                ft.Detach(fragment3);
            if (fragment4 != null)
                ft.Detach(fragment4);

            //当前选项卡
            if (tabId.Equals("Fragment1"))
            {
                if (fragment1 == null)
                {
                    ft.Add(Resource.Id.realtabcontent, new Fragment1(), "Fragment1");
                }
                else
                {
                    ft.Attach(fragment1);
                }
            }
            else if (tabId.Equals("Fragment2"))
            {
                if (fragment2 == null)
                {
                    ft.Add(Resource.Id.realtabcontent, new Fragment2(), "Fragment2");
                }
                else
                {
                    ft.Attach(fragment2);
                }
            }
            else if (tabId.Equals("Fragment3"))
            {
                if (fragment3 == null)
                {
                    ft.Add(Resource.Id.realtabcontent, new Fragment3(), "Fragment3");
                }
                else
                {
                    ft.Attach(fragment3);
                }
            }
            else if (tabId.Equals("Fragment4"))
            {
                if (fragment4 == null)
                {
                    ft.Add(Resource.Id.realtabcontent, new Fragment4(), "Fragment4");
                }
                else
                {
                    ft.Attach(fragment4);
                }
            } 
            ft.Commit();
        }
    }
}

