﻿using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Android.Support.V7.App;
using Activity = Android.App.Activity;
using System.Linq;
using Android.Content;

namespace Toggl.Droid.Views
{
    public class ListSelectionDialog<T>
    {
        private readonly List<(string Text, T Item)> options;
        private readonly string title;
        private readonly Action<T> onChosen;
        private readonly int initialIndex;
        private Activity activity;
        private AlertDialog dialog;

        public ListSelectionDialog(
            Activity activity,
            string title,
            IEnumerable<(string Text, T Item)> options,
            int initialIndex,
            Action<T> onChosen)
        {
            this.activity = activity;
            this.initialIndex = initialIndex;
            this.title = title;
            this.options = options.ToList();
            this.onChosen = onChosen;
        }

        public void Show()
        {
            if (activity == null)
                throw new InvalidOperationException("Dialog has already been dismissed.");

            var texts = options.Select(option => option.Text).ToArray();

            dialog = new AlertDialog.Builder(activity, Resource.Style.TogglDialog)
                .SetTitle(title)
                .SetSingleChoiceItems(texts, initialIndex, onItemChosen)
                .Show();
        }

        private void onItemChosen(object sender, DialogClickEventArgs args)
        {
            onChosen(options[args.Which].Item);

            dialog.Dismiss();
            activity = null;
        }
    }
}
