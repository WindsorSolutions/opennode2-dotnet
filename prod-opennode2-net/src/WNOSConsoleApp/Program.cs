#region License
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Xml;
using System.IO;

using Windsor.Node2008.WNOS;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSPlugin.AFX_10;

namespace Windsor.Node2008.WNOSConsoleApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //var exception =
                //     AFXQuerySolicitProcessor.GenerateSubmissionFile("server= SQL2008;User ID=AFX_NODE_FLOW;Password=M3morial!;database = NWIFC_ADULT_FISH",
                //                                                     "System.Data.SqlClient", null, true, "NWIFC_AFX", false, (string message) =>
                //                                                     {
                //                                                         Console.WriteLine(message);
                //                                                     },
                //                                                     out string outSubmissionFilePath, out string outValidationErrorsFilePath);
                //var exception =
                //    AFXSubmissionProcessor.ImportFile("server= SQL2008;User ID=AFX_NODE_FLOW;Password=M3morial!;database = NWIFC_ADULT_FISH",
                //                                      "System.Data.SqlClient", null, @"D:\PROJECTS\OpenNode2-git\prod-opennode2-net\private\AFX_10\AFX.xml", true, (string message) =>
                //                                      {
                //                                          Console.WriteLine(message);
                //                                      },
                //                                      out string[] importedPrimaryKeys, out string outValidationErrorsFilePath);
                Console.WriteLine("Starting server...");
                WNOSController.Start("WNOS");
                Console.WriteLine("Server started");
                Console.WriteLine();

                Console.WriteLine("Press <return> to stop server...");
                Console.ReadKey();

                Console.WriteLine();
                Console.WriteLine("Stopping server...");
                WNOSController.Stop();
                Console.WriteLine("Server stopped");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                DebugUtils.CheckDebuggerBreak();
                Console.WriteLine("\n\n\n***************************\n\n"
                    + ex.Message
                    + "\n\n***************************\n\n\n", ex);

                Console.WriteLine("\n\n\nERROR *********************\n\n");
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
