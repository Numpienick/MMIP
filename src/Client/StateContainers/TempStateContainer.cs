using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace Client.StateContainers
{
    public class TempStateContainer
    {
        public Challenge? Challenge { get; set; }
        public event Action? OnStateChange;

        public void SetValue(Challenge? challenge)
        {
            Challenge = challenge;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
