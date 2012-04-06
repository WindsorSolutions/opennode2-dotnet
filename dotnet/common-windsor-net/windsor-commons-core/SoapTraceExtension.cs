using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;

namespace Windsor.Commons.Core
{
    public class SoapTraceExtension : SoapExtension 
	{

		Stream oldStream;
		Stream newStream;
		string filename;

		public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute) 
		{
            return ((SoapTraceExtensionAttribute)attribute).Filename;
		}

		public override object GetInitializer(Type serviceType) 
		{
			return filename.GetType();
		}

		// Receive the filename stored by GetInitializer and store it in a member variable
		// for this specific instance.
		public override void Initialize(object initializer) 
		{
			filename = (string) initializer;
            if (string.IsNullOrEmpty(filename))
            {
                filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SoapContent.txt");
            }
		}


		//  If the SoapMessageStage is such that the SoapRequest or SoapResponse is still in the SOAP 
		//  format to be sent or received over the wire, save it out to filename passed in using the SoapExtensionAttribute
		public override void ProcessMessage(SoapMessage message) 
		{
            using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write))
            {
                StreamWriter w = new StreamWriter(fs);
                w.Write("---------------------------------");
                w.WriteLine("Message in: " + message.Stage.ToString());
                w.WriteLine("Action: " + message.Action);
                w.WriteLine("URL: " + message.Url);
                w.WriteLine(DateTime.Now);
                w.WriteLine();
                w.WriteLine("BEGIN CONTENT---------------------------------");
                w.Flush();
            }
            using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write))
            {

                if (message.Stage == SoapMessageStage.AfterSerialize)
                {
                    // Store the SOAP reponse message in the file.
                    Stream memStream;
                    if (newStream.CanSeek)
                    {
                        memStream = newStream;
                    }
                    else
                    {
                        memStream = new MemoryStream(((MemoryStream)newStream).ToArray());
                    }

                    memStream.Position = 0;
                    CopyStream(memStream, fs);

                    memStream.Position = 0;
                    CopyStream(memStream, oldStream);
                    //output
                }
                else if (message.Stage == SoapMessageStage.BeforeDeserialize)
                {
                    CopyStream(oldStream, newStream);

                    // Store the SOAP request message in the file.
                    newStream.Position = 0;
                    CopyStream(newStream, fs);

                    newStream.Position = 0;
                    //input
                }
            }
            using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write))
            {
                StreamWriter w = new StreamWriter(fs);
                w.WriteLine("END CONTENT---------------------------------");
                w.WriteLine();
                w.Flush();
            }
		}





		// Save the Stream representing the SOAP request or SOAP response into a local memory buffer
		public override Stream ChainStream( Stream stream )
		{
			oldStream = stream;
			newStream = new MemoryStream();
			return newStream;
		}

		

		void CopyStream(Stream from, Stream to) 
		{
			TextReader reader = new StreamReader(from);
			TextWriter writer = new StreamWriter(to);
			writer.WriteLine(reader.ReadToEnd());
			writer.Flush();
		}
        public void WriteOutput()
		{
			newStream.Position = 0;
			FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
			StreamWriter w = new StreamWriter(fs);
			w.WriteLine("---------------------------------- Response at " + DateTime.Now);
			w.Flush();
			CopyStream(newStream, fs);
			fs.Close();
			newStream.Position = 0;
			CopyStream(newStream, oldStream);
		}

		public void WriteInput( )
		{
			CopyStream(oldStream, newStream);
			FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
			StreamWriter w = new StreamWriter(fs);
			w.WriteLine("================================== Request at " + DateTime.Now);
			w.Flush();
			newStream.Position = 0;
			CopyStream(newStream, fs);
			fs.Close();
			newStream.Position = 0;
		}
	}

	[AttributeUsage(AttributeTargets.Method)]
    public class SoapTraceExtensionAttribute : SoapExtensionAttribute 
	{

        private string filename;
		private int priority;

		public override Type ExtensionType 
		{
			get { return typeof(SoapTraceExtension); }
		}

		public override int Priority 
		{
			get { return priority; }
			set { priority = value; }
		}

		public string Filename 
		{
			get { return filename; }
			set { filename = value; }
		}
	}
}
