using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace willitfuckingsnow.API.Services
{
    public interface IAuthorization
    {
        string Key { get; }
    }
    public class Authorization : IAuthorization
    {
        public string Key { get; }
        public Authorization(string absoluteKeyPath)
        {
            var key = File.ReadAllText(absoluteKeyPath);
            Key = key;
        }
    }
}
