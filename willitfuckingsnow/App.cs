using Android.App;
using Android.Content;
using Android.Runtime;
using System;
using TinyIoC;
using willitfuckingsnow.Data.Redux;
using willitfuckingsnow.Data.State;
using willitfuckingsnow.Fragments;

namespace willitfuckingsnow
{
    [Application(Label = "@string/app_name")]
    class App : Application
    {
        IServiceConnection connection;

        public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
        {
        }

        public override void OnCreate()
        {
            var container = TinyIoCContainer.Current;

            //data resources
            container.Register<IApplicationState, ApplicationState>().AsSingleton();
            container.Register<IReduxStore<IApplicationState>, ReduxStore<IApplicationState>>().AsSingleton();

            // display resources
            container.Register<IAppPageCollection, WeatherPageCollection>();

            base.OnCreate();
        }
    }
}