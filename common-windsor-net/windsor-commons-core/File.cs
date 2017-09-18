using System;
using System.Collections.Generic;
using System.IO;
using SIO = System.IO;
using System.Text;
using System.Linq;
using System.Security.AccessControl;

namespace Windsor.Commons.Core.IO
{
    /// <summary>Augments <see cref="T:System.IO.File"/> class with ability to pass in username, password, and domain to connect to UNC paths.  Use with care, as operations are slow across a network and this class will enforce
    /// one operation at a time across threads. As such, methods returning streams are disabled.  Backward compatible, so it is possible to use this class for local paths (just pass in null user/pass/domain information.
    /// Provides static methods for the creation, copying, deletion, moving, and opening of files, and aids in the creation of <see cref="T:System.IO.FileStream" /> objects.</summary>
    /// <filterpriority>1</filterpriority>
    public class File
    {
        private static readonly object _lockObj = new object();

        /// <summary>Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.</summary>
        /// <param name="path">The file to append the specified string to. </param>
        /// <param name="contents">The string to append to the file. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void AppendAllText(string path, string contents, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.AppendAllText(path, contents), path, username, password, domain);
        }

        private static T WrapFunctionWithConnection<T>(Func<T> function, string path, string username, string password, string domain)
        {
            lock (_lockObj) {
                try {
                    Connect(path, username, password, domain);
                    return function();
                }
                finally {
                    Disconnect(path, username);
                }
            }
        }

        private static void WrapActionWithConnection(Action action, string path, string username, string password, string domain)
        {
            lock (_lockObj) {
                try {
                    Connect(path, username, password, domain);
                    action();
                }
                finally {
                    Disconnect(path, username);
                }
            }
        }

        private static void Connect(string path, string username, string password, string domain)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(path);

            if (string.IsNullOrEmpty(username) ||
                !(path.StartsWith(Path.DirectorySeparatorChar.ToString() + Path.DirectorySeparatorChar.ToString()) ||
                path.StartsWith(Path.AltDirectorySeparatorChar.ToString() + Path.AltDirectorySeparatorChar.ToString())
                )) return;

