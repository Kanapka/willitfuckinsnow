using System;
using System.Threading.Tasks;

namespace willitfuckingsnow.Data.Redux
{

    public interface IReduxStore<TReduxState> : IObservable<TReduxState>, IDisposable
    {
        TReduxState State { get; }
        Task Dispatch(Action<TReduxState> action);
        void Commit(Mutation<TReduxState> mutation);
        void Commit<P>(Mutation<TReduxState, P> mutation, P payload) where P : ActionPayload;

    }

    public delegate Task<T> Action<T>(T state);
    public delegate T Mutation<T>(T state);
    public delegate T Mutation<T, P>(T state, P payload) where P : ActionPayload;


    public class ActionPayload { }

}