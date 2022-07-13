using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Squirrel;

namespace DigitalReceipts
{
    internal class Updater
    {
        public static async Task UpdateMyApp()
        {
            using var mgr = new UpdateManager("https://github.com/rex8112/DigitalReceipts/releases");
            if (mgr.IsInstalledApp)
            {
                var newVersion = await mgr.UpdateApp();

                if (newVersion != null) UpdateManager.RestartApp();
            }
        }
    }
}
