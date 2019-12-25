using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace willitfuckingsnow.Data.Redux
{
    public class ReduxStore<TReduxState> : IReduxStore<TReduxState>
    {
        public TReduxState State { get; private set; }

        readonly List<IObserver<TReduxState>> Observers = new List<IObserver<TReduxState>>();

        public ReduxStore(TReduxState initialState)
        {
            State = initialState;
        }

        public async Task Dispatch(Action<TReduxState> action)
        {
            State = await action(State);
            Notify();
        }

        public void Commit(Mutation<TReduxState> mutation)
        {
            State = mutation(State);
            Notify();
        }

        public void Commit<P>(Mutation<TReduxState, P> mutation, P payload) where P : ActionPayload
        {
            State = mutation(State, payload);
            Notify();
        }

        public IDisposable Subscribe(IObserver<TReduxState> observer)
        {
            Observers.Add(observer);
            return new Unsubscriber(Unsubscribe, observer);
        }

        void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.OnNext(State);
            }
        }

        public void Dispose()
        {
            foreach (var observer in Observers)
            {
                observer.OnCompleted();
            }
            Observers.Clear();
        }

        delegate void DUnsubscribe(IObserver<TReduxState> observer);

        void Unsubscribe(IObserver<TReduxState> observer)
        {
            if (observer != null && Observers.Contains(observer))
            {
                Observers.Remove(observer);
            }
        }

        class Unsubscriber : IDisposable
        {
            IObserver<TReduxState> Observer;
            DUnsubscribe Unsubscribe;
            public Unsubscriber(DUnsubscribe unsubscribe, IObserver<TReduxState> observer)
            {
                Observer = observer;
                Unsubscribe = unsubscribe;
            }
            public void Dispose()
            {
                Unsubscribe(Observer);
            }
        }
    }
}