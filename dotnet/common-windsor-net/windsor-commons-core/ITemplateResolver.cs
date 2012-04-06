namespace Windsor.Commons.Core
{
    public interface ITemplateResolver
    {
        /// <summary>
        /// Resolves the template name to the corresponding string (usually contents of a file)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string Resolve(string name);
    }
}
