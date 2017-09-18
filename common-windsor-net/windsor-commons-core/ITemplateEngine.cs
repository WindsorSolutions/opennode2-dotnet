namespace Windsor.Commons.Core
{
    public interface ITemplateEngine
    {
        /// <summary>
        /// Parses a template using the supplied model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="template"></param>
        /// <param name="model"></param>
        /// <returns>Parsed template</returns>
        string Parse<T>(string template, T model);
    }
}
