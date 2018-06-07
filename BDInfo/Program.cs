//============================================================================
// BDInfo - Blu-ray Video and Audio Analysis Tool
// Copyright © 2010 Cinema Squid
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//=============================================================================

using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using Mono.Options;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace BDInfo
{
    static class Program
    {

        public static void show_help(OptionSet option_set, string msg = null)
        {
            if (msg != null)
                Console.Error.WriteLine(msg);
            Console.Error.WriteLine("BDInfo.exe <BD_FOLDER> [REPORT_DEST]");
            option_set.WriteOptionDescriptions(Console.Error);
            Environment.Exit(-1);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
#if false
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(args));
#else
            bool help = false;
            bool version = false;
            bool whole = false;
            bool list = false;
            string mpls = null;
            OptionSet option_set = new OptionSet()
                .Add("h|help", "Print out the options.", option => help = option != null)
                .Add("l|list", "Print the list of playlists.", option => list = option != null)
                .Add("m=|mpls=", "Comma separated list of playlists to scan.", option => mpls = option)
                .Add("w|whole", "Scan whole disc - every playlist.", option => whole = option != null)
                .Add("v|version", "Print the version.", option => version = option != null)
            ;

            List<string> nsargs = new List<string>();
            try
            {
                nsargs = option_set.Parse(args);
            }
            catch (OptionException)
            {
                show_help(option_set, "Error - usage is:");
            }

            if (help)
                show_help(option_set);

            if (version)
            {
                Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Version.ToString());
                Environment.Exit(-1);
            }

            if (list)
                whole = true;

            if (nsargs.Count == 0)
                show_help(option_set, "Error: insufficient args - usage is:");

            string bdPath = nsargs[0];
            if (!System.IO.Directory.Exists(bdPath))
            {
                Console.Error.WriteLine(String.Format("error: {0} does not exist or is not a directory", bdPath));
                Environment.Exit(-1);
            }
            string reportPath = bdPath;
            if (nsargs.Count == 2)
                reportPath = nsargs[1];
            if (!System.IO.Directory.Exists(reportPath))
            {
                Console.Error.WriteLine(String.Format("error: {0} does not exist or is not a directory", reportPath));
                Environment.Exit(-1);
            }

            FormMain main = (FormMain)FormatterServices.GetUninitializedObject(typeof(FormMain));
            System.Console.WriteLine("Please wait while we scan the disc...");
            DoWorkEventArgs eventArgs = new DoWorkEventArgs(bdPath);
            main.InitBDROMWork(null, eventArgs);
            if (mpls != null) {
                System.Console.WriteLine(mpls);
                main.LoadPlaylists(mpls.Split(',').ToList());
            }
            else if (whole)
                main.LoadPlaylists(true);
            else
                main.LoadPlaylists();
            if (list)
                Environment.Exit(0);
            main.ScanBDROMWork(null, null);
            main.GenerateReportCLI(reportPath);
#endif
        }
    }
}
