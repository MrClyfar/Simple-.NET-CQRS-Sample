namespace CQRS.Queries
{
    using System.Collections.Generic;

    public class ListSitesQueryResult
    {
        public ListSitesQueryResult(IList<Site> sites)
        {
            this.Sites = sites;
        }

        public IList<Site> Sites { get; private set; }
    }
}