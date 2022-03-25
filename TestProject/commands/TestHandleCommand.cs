
using CQRSCore.Implementation;

namespace TestProject.commands
{
    public sealed class TestHandleCommand : Command
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                AddNotification(nameof(Name), "Name can't be null");
            }

            if (Age < 1)
            {
                AddNotification(nameof(Age), "Age must be a positive integer");
            }
        }
    }
}
