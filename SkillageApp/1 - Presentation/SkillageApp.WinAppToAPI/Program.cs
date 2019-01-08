using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SkillageApp.WinAppToAPI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new RadMainForm());
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        /// <summary>
        /// Write log win application to EventLog of windows
        /// </summary>
        /// <param name="ex"></param>
        static void WriteLog(Exception ex)
        {
            var eventLog = new EventLog();
            if (!(EventLog.SourceExists("SkillageApp")))
            {
                EventLog.CreateEventSource("SkillageApp", "Log");
            }
            eventLog.Source = "SkillageApp";

            eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
        }
    }
}