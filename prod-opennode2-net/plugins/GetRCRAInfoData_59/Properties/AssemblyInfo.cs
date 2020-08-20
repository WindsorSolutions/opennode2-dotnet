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

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Commons.AssemblyInfo;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("GetRCRAInfoData 5.9 Plugin")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(AssemblyInfo.cAssemblyCompany)]
[assembly: AssemblyProduct(AssemblyInfo.cAssemblyProduct)]
[assembly: AssemblyCopyright(AssemblyInfo.cAssemblyCopyright)]
[assembly: AssemblyTrademark(AssemblyInfo.cAssemblyTrademark)]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("539D86E1-B390-4A7A-BCA2-79654B950000")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion(AssemblyInfo.cAssemblyVersion)]
[assembly: AssemblyFileVersion(AssemblyInfo.cAssemblyFileVersion)]
[assembly: PluginDefaultFlowAttribute("GetRCRAInfoData")]
[assembly: PluginPackageNameAttribute("GetRCRAInfoData 5.9")]
[assembly: PluginSqlDdlFilePaths(@"RCRA\5.9\staging_schema_ddl\RCRA_5.7-SQL-DDL.sql,RCRA\5.9\staging_schema_ddl\RCRA_5.7-ORA-DDL.sql,RCRA\5.9\staging_schema_ddl\RCRA_5.6_to_5.7-upgrade_SQL-DDL.sql,RCRA\5.9\staging_schema_ddl\RCRA_5.6_to_5.7-upgrade_ORA-DDL.sql,RCRA\5.9\RCRA_REPORTING_5.7_ORA_DDL.sql,RCRA\5.9\RCRA_REPORTING_5.7_SQL_DDL.sql")]
[assembly: PublicPluginAttribute()]
