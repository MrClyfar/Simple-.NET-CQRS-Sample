namespace CQRS
{
    using System.Collections.Generic;

    public interface IContext
    {
        IList<Site> Sites { get; set; }
    }
}