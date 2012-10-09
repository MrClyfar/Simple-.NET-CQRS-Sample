namespace CQRS.Commands
{
    using System;

    public class AddSiteCommand : ICommand
    {
        public IContext Context { get; set; }

        public AddSiteCommand(IContext ctx)
        {
            this.Context = ctx;
        }

        public void Execute()
        {
            if (string.IsNullOrWhiteSpace(this.Url))
            {
                throw new ArgumentException("url is empty.");
            }

            var site = new Site { Url = this.Url };

            this.Context.Sites.Add(site);
        }

        public string Url { get; set; }
    }
}