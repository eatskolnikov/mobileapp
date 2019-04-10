﻿using System;
using Android.Support.Design.Widget;

namespace Toggl.Droid.Activities
{
    public sealed partial class MainTabBarActivity
    {
        private BottomNavigationView navigationView;

        protected override void InitializeViews()
        {
            navigationView = FindViewById<BottomNavigationView>(Resource.Id.MainTabBarBottomNavigationView);
        }
    }
}
