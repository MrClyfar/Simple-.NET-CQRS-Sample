namespace CQRS
{
    using System.Collections.Generic;

    public class Context : IContext
    {
        public Context()
        {
            this.Sites = new List<Site>();
        }

        public IList<Site> Sites { get; set; }
    }
}