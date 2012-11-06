﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.IO;
using System.Text;
using System.Reflection;
using System.Data.Common;

namespace Windsor.Commons.Core
{
    public static class CsvExporter
    {
        public static string ExportCsvToTempFile(IQueryable queryable, string baseExportFileName)
        {
            string tempFilePath = GetTempCsvFilePath(baseExportFileName);

            ExportCsv(queryable, tempFilePath);

            return tempFilePath;
        }
        public static void ExportCsv(IQueryable queryable, string filePath)
        {
            FileUtils.SafeDeleteFile(filePath);

            using (FileStream fs = File.OpenWrite(filePath))
            {
                ExportCsv(queryable, fs);
            }
        }
        public static void ExportCsv(IQueryable queryable, Stream stream)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8, 1024 * 64))
                {
                    Type exportType = queryable.ElementType;
                    List<PropertyInfo> properties = ReflectionUtils.GetPublicInstanceProperties(exportType);
                    bool isFirst = true;
                    foreach (PropertyInfo property in properties)
                    {
                        ExportCsvValue(property.Name, writer, ref isFirst);
                    }
                    writer.WriteLine();
                    foreach (object obj in queryable)
                    {
                        isFirst = true;
                        foreach (PropertyInfo property in properties)
                        {
                            var value = property.GetValue(obj, null);
                            ExportCsvValue(value, writer, ref isFirst);
                        }
                        writer.WriteLine();
                    }
                    writer.Flush();
                }
            }
            catch (Exception)
            {
                DebugUtils.CheckDebuggerBreak();
                throw;
            }
        }
        public static string ExportCsvToTempFile(ICollection<string> columnNames, DbDataReader reader, string baseExportFileName)
        {
            string tempFilePath = GetTempCsvFilePath(baseExportFileName);

            ExportCsv(columnNames, reader, tempFilePath);

            return tempFilePath;
        }
        public static void ExportCsv(ICollection<string> columnNames, DbDataReader reader, string filePath)
        {
            FileUtils.SafeDeleteFile(filePath);

            using (FileStream fs = File.OpenWrite(filePath))
            {
                ExportCsv(columnNames, reader, fs);
            }
        }
        public static void ExportCsv(ICollection<string> columnNames, DbDataReader reader, Stream stream)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8, 1024 * 64))
                {
                    bool isFirst = true;
                    foreach (string columnName in columnNames)
                    {
                        ExportCsvValue(columnName, writer, ref isFirst);
                    }
                    writer.WriteLine();
                    object[] fieldValues = new object[columnNames.Count];
                    while (reader.Read())
                    {
                        reader.GetValues(fieldValues);
                        isFirst = true;
                        foreach (object rowValue in fieldValues)
                        {
                            ExportCsvValue(rowValue, writer, ref isFirst);
                        }
                        writer.WriteLine();
                    }
                    writer.Flush();
                }
            }
            catch (Exception)
            {
                DebugUtils.CheckDebuggerBreak();
                throw;
            }
        }
        public static string GetTempCsvFilePath(string baseExportFileName)
        {
            string parentFolderPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(parentFolderPath);
            string fileName = FileUtils.ReplaceInvalidFilenameChars(baseExportFileName, '_') + DateTime.Now.ToString("-yyyy-MM-dd-HH-mm-ss") + ".csv";
            string tempFilePath = Path.Combine(parentFolderPath, fileName);
            return tempFilePath;
        }
        public static void ExportCsvValue(object value, StreamWriter writer, ref bool isFirst)
        {
            string valueString;
            if (value == null)
            {
                valueString = string.Empty;
            }
            else
            {
                valueString = value.ToString();
                bool needsWrapping = false;
                if (valueString.Contains('\"'))
                {
                    valueString = valueString.Replace("\"", "\"\"");
                    needsWrapping = true;
                }
                if (!needsWrapping)
                {
                    foreach (char charValue in valueString)
                    {
                        bool invalidChar = (charValue == ',') ||
                            !(char.IsLetterOrDigit(charValue) || (charValue == ' ') || char.IsPunctuation(charValue) || char.IsSymbol(charValue));
                        if ( invalidChar )
                        {
                            needsWrapping = true;
                            break;
                        }
                    }
                }
                if (needsWrapping)
                {
                    valueString = "\"" + valueString + "\"";
                }
            }
            if (isFirst)
            {
                writer.Write(valueString);
                isFirst = false;
            }
            else
            {
                writer.Write("," + valueString);
            }
        }
    }
}