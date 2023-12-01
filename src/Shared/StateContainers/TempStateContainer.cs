using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace Shared.StateContainers
{
    public class TempStateContainer
    {
        private static TempStateContainer _instance;

        public IQueryable<Challenge> Challenges { get; set; }
        public IQueryable<Reaction> Reactions { get; set; }

        public static TempStateContainer Instance()
        {
            if (_instance == null)
            {
                _instance = new TempStateContainer();
            }

            return _instance;
        }
    }
}
