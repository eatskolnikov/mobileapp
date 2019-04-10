﻿using System;
using Android.Content;
using Android.Support.V4.Content;
using Android.Widget;
using Toggl.Core.UI.Reactive;

namespace Toggl.Droid.Extensions.Reactive
{
    public static class ImageViewExtensions
    {
        public static Action<int> Image(this IReactive<ImageView> reactive, Context context)
            => resource => reactive.Base.SetImageDrawable(ContextCompat.GetDrawable(context, resource));
    }
}
