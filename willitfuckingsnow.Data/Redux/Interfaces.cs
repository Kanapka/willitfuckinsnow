using System;
using System.Threading.Tasks;

namespace willitfuckingsnow.Data.Redux
{

    public interface IReduxStore<TReduxState> : IObservable<TReduxState>, IDisposable
    {
        TReduxState State { get; }
        Task Dispatch(Action<TReduxState> action);
        void Commit(Mutation<TReduxState> mutation);

    }

    public delegate Task<T> Action<T>(T state);
    public delegate T Mutation<T>(T state);



}