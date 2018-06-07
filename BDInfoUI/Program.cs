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
using System.Collections.Generic;
using System.Windows.Forms;

using System.ComponentModel;
using System.Runtime.Serialization;

namespace BDInfo
{
    static class Program
    {
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
            FormMain main = (FormMain)FormatterServices.GetUninitializedObject(typeof(FormMain));
            System.Console.WriteLine("Please wait while we scan the disc...");
            DoWorkEventArgs eventArgs = new DoWorkEventArgs(args[0]);
            main.InitBDROMWork(null, eventArgs);
            main.LoadPlaylists();
            main.ScanBDROMWork(null, null);
            main.GenerateReportCLI(args[0]);
#endif
        }
    }
}
