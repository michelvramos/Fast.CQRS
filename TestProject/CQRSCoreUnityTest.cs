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
            Assert.IsNotNull(ret, "Ret is null");
            Assert.IsTrue(ret.Success, "Command not successfull");
            Assert.IsInstanceOfType(ret.Data, typeof(bool), "Expected type mismatch");
            Assert.IsTrue((bool)ret.Data == true, "data missmatch");
        }

        [TestMethod]
        [DataRow("https://www.microsoft.com")]
        [DataRow("https://www.google.com")]
        [DataRow("https://www.terra.com.br")]
        public async Task TestHandlerIO(string url)
        {
            ICommandResult ret = await handler.HandleAsync(new TestAsyncIOCommand { Url = url}, cancellationToken);
            Assert.IsNotNull(ret, "Ret is null");
            Assert.IsTrue(ret.Success, "Command not successfull");
            Assert.IsInstanceOfType(ret.Data, typeof(string), "Expected type mismatch");
            Assert.IsTrue(ret.Data.ToString().Contains("!DOCTYPE", System.StringComparison.InvariantCultureIgnoreCase), "data missmatch");
        }

        [TestMethod]
        public async Task TestHandlerCPU()
        {
            ICommandResult ret = await handler.HandleAsync(new TestAsyncCpuCommand { MaxPrime = 10000000 }, cancellationToken);
            Assert.IsNotNull(ret,"Ret is null");
            Assert.IsTrue(ret.Success, "Command not successfull");
            Assert.IsInstanceOfType(ret.Data, typeof(int), "Expected type mismatch");
            Assert.IsTrue((int)ret.Data == 664579, "data missmatch");
        }
    }
}
