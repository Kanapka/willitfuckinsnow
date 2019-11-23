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
        public static Task<IApplicationState> CurrentViewLoaded(IApplicationState state)
        {
            Thread.Sleep(2000);
            state.Location = "Middle of fucking nowhere";
            state.Date = DateTime.Now;
            state.Status = "Rains like fuck";
            state.AdditionalStatus = "And it ain't gonna stop today";
            state.Temperature = 15.3f;
            return Task.FromResult(state);
        }
    }
}