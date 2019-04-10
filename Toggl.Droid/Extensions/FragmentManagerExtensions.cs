﻿using System.Linq;
using Android.Support.V4.App;
using Toggl.Shared.Extensions;

namespace Toggl.Droid.Extensions
{
    public static class FragmentManagerExtensions
    {
        public static void RemoveAllFragments(this FragmentManager fragmentManager)
        {
            fragmentManager.Fragments
                .Aggregate(fragmentManager.BeginTransaction(), (transaction, fragment) => transaction.Remove(fragment))
                .Commit();
        }
    }
}
