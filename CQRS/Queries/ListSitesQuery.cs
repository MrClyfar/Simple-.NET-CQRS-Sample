namespace CQRS.Queries
{
    using System.Linq;

    public class ListSitesQuery
    {
        public IContext Context { get; set; }

        public ListSitesQuery(IContext context)
        {
            this.Context = context;
        }

        public ListSitesQueryResult Execute(PagingInfo pagingInfo)
        {
            return new ListSitesQueryResult(
                this.Context.Sites
                .Skip((pagingInfo.PageNumber - 1) * pagingInfo.PageSize)
                .Take(pagingInfo.PageSize)
                .ToList());
        }

        public ListSitesQueryResult Execute()
        {
            return new ListSitesQueryResult(this.Context.Sites.ToList());
        }
    }
}