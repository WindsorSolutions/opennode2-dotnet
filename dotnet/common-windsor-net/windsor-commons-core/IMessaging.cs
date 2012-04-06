using System;
using System.IO;
namespace Windsor.Commons.Core
{
    public interface IMessaging
    {
        IMessaging AsHtml();

        /// <summary>
        /// Adds an Attachment to the message
        /// </summary>
        /// <param name="contentStream">The stream to add</param>
        /// <param name="name">Name of attachment</param>
        /// <returns>IMessaging object</returns>
        IMessaging Attach(Stream contentStream, string name);

        /// <summary>
        /// Adds an Attachment to the message
        /// </summary>
        /// <param name="contentStream">The stream to add</param>
        /// <param name="contentType">Content type of the file.  This value can be null</param>
        /// <returns>IMessaging object</returns>
        IMessaging Attach(Stream contentStream, System.Net.Mime.ContentType contentType);

        /// <summary>
        /// Adds an Attachment to the message
        /// </summary>
        /// <param name="filename">The filename to add</param>
        /// <param name="mediaType">The MIME content header of the attachment.  Value can be null</param>
        /// <returns>IMessaging object</returns>
        IMessaging Attach(string filename, string mediaType);

        /// <summary>
        /// Adds an Attachment to the message
        /// </summary>
        /// <param name="filename">The filename to add</param>
        /// <param name="contentType">Content type of the file.  This value can be null</param>
        /// <returns>IMessaging object</returns>
        IMessaging Attach(string filename, System.Net.Mime.ContentType contentType);

        /// <summary>
        /// Adds an Attachment
        /// </summary>
        /// <param name="contentStream">The stream to add</param>
        /// <param name="name">The name of the attachment. Value can be null</param>
        /// <param name="mediaType">The MIME content header of the attachment.  Value can be null</param>
        /// <returns>IMessaging object</returns>
        IMessaging Attach(Stream contentStream, string name, string mediaType);

        /// <summary>
        /// Adds a blind carbon copy to the message
        /// </summary>
        /// <param name="address">Address of bcc</param>
        /// <param name="name">Name of bcc</param>
        /// <returns>IMessaging object</returns>
        IMessaging Bcc(string address, string name);

        /// <summary>
        /// Sets the body of the message
        /// </summary>
        /// <param name="body"></param>
        /// <returns>IMessaging object</returns>
        IMessaging Body(string body);

        /// <summary>
        /// Sets the body of the message
        /// </summary>
        /// <param name="body"></param>
        /// <param name="isHtml">Specifies whether the body is in HTML</param>
        /// <returns>IMessaging object</returns>
        IMessaging Body(string body, bool isHtml = true);

        /// <summary>
        /// Adds a carbon copy to the message
        /// </summary>
        /// <param name="address">Address of cc</param>
        /// <param name="name">Name of cc</param>
        /// <returns>IMessaging object</returns>
        IMessaging CC(string address, string name);

        /// <summary>
        /// Sets the message as high priority
        /// </summary>
        /// <returns>IMessaging object</returns>
        IMessaging HighPriority();

        /// <summary>
        /// Sets the message to low priority
        /// </summary>
        /// <returns>IMessaging object</returns>
        IMessaging LowPriority();

        /// <summary>
        /// Sets the reply to of the message
        /// </summary>
        /// <param name="address">Address of reply to</param>
        /// <returns>IMessaging object</returns>
        IMessaging ReplyTo(string address);

        /// <summary>
        /// Sets the reply to of the message
        /// </summary>
        /// <param name="address">Address of reply to</param>
        /// <param name="name">Name of the reply to</param>
        /// <returns>IMessaging object</returns>
        IMessaging ReplyTo(string address, string name);

        /// <summary>
        /// Sends the message
        /// </summary>
        /// <returns>IMessaging object</returns>
        IMessaging Send();

        /// <summary>
        /// Sets the subject of the message
        /// </summary>
        /// <param name="subject"></param>
        /// <returns>IMessaging object</returns>
        IMessaging Subject(string subject);

        /// <summary>
        /// Adds an address to the to list
        /// </summary>
        /// <param name="address"></param>
        /// <returns>IMessaging object</returns>
        IMessaging To(string address);

        /// <summary>
        /// Adds an address to the to list
        /// </summary>
        /// <param name="address"></param>
        /// <param name="name"></param>
        /// <returns>IMessaging object</returns>
        IMessaging To(string address, string name);

        /// <summary>
        /// Sets the body of the message through the use of a template and model object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="template"></param>
        /// <param name="model">model for the template.  This value may be null</param>
        /// <returns>IMessaging object</returns>
        IMessaging UsingTemplate<T>(string template, T model);

        /// <summary>
        /// Sets the body of the message through the use of a template and model object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="template"></param>
        /// <param name="model">model for the template.  This value may be null</param>
        /// <param name="isHtml"></param>
        /// <returns>IMessaging object</returns>
        IMessaging UsingTemplate<T>(string template, T model, bool isHtml);

        /// <summary>
        /// Sets the template engine.  The Engine will parse the template
        /// </summary>
        /// <param name="engine"></param>
        /// <returns>IMessaging object</returns>
        IMessaging UsingTemplateEngine(ITemplateEngine engine);

        /// <summary>
        /// Sets the body of the message through the use of a template and model object.  
        /// The template name specified will be passed to the resolver to gather the actual template text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <param name="model"></param>
        /// <returns>IMessaging object</returns>
        IMessaging UsingNamedTemplate<T>(string templateName, T model);

                /// <summary>
        /// Sets the body of the message through the use of a template and model object.  
        /// The template name specified will be passed to the resolver to gather the actual template text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <param name="model"></param>
        /// <returns>IMessaging object</returns>
        IMessaging UsingNamedTemplate<T>(string templateName, T model, bool? isHtml);

        /// <summary>
        /// Sets the template resolver.  The resolver will locate the template (typically by searching the filesystem)
        /// </summary>
        /// <param name="resolver"></param>
        /// <returns>IMessaging object</returns>
        IMessaging UsingTemplateResolver(ITemplateResolver resolver);

        /// <summary>
        /// Sets credentials for the sending user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>IMessaging object</returns>
        IMessaging WithCredentials(string username, string password);

        /// <summary>
        /// Sets credentials for the sending user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <returns>IMessaging object</returns>
        IMessaging WithCredentials(string username, string password, string domain);
    }
}
