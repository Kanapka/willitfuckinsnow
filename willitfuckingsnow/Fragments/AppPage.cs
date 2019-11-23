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
using Fragment = Android.Support.V4.App.Fragment;
using willitfuckingsnow.Data.State;
using willitfuckingsnow.Data.Redux;

namespace willitfuckingsnow.Fragments
{
    public abstract class AppPage : Fragment, IObserver<IApplicationState>
    {
        protected IReduxStore<IApplicationState> store;

        public AppPage(IReduxStore<IApplicationState> _store)
        {
            store = _store;
            store.Subscribe(this);
            OnNext(store.State);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
        public void OnCompleted()
        { }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public abstract void OnNext(IApplicationState state);
    }
}