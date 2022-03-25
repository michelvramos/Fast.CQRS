using System;
using CQRSCore.Implementation;

namespace TestProject.commands
{
    public sealed class TestAsyncIOCommand : Command
    {
        public string Url { get; set; }
        public override void Validate()
        {
            if (!Uri.TryCreate(Url, UriKind.Absolute, out _))
            {
                AddNotification(nameof(Url), "Not a valid URL.");
            }
        }
    }
}
