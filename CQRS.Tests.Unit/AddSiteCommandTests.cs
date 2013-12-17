namespace CQRS.Tests.Unit
{
    using Commands;
    using FizzWare.NBuilder;
    using Moq;
    using Queries;
    using System;
    using Xunit;

    public class AddSiteCommandTests
    {
        [Fact]
        public void AddingNewSiteResultsInOneSiteReturned()
        {
            // Arrange.
            var ctx = new Context();
            
            var sut = new AddSiteCommand(ctx) { Url = "AnyUrl" };

            // Act.
            sut.Execute();

            var query = new ListSitesQuery(ctx);

            var result = query.Execute();

            // Assert.
            Assert.Equal(1, result.Sites.Count);
        }

        [Fact]
        public void NoSiteShouldBeReturnedGivenDefaultContext()
        {
            // Arrange.
            var ctx = new Context();

            // Act.
            var query = new ListSitesQuery(ctx);

            var result = query.Execute();

            // Assert.
            Assert.Equal(0, result.Sites.Count);
        }

        [Fact]
        public void ExceptionThrownIfUrlNotGiven()
        {
            // Arrange.
            var ctx = new Context();

            var sut = new AddSiteCommand(ctx);

            // Act and Assert.
            Assert.Throws<ArgumentException>(() => sut.Execute());
        }

        [Fact]
        public void PassingPagingInfoReturnsFiveSites()
        {
            // Arrange.
            var sites = Builder<Site>.CreateListOfSize(10).Build();

            var ctx = new Mock<IContext>();

            ctx.Setup(m => m.Sites).Returns(sites);

            // Act.
            var pagingInfo = new PagingInfo { PageSize = 5, PageNumber = 1 };

            // Act.
            var sut = new ListSitesQuery(ctx.Object);

            var result = sut.Execute(pagingInfo);

            // Assert.
            Assert.Equal(5, result.Sites.Count);
        }

        [Fact]
        public void PassingPagingInfoReturnsTwoSites()
        {
            // Arrange.
            var sites = Builder<Site>.CreateListOfSize(22).Build();

            var ctx = new Mock<IContext>();

            ctx.Setup(m => m.Sites).Returns(sites);

            // Act.
            var pagingInfo = new PagingInfo { PageSize = 5, PageNumber = 4 };

            // Act.
            var sut = new ListSitesQuery(ctx.Object);

            var result = sut.Execute(pagingInfo);

            // Assert.
            Assert.Equal(5, result.Sites.Count);
        }

        [Fact]
        public void PassingPagingInfoReturnsOneSite()
        {
            // Arrange.
            var sites = Builder<Site>.CreateListOfSize(1).Build();

            var ctx = new Mock<IContext>();

            ctx.Setup(m => m.Sites).Returns(sites);

            // Act.
            var pagingInfo = new PagingInfo { PageSize = 1, PageNumber = 1 };

            // Act.
            var sut = new ListSitesQuery(ctx.Object);

            var result = sut.Execute(pagingInfo);

            // Assert.
            Assert.Equal(1, result.Sites.Count);
        }
    }
}
