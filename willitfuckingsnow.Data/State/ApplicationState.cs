using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using willitfuckingsnow.Data.Redux;

namespace willitfuckingsnow.Data.State
{
    public interface IApplicationState
    {
        string Location { get; set; }
        DateTime Date { get; set; }
        string Status { get; set; }
        string AdditionalStatus { get; set; }
        float Temperature { get; set; }
    }
    public class ApplicationState : IApplicationState
    {
        public ApplicationState()
        {
            ;
        }
        public string Location { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public string Status { get; set; } = "";
        public string AdditionalStatus { get; set; } = "";
        public float Temperature { get; set; } = 0;
    }
}