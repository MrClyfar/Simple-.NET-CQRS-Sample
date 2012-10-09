namespace CQRS.Tests.Unit
{
    using System;
    using CQRS.Commands;
    using CQRS.Queries;
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
    }
}
