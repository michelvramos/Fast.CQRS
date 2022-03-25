
using CQRSCore.Implementation;

namespace TestProject.commands
{
    public sealed class TestAsyncCpuCommand : Command
    {

        public int MaxPrime { get; set; }
        public override void Validate()
        {
            if (MaxPrime < 1)
            {
                AddNotification(nameof(MaxPrime), "Must be a positive integer greater then 0.");
            }

            if (MaxPrime > 2000000000)
            {
                AddNotification(nameof(MaxPrime), "Must be less than 2000000000.");
            }
        }
    }
}
