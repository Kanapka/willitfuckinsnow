using Android.App;
using Android.Content;
using Android.Runtime;
using Java.Security;
using Java.Security.Cert;
using Javax.Net.Ssl;
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

            //AddCertificate();

            base.OnCreate();
        }

        void AddCertificate(int certificateId, int id)
        {
            var certificateFactory = CertificateFactory.GetInstance("X.509");
            string keyStoreType = KeyStore.DefaultType;
            KeyStore keyStore = KeyStore.GetInstance(keyStoreType);
            keyStore.Load(null, null);


            Certificate certificate;
            using (var stream = Application.Context.Resources.OpenRawResource(certificateId))
                certificate = certificateFactory.GenerateCertificate(stream);
            keyStore.SetCertificateEntry("ca" + id, certificate);

            string tmfAlgorithm = TrustManagerFactory.DefaultAlgorithm;
            TrustManagerFactory tmf = TrustManagerFactory.GetInstance(tmfAlgorithm);
            tmf.Init(keyStore);


            // Create a TrustManager that trusts the CAs in our KeyStore
            var trustManagerFactory = TrustManagerFactory.GetInstance(TrustManagerFactory.DefaultAlgorithm);
            trustManagerFactory.Init(keyStore);
            // Create an SSLContext that uses our TrustManager

            var ctx = SSLContext.GetInstance("TLS");
            ctx.Init(null, tmf.GetTrustManagers(), null);

            // apply the new context
            var socketFactory = ctx.SocketFactory;
        }
    }
}