            // http://stackoverflow.com/questions/659013            
            PinvokeWindowsNetworking.ConnectToRemote(path, CombineDomain(domain, username), password);
        }

        private static string CombineDomain(string domain, string username)
        {
            return !string.IsNullOrEmpty(domain)
                ? domain + @"\" + username
                : username;
        }

        private static void Disconnect(string path, string username)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(path);

            if (string.IsNullOrEmpty(username) ||
                !(path.StartsWith(Path.DirectorySeparatorChar.ToString() + Path.DirectorySeparatorChar.ToString()) ||
                path.StartsWith(Path.AltDirectorySeparatorChar.ToString() + Path.AltDirectorySeparatorChar.ToString())
                )) return;

            PinvokeWindowsNetworking.DisconnectRemote(path);
            //disconnectRemote(ToUncMachineOnly(path));
        }

        /// <summary>Appends the specified string to the file, creating the file if it does not already exist.</summary>
        /// <param name="path">The file to append the specified string to. </param>
        /// <param name="contents">The string to append to the file. </param>
        /// <param name="encoding">The character encoding to use. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void AppendAllText(string path, string contents, Encoding encoding, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.AppendAllText(path, contents, encoding), path, username, password, domain);
        }

        /// <summary>Creates a <see cref="T:System.IO.StreamWriter" /> that appends UTF-8 encoded text to an existing file.</summary>
        /// <returns>A StreamWriter that appends UTF-8 encoded text to an existing file.</returns>
        /// <param name="path">The path to the file to append to. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static StreamWriter AppendText(string path, string username, string password, string domain)
        {
            throw new NotImplementedException("This method needs to return a wrapped streamreader with a custom dispose method to work correctly");
            //return WrapFunctionWithConnection(() => SIO.File.AppendText(path), path, username, password, domain);
        }

        /// <summary>Copies an existing file to a new file. Overwriting a file of the same name is not allowed.</summary>
        /// <param name="sourceFileName">The file to copy. </param>
        /// <param name="destFileName">The name of the destination file. This cannot be a directory or an existing file. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />.-or- <paramref name="sourceFileName" /> or <paramref name="destFileName" /> specifies a directory. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The path specified in <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///   <paramref name="sourceFileName" /> was not found. </exception>
        /// <exception cref="T:System.IO.IOException">
        ///   <paramref name="destFileName" /> exists.-or- An I/O error has occurred. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void Copy(string sourceFileName, string destFileName,
            string sourceusername, string sourcepassword, string sourcedomain,
            string destusername, string destpassword, string destdomain)
        {
            Copy(sourceFileName, destFileName, false, sourceusername, sourcepassword, sourcedomain, destusername, destpassword, destdomain);
        }

        /// <summary>Copies an existing file to a new file. Overwriting a file of the same name is allowed.</summary>
        /// <param name="sourceFileName">The file to copy. </param>
        /// <param name="destFileName">The name of the destination file. This cannot be a directory. </param>
        /// <param name="overwrite">true if the destination file can be overwritten; otherwise, false. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. -or-<paramref name="destFileName" /> is read-only.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />.-or- <paramref name="sourceFileName" /> or <paramref name="destFileName" /> specifies a directory. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The path specified in <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///   <paramref name="sourceFileName" /> was not found. </exception>
        /// <exception cref="T:System.IO.IOException">
        ///   <paramref name="destFileName" /> exists and <paramref name="overwrite" /> is false.-or- An I/O error has occurred. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void Copy(string sourceFileName, string destFileName, bool overwrite,
            string sourceusername, string sourcepassword, string sourcedomain,
            string destusername, string destpassword, string destdomain)
        {
            // Copy is a special case.  We might have two connections
            try {
                Connect(destFileName, destusername, destpassword, destdomain);
                WrapActionWithConnection(() => SIO.File.Copy(sourceFileName, destFileName, overwrite), sourceFileName, sourceusername, sourcepassword, sourcedomain);
            }
            finally {
                Disconnect(destFileName, destusername);
            }
        }

        /// <summary>Creates or overwrites a file in the specified path.</summary>
        /// <returns>A <see cref="T:System.IO.FileStream" /> that provides read/write access to the file specified in <paramref name="path" />.</returns>
        /// <param name="path">The path and name of the file to create. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.-or- <paramref name="path" /> specified a file that is read-only. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while creating the file. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static FileStream Create(string path, string username, string password, string domain)
        {
            throw new NotImplementedException("This method needs to return a wrapped streamreader with a custom dispose method to work correctly");
            //return WrapFunctionWithConnection(() => SIO.File.Create(path), path, username, password, domain);
        }

        /// <summary>Creates or overwrites the specified file.</summary>
        /// <returns>A <see cref="T:System.IO.FileStream" /> with the specified buffer size that provides read/write access to the file specified in <paramref name="path" />.</returns>
        /// <param name="path">The name of the file. </param>
        /// <param name="bufferSize">The number of bytes buffered for reads and writes to the file. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.-or- <paramref name="path" /> specified a file that is read-only. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while creating the file. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static FileStream Create(string path, int bufferSize, string username, string password, string domain)
        {
            throw new NotImplementedException("This method needs to return a wrapped streamreader with a custom dispose method to work correctly"); ;
            //return WrapFunctionWithConnection(() => SIO.File.Create(path, bufferSize), path, username, password, domain);
        }

        /// <summary>Creates or overwrites the specified file, specifying a buffer size and a <see cref="T:System.IO.FileOptions" /> value that describes how to create or overwrite the file.</summary>
        /// <returns>A new file with the specified buffer size.</returns>
        /// <param name="path">The name of the file. </param>
        /// <param name="bufferSize">The number of bytes buffered for reads and writes to the file. </param>
        /// <param name="options">One of the <see cref="T:System.IO.FileOptions" /> values that describes how to create or overwrite the file.</param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.-or- <paramref name="path" /> specified a file that is read-only. -or-<see cref="F:System.IO.FileOptions.Encrypted" /> is specified for <paramref name="options" /> and file encryption is not supported on the current platform.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while creating the file. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.-or- <paramref name="path" /> specified a file that is read-only. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.-or- <paramref name="path" /> specified a file that is read-only. </exception>
        public static FileStream Create(string path, int bufferSize, FileOptions options, string username, string password, string domain)
        {
            throw new NotImplementedException("This method needs to return a wrapped streamreader with a custom dispose method to work correctly");
            //return WrapFunctionWithConnection(() => SIO.File.Create(path, bufferSize, options), path, username, password, domain);
        }

        /// <summary>Creates or overwrites the specified file with the specified buffer size, file options, and file security.</summary>
        /// <returns>A new file with the specified buffer size, file options, and file security.</returns>
        /// <param name="path">The name of the file. </param>
        /// <param name="bufferSize">The number of bytes buffered for reads and writes to the file. </param>
        /// <param name="options">One of the <see cref="T:System.IO.FileOptions" /> values that describes how to create or overwrite the file.</param>
        /// <param name="fileSecurity">One of the <see cref="T:System.Security.AccessControl.FileSecurity" /> values that determines the access control and audit security for the file.</param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.-or- <paramref name="path" /> specified a file that is read-only.-or-<see cref="F:System.IO.FileOptions.Encrypted" /> is specified for <paramref name="options" /> and file encryption is not supported on the current platform. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while creating the file. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.-or- <paramref name="path" /> specified a file that is read-only. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.-or- <paramref name="path" /> specified a file that is read-only. </exception>
        public static FileStream Create(string path, int bufferSize, FileOptions options, FileSecurity fileSecurity, string username, string password, string domain)
        {
            throw new NotImplementedException("This method needs to return a wrapped streamreader with a custom dispose method to work correctly");
            //return WrapFunctionWithConnection(() => SIO.File.Create(path, bufferSize, options, fileSecurity), path, username, password, domain);
        }

        /// <summary>Creates or opens a file for writing UTF-8 encoded text.</summary>
        /// <returns>A <see cref="T:System.IO.StreamWriter" /> that writes to the specified file using UTF-8 encoding.</returns>
        /// <param name="path">The file to be opened for writing. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static StreamWriter CreateText(string path, string username, string password, string domain)
        {
            throw new NotImplementedException("This method needs to return a wrapped streamreader with a custom dispose method to work correctly");
            //return WrapFunctionWithConnection(() => SIO.File.CreateText(path), path, username, password, domain);
        }

        /// <summary>Deletes the specified file. </summary>
        /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">The specified file is in use. -or-There is an open handle on the file, and the operating system is Windows XP or earlier. This open handle can result from enumerating directories and files. For more information, see How to: Enumerate Directories and Files.</exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.-or- <paramref name="path" /> is a directory.-or- <paramref name="path" /> specified a read-only file. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void Delete(string path, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.Delete(path), path, username, password, domain);
        }

        /// <summary>Determines whether the specified file exists.</summary>
        /// <returns>true if the caller has the required permissions and <paramref name="path" /> contains the name of an existing file; otherwise, false. This method also returns false if <paramref name="path" /> is null, an invalid path, or a zero-length string. If the caller does not have sufficient permissions to read the specified file, no exception is thrown and the method returns false regardless of the existence of <paramref name="path" />.</returns>
        /// <param name="path">The file to check. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static bool Exists(string path, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.Exists(path), path, username, password, domain);
        }
        /// <summary>Gets a <see cref="T:System.Security.AccessControl.FileSecurity" /> object that encapsulates the access control list (ACL) entries for a specified file.</summary>
        /// <returns>A <see cref="T:System.Security.AccessControl.FileSecurity" /> object that encapsulates the access control rules for the file described by the <paramref name="path" /> parameter.     </returns>
        /// <param name="path">The path to a file containing a <see cref="T:System.Security.AccessControl.FileSecurity" /> object that describes the file's access control list (ACL) information.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.SEHException">The <paramref name="path" /> parameter is null.</exception>
        /// <exception cref="T:System.SystemException">The file could not be found.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The <paramref name="path" /> parameter specified a file that is read-only.-or- This operation is not supported on the current platform.-or- The <paramref name="path" /> parameter specified a directory.-or- The caller does not have the required permission.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static FileSecurity GetAccessControl(string path, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.GetAccessControl(path), path, username, password, domain);
        }

        /// <summary>Gets a <see cref="T:System.Security.AccessControl.FileSecurity" /> object that encapsulates the specified type of access control list (ACL) entries for a particular file.</summary>
        /// <returns>A <see cref="T:System.Security.AccessControl.FileSecurity" /> object that encapsulates the access control rules for the file described by the <paramref name="path" /> parameter.     </returns>
        /// <param name="path">The path to a file containing a <see cref="T:System.Security.AccessControl.FileSecurity" /> object that describes the file's access control list (ACL) information.</param>
        /// <param name="includeSections">One of the <see cref="T:System.Security.AccessControl.AccessControlSections" /> values that specifies the type of access control list (ACL) information to receive.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.SEHException">The <paramref name="path" /> parameter is null.</exception>
        /// <exception cref="T:System.SystemException">The file could not be found.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The <paramref name="path" /> parameter specified a file that is read-only.-or- This operation is not supported on the current platform.-or- The <paramref name="path" /> parameter specified a directory.-or- The caller does not have the required permission.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static FileSecurity GetAccessControl(string path, AccessControlSections includeSections, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.GetAccessControl(path, includeSections), path, username, password, domain);
        }
        /// <summary>Gets the <see cref="T:System.IO.FileAttributes" /> of the file on the path.</summary>
        /// <returns>The <see cref="T:System.IO.FileAttributes" /> of the file on the path.</returns>
        /// <param name="path">The path to the file. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is empty, contains only white spaces, or contains invalid characters. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">
        ///   <paramref name="path" /> represents a file and is invalid, such as being on an unmapped drive, or the file cannot be found. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///   <paramref name="path" /> represents a directory and is invalid, such as being on an unmapped drive, or the directory cannot be found.</exception>
        /// <exception cref="T:System.IO.IOException">This file is being used by another process.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static FileAttributes GetAttributes(string path, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.GetAttributes(path), path, username, password, domain);
        }

        /// <summary>Returns the creation date and time of the specified file or directory.</summary>
        /// <returns>A <see cref="T:System.DateTime" /> structure set to the creation date and time for the specified file or directory. This value is expressed in local time.</returns>
        /// <param name="path">The file or directory for which to obtain creation date and time information. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static DateTime GetCreationTime(string path, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.GetCreationTime(path), path, username, password, domain);
        }
        /// <summary>Returns the creation date and time, in coordinated universal time (UTC), of the specified file or directory.</summary>
        /// <returns>A <see cref="T:System.DateTime" /> structure set to the creation date and time for the specified file or directory. This value is expressed in UTC time.</returns>
        /// <param name="path">The file or directory for which to obtain creation date and time information. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static DateTime GetCreationTimeUtc(string path, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.GetCreationTimeUtc(path), path, username, password, domain);
        }
        /// <summary>Returns the date and time the specified file or directory was last accessed.</summary>
        /// <returns>A <see cref="T:System.DateTime" /> structure set to the date and time that the specified file or directory was last accessed. This value is expressed in local time.</returns>
        /// <param name="path">The file or directory for which to obtain access date and time information. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static DateTime GetLastAccessTime(string path, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.GetLastAccessTime(path), path, username, password, domain);
        }
        /// <summary>Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last accessed.</summary>
        /// <returns>A <see cref="T:System.DateTime" /> structure set to the date and time that the specified file or directory was last accessed. This value is expressed in UTC time.</returns>
        /// <param name="path">The file or directory for which to obtain access date and time information. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static DateTime GetLastAccessTimeUtc(string path, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.GetLastAccessTimeUtc(path), path, username, password, domain);
        }
        /// <summary>Returns the date and time the specified file or directory was last written to.</summary>
        /// <returns>A <see cref="T:System.DateTime" /> structure set to the date and time that the specified file or directory was last written to. This value is expressed in local time.</returns>
        /// <param name="path">The file or directory for which to obtain write date and time information. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static DateTime GetLastWriteTime(string path, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.GetLastWriteTime(path), path, username, password, domain);
        }
        /// <summary>Returns the date and time, in coordinated universal time (UTC), that the specified file or directory was last written to.</summary>
        /// <returns>A <see cref="T:System.DateTime" /> structure set to the date and time that the specified file or directory was last written to. This value is expressed in UTC time.</returns>
        /// <param name="path">The file or directory for which to obtain write date and time information. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static DateTime GetLastWriteTimeUtc(string path, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.GetLastWriteTimeUtc(path), path, username, password, domain);
        }

        /// <summary>Moves a specified file to a new location, providing the option to specify a new file name.</summary>
        /// <param name="sourceFileName">The name of the file to move. </param>
        /// <param name="destFileName">The new path for the file. </param>
        /// <exception cref="T:System.IO.IOException">The destination file already exists.-or-<paramref name="sourceFileName" /> was not found. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is null. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The path specified in <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is invalid, (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="sourceFileName" /> or <paramref name="destFileName" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void Move(string sourceFileName, string destFileName,
            string sourceusername, string sourcepassword, string sourcedomain,
            string destusername, string destpassword, string destdomain)
        {
            // Move is a special case.  We might have two connections
            try {
                Connect(destFileName, destusername, destpassword, destdomain);
                WrapActionWithConnection(() => SIO.File.Move(sourceFileName, destFileName), sourceFileName, sourceusername, sourcepassword, sourcedomain);
            }
            finally {
                Disconnect(destFileName, destusername);
            }
        }
        //
        /// <summary>Opens a <see cref="T:System.IO.FileStream" /> on the specified path with read/write access.</summary>
        /// <returns>A <see cref="T:System.IO.FileStream" /> opened in the specified mode and path, with read/write access and not shared.</returns>
        /// <param name="path">The file to open. </param>
        /// <param name="mode">A <see cref="T:System.IO.FileMode" /> value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. -or-<paramref name="mode" /> is <see cref="F:System.IO.FileMode.Create" /> and the specified file is a hidden file.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="mode" /> specified an invalid value. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static FileStream Open(string path, FileMode mode, string username, string password, string domain)
        {
            throw new NotImplementedException("This method needs to return a wrapped streamreader with a custom dispose method to work correctly");
            //return WrapFunctionWithConnection(() => SIO.File.Open(path, mode), path, username, password, domain);
        }
        /// <summary>Opens a <see cref="T:System.IO.FileStream" /> on the specified path, with the specified mode and access.</summary>
        /// <returns>An unshared <see cref="T:System.IO.FileStream" /> that provides access to the specified file, with the specified mode and access.</returns>
        /// <param name="path">The file to open. </param>
        /// <param name="mode">A <see cref="T:System.IO.FileMode" /> value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten. </param>
        /// <param name="access">A <see cref="T:System.IO.FileAccess" /> value that specifies the operations that can be performed on the file. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />.-or- <paramref name="access" /> specified Read and <paramref name="mode" /> specified Create, CreateNew, Truncate, or Append. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only and <paramref name="access" /> is not Read.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. -or-<paramref name="mode" /> is <see cref="F:System.IO.FileMode.Create" /> and the specified file is a hidden file.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="mode" /> or <paramref name="access" /> specified an invalid value. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static FileStream Open(string path, FileMode mode, FileAccess access, string username, string password, string domain)
        {
            throw new NotImplementedException("This method needs to return a wrapped streamreader with a custom dispose method to work correctly");
            //return WrapFunctionWithConnection(() => SIO.File.Open(path, mode, access), path, username, password, domain);
        }

        /// <summary>Opens a <see cref="T:System.IO.FileStream" /> on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.</summary>
        /// <returns>A <see cref="T:System.IO.FileStream" /> on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.</returns>
        /// <param name="path">The file to open. </param>
        /// <param name="mode">A <see cref="T:System.IO.FileMode" /> value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten. </param>
        /// <param name="access">A <see cref="T:System.IO.FileAccess" /> value that specifies the operations that can be performed on the file. </param>
        /// <param name="share">A <see cref="T:System.IO.FileShare" /> value specifying the type of access other threads have to the file. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />.-or- <paramref name="access" /> specified Read and <paramref name="mode" /> specified Create, CreateNew, Truncate, or Append. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only and <paramref name="access" /> is not Read.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. -or-<paramref name="mode" /> is <see cref="F:System.IO.FileMode.Create" /> and the specified file is a hidden file.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="mode" />, <paramref name="access" />, or <paramref name="share" /> specified an invalid value. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static FileStream Open(string path, FileMode mode, FileAccess access, FileShare share, string username, string password, string domain)
        {
            throw new NotImplementedException("This method needs to return a wrapped streamreader with a custom dispose method to work correctly");
            //return WrapFunctionWithConnection(() => SIO.File.Open(path, mode, access, share), path, username, password, domain);
        }

        /// <summary>Opens an existing file for reading.</summary>
        /// <returns>A read-only <see cref="T:System.IO.FileStream" /> on the specified path.</returns>
        /// <param name="path">The file to be opened for reading. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static FileStream OpenRead(string path, string username, string password, string domain)
        {
            throw new NotImplementedException("This method needs to return a wrapped streamreader with a custom dispose method to work correctly");
            //return WrapFunctionWithConnection(() => SIO.File.OpenRead(path), path, username, password, domain);
        }

        /// <summary>Opens an existing UTF-8 encoded text file for reading.</summary>
        /// <returns>A <see cref="T:System.IO.StreamReader" /> on the specified path.</returns>
        /// <param name="path">The file to be opened for reading. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static StreamReader OpenText(string path, string username, string password, string domain)
        {
            throw new NotImplementedException("This method needs to return a wrapped streamreader with a custom dispose method to work correctly");
            //return WrapFunctionWithConnection(() => SIO.File.OpenText(path), path, username, password, domain);
        }
        /// <summary>Opens an existing file or creates a new file for writing.</summary>
        /// <returns>An unshared <see cref="T:System.IO.FileStream" /> object on the specified path with <see cref="F:System.IO.FileAccess.Write" /> access.</returns>
        /// <param name="path">The file to be opened for writing. </param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.-or- <paramref name="path" /> specified a read-only file or directory. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static FileStream OpenWrite(string path, string username, string password, string domain)
        {
            throw new NotImplementedException("This method needs to return a wrapped streamreader with a custom dispose method to work correctly");
            //return WrapFunctionWithConnection(() => SIO.File.OpenWrite(path), path, username, password, domain);
        }
        /// <summary>Opens a binary file, reads the contents of the file into a byte array, and then closes the file.</summary>
        /// <returns>A byte array containing the contents of the file.</returns>
        /// <param name="path">The file to open for reading. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static byte[] ReadAllBytes(string path, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.ReadAllBytes(path), path, username, password, domain);
        }

        /// <summary>Opens a text file, reads all lines of the file, and then closes the file.</summary>
        /// <returns>A string array containing all lines of the file.</returns>
        /// <param name="path">The file to open for reading. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static string[] ReadAllLines(string path, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.ReadAllLines(path), path, username, password, domain);
        }

        /// <summary>Opens a file, reads all lines of the file with the specified encoding, and then closes the file.</summary>
        /// <returns>A string array containing all lines of the file.</returns>
        /// <param name="path">The file to open for reading. </param>
        /// <param name="encoding">The encoding applied to the contents of the file. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static string[] ReadAllLines(string path, Encoding encoding, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.ReadAllLines(path, encoding), path, username, password, domain);
        }

        /// <summary>Opens a text file, reads all lines of the file, and then closes the file.</summary>
        /// <returns>A string containing all lines of the file.</returns>
        /// <param name="path">The file to open for reading. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static string ReadAllText(string path, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.ReadAllText(path), path, username, password, domain);
        }

        /// <summary>Opens a file, reads all lines of the file with the specified encoding, and then closes the file.</summary>
        /// <returns>A string containing all lines of the file.</returns>
        /// <param name="path">The file to open for reading. </param>
        /// <param name="encoding">The encoding applied to the contents of the file. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static string ReadAllText(string path, Encoding encoding, string username, string password, string domain)
        {
            return WrapFunctionWithConnection(() => SIO.File.ReadAllText(path, encoding), path, username, password, domain);
        }
        /// <summary>Replaces the contents of a specified file with the contents of another file, deleting the original file, and creating a backup of the replaced file.</summary>
        /// <param name="sourceFileName">The name of a file that replaces the file specified by <paramref name="destinationFileName" />.</param>
        /// <param name="destinationFileName">The name of the file being replaced.</param>
        /// <param name="destinationBackupFileName">The name of the backup file.</param>
        /// <exception cref="T:System.ArgumentException">The path described by the <paramref name="destinationFileName" /> parameter was not of a legal form.-or-The path described by the <paramref name="destinationBackupFileName" /> parameter was not of a legal form.</exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationFileName" /> parameter is null.</exception>
        /// <exception cref="T:System.IO.DriveNotFoundException">An invalid drive was specified. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file described by the current <see cref="T:System.IO.FileInfo" /> object could not be found.-or-The file described by the <paramref name="destinationBackupFileName" /> parameter could not be found. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file.- or -The <paramref name="sourceFileName" /> and <paramref name="destinationFileName" /> parameters specify the same file.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.PlatformNotSupportedException">The operating system is Windows 98 Second Edition or earlier and the files system is not NTFS.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The <paramref name="sourceFileName" /> or <paramref name="destinationFileName" /> parameter specifies a file that is read-only.-or- This operation is not supported on the current platform.-or- Source or destination parameters specify a directory instead of a file.-or- The caller does not have the required permission.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName,
            string sourceusername, string sourcepassword, string sourcedomain,
            string destusername, string destpassword, string destdomain)
        {
            // Replace is a special case.  We might have two connections
            try {
                Connect(destinationFileName, destusername, destpassword, destdomain);
                WrapActionWithConnection(() => SIO.File.Replace(sourceFileName, destinationFileName, destinationBackupFileName), sourceFileName, sourceusername, sourcepassword, sourcedomain);
            }
            finally {
                Disconnect(destinationFileName, destusername);
            }
        }
        /// <summary>Replaces the contents of a specified file with the contents of another file, deleting the original file, and creating a backup of the replaced file and optionally ignores merge errors.</summary>
        /// <param name="sourceFileName">The name of a file that replaces the file specified by <paramref name="destinationFileName" />.</param>
        /// <param name="destinationFileName">The name of the file being replaced.</param>
        /// <param name="destinationBackupFileName">The name of the backup file.</param>
        /// <param name="ignoreMetadataErrors">true to ignore merge errors (such as attributes and access control lists (ACLs)) from the replaced file to the replacement file; otherwise, false. </param>
        /// <exception cref="T:System.ArgumentException">The path described by the <paramref name="destinationFileName" /> parameter was not of a legal form.-or-The path described by the <paramref name="destinationBackupFileName" /> parameter was not of a legal form.</exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationFileName" /> parameter is null.</exception>
        /// <exception cref="T:System.IO.DriveNotFoundException">An invalid drive was specified. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file described by the current <see cref="T:System.IO.FileInfo" /> object could not be found.-or-The file described by the <paramref name="destinationBackupFileName" /> parameter could not be found. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file.- or -The <paramref name="sourceFileName" /> and <paramref name="destinationFileName" /> parameters specify the same file.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.PlatformNotSupportedException">The operating system is Windows 98 Second Edition or earlier and the files system is not NTFS.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The <paramref name="sourceFileName" /> or <paramref name="destinationFileName" /> parameter specifies a file that is read-only.-or- This operation is not supported on the current platform.-or- Source or destination parameters specify a directory instead of a file.-or- The caller does not have the required permission.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors,
            string sourceusername, string sourcepassword, string sourcedomain,
            string destusername, string destpassword, string destdomain)
        {
            // Replace is a special case.  We might have two connections
            try {
                Connect(destinationFileName, destusername, destpassword, destdomain);
                WrapActionWithConnection(() => SIO.File.Replace(sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors), sourceFileName, sourceusername, sourcepassword, sourcedomain);
            }
            finally {
                Disconnect(destinationFileName, destusername);
            }
        }

        /// <summary>Applies access control list (ACL) entries described by a <see cref="T:System.Security.AccessControl.FileSecurity" /> object to the specified file.</summary>
        /// <param name="path">A file to add or remove access control list (ACL) entries from.</param>
        /// <param name="fileSecurity">A <see cref="T:System.Security.AccessControl.FileSecurity" /> object that describes an ACL entry to apply to the file described by the <paramref name="path" /> parameter.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="T:System.Runtime.InteropServices.SEHException">The <paramref name="path" /> parameter is null.</exception>
        /// <exception cref="T:System.SystemException">The file could not be found.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The <paramref name="path" /> parameter specified a file that is read-only.-or- This operation is not supported on the current platform.-or- The <paramref name="path" /> parameter specified a directory.-or- The caller does not have the required permission.</exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="fileSecurity" /> parameter is null.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void SetAccessControl(string path, FileSecurity fileSecurity, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.SetAccessControl(path, fileSecurity), path, username, password, domain);
        }
        /// <summary>Sets the specified <see cref="T:System.IO.FileAttributes" /> of the file on the specified path.</summary>
        /// <param name="path">The path to the file. </param>
        /// <param name="fileAttributes">A bitwise combination of the enumeration values. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is empty, contains only white spaces, contains invalid characters, or the file attribute is invalid. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file cannot be found.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void SetAttributes(string path, FileAttributes fileAttributes, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.SetAttributes(path, fileAttributes), path, username, password, domain);
        }
        /// <summary>Sets the date and time the file was created.</summary>
        /// <param name="path">The file for which to set the creation date and time information. </param>
        /// <param name="creationTime">A <see cref="T:System.DateTime" /> containing the value to set for the creation date and time of <paramref name="path" />. This value is expressed in local time. </param>
        /// <exception cref="T:System.IO.FileNotFoundException">The specified path was not found. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while performing the operation. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="creationTime" /> specifies a value outside the range of dates, times, or both permitted for this operation. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void SetCreationTime(string path, DateTime creationTime, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.SetCreationTime(path, creationTime), path, username, password, domain);
        }
        /// <summary>Sets the date and time, in coordinated universal time (UTC), that the file was created.</summary>
        /// <param name="path">The file for which to set the creation date and time information. </param>
        /// <param name="creationTimeUtc">A <see cref="T:System.DateTime" /> containing the value to set for the creation date and time of <paramref name="path" />. This value is expressed in UTC time. </param>
        /// <exception cref="T:System.IO.FileNotFoundException">The specified path was not found. </exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while performing the operation. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="creationTime" /> specifies a value outside the range of dates, times, or both permitted for this operation. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.SetCreationTimeUtc(path, creationTimeUtc), path, username, password, domain);
        }

        /// <summary>Sets the date and time the specified file was last accessed.</summary>
        /// <param name="path">The file for which to set the access date and time information. </param>
        /// <param name="lastAccessTime">A <see cref="T:System.DateTime" /> containing the value to set for the last access date and time of <paramref name="path" />. This value is expressed in local time. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The specified path was not found. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="lastAccessTime" /> specifies a value outside the range of dates or times permitted for this operation.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void SetLastAccessTime(string path, DateTime lastAccessTime, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.SetLastAccessTime(path, lastAccessTime), path, username, password, domain);
        }
        /// <summary>Sets the date and time, in coordinated universal time (UTC), that the specified file was last accessed.</summary>
        /// <param name="path">The file for which to set the access date and time information. </param>
        /// <param name="lastAccessTimeUtc">A <see cref="T:System.DateTime" /> containing the value to set for the last access date and time of <paramref name="path" />. This value is expressed in UTC time. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The specified path was not found. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="lastAccessTimeUtc" /> specifies a value outside the range of dates or times permitted for this operation.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.SetLastAccessTimeUtc(path, lastAccessTimeUtc), path, username, password, domain);
        }
        /// <summary>Sets the date and time that the specified file was last written to.</summary>
        /// <param name="path">The file for which to set the date and time information. </param>
        /// <param name="lastWriteTime">A <see cref="T:System.DateTime" /> containing the value to set for the last write date and time of <paramref name="path" />. This value is expressed in local time. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The specified path was not found. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="lastWriteTime" /> specifies a value outside the range of dates or times permitted for this operation.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void SetLastWriteTime(string path, DateTime lastWriteTime, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.SetLastWriteTime(path, lastWriteTime), path, username, password, domain);
        }
        /// <summary>Sets the date and time, in coordinated universal time (UTC), that the specified file was last written to.</summary>
        /// <param name="path">The file for which to set the date and time information. </param>
        /// <param name="lastWriteTimeUtc">A <see cref="T:System.DateTime" /> containing the value to set for the last write date and time of <paramref name="path" />. This value is expressed in UTC time. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The specified path was not found. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///   <paramref name="lastWriteTimeUtc" /> specifies a value outside the range of dates or times permitted for this operation.</exception>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.SetLastWriteTimeUtc(path, lastWriteTimeUtc), path, username, password, domain);
        }
        /// <summary>Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.</summary>
        /// <param name="path">The file to write to. </param>
        /// <param name="bytes">The bytes to write to the file. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null or the byte array is empty. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void WriteAllBytes(string path, byte[] bytes, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.WriteAllBytes(path, bytes), path, username, password, domain);
        }

        /// <summary>Creates a new file, write the specified string array to the file, and then closes the file. </summary>
        /// <param name="path">The file to write to. </param>
        /// <param name="contents">The string array to write to the file. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">Either <paramref name="path" /> or <paramref name="contents" /> is null.  </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void WriteAllLines(string path, string[] contents, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.WriteAllLines(path, contents), path, username, password, domain);
        }
        /// <summary>Creates a new file, writes the specified string array to the file by using the specified encoding, and then closes the file. </summary>
        /// <param name="path">The file to write to. </param>
        /// <param name="contents">The string array to write to the file. </param>
        /// <param name="encoding">An <see cref="T:System.Text.Encoding" /> object that represents the character encoding applied to the string array.</param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">Either <paramref name="path" /> or <paramref name="contents" /> is null.  </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void WriteAllLines(string path, string[] contents, Encoding encoding, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.WriteAllLines(path, contents, encoding), path, username, password, domain);
        }

        /// <summary>Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.</summary>
        /// <param name="path">The file to write to. </param>
        /// <param name="contents">The string to write to the file. </param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null or <paramref name="contents" /> is empty.  </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void WriteAllText(string path, string contents, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.WriteAllText(path, contents), path, username, password, domain);
        }

        /// <summary>Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.</summary>
        /// <param name="path">The file to write to. </param>
        /// <param name="contents">The string to write to the file. </param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="path" /> is null or <paramref name="contents" /> is empty. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="T:System.UnauthorizedAccessException">
        ///   <paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file specified in <paramref name="path" /> was not found. </exception>
        /// <exception cref="T:System.NotSupportedException">
        ///   <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void WriteAllText(string path, string contents, Encoding encoding, string username, string password, string domain)
        {
            WrapActionWithConnection(() => SIO.File.WriteAllText(path, contents, encoding), path, username, password, domain);
        }

    }
}
