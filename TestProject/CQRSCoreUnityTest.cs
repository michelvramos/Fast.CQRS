using System.Threading;
using System.Threading.Tasks;
using CQRSCore.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.commands;
using TestProject.handlers;

namespace TestProject
{
    [TestClass]
    public class CQRSCoreUnityTest
    {
        static TestHandlerCore handler;
        static CancellationToken cancellationToken;
        static TestContext context;

        [ClassInitialize]
        public static void Initialize(TestContext _context)
        {
            context = _context;
            handler = new TestHandlerCore();
            cancellationToken = new CancellationToken();
        }

        [TestMethod]
        public void TestHandler()
        {
            ICommandResult ret = handler.Handle(new TestHandleCommand { Name = "John Doo", Age = 42 }, cancellationToken);
            Assert.IsTrue(ret.Success, "Command not successfull");
            Assert.IsInstanceOfType(ret.Data, typeof(bool), "Expected type mismatch");
            Assert.IsTrue((bool)ret.Data == true, "data missmatch");
        }

        [TestMethod]
        public async Task TestHandlerIO()
        {
            ICommandResult ret = await handler.HandleAsync(new TestAsyncIOCommand { Url = "https://www.microsoft.com" }, cancellationToken);
            Assert.IsTrue(ret.Success, "Command not successfull");
            Assert.IsInstanceOfType(ret.Data, typeof(string), "Expected type mismatch");
            Assert.IsTrue(ret.Data.ToString().Contains("!DOCTYPE"), "data missmatch");
            context.WriteLine(ret.Data.ToString());
        }

        [TestMethod]
        public async Task TestHandlerCPU()
        {
            ICommandResult ret = await handler.HandleAsync(new TestAsyncCpuCommand { MaxPrime = 10000000 }, cancellationToken);
            Assert.IsTrue(ret.Success, "Command not successfull");
            Assert.IsInstanceOfType(ret.Data, typeof(int), "Expected type mismatch");
            Assert.IsTrue((int)ret.Data == 664579, "data missmatch");
        }
    }
}
