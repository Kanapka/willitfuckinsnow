using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using willitfuckingsnow.Data.State;
using System.Threading.Tasks;
using System.Threading;

namespace willitfuckingsnow.Data
{
    public class Actions
    {
        public static Task<IApplicationState> SwitchToCurrent(IApplicationState state)
        {
            state.Today = state.Repository.GetCurrent().Result;
            return Task.FromResult(state);
        }

        public static Task<IApplicationState> SwitchToForecast(IApplicationState state)
        {
            state.Future = state.Repository.GetForecast().Result;
            return Task.FromResult(state);
        }
    }
}