
namespace EstudandoAutomacao
{
    [SetUpFixture]
    public class TestEnvironmentSetup
    {
        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            await UserLoggedService.InitializeDriversPool();
            Console.WriteLine("Drivers pool inicializado para todos os testes.");
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            UserLoggedService.ClearBrowser();
            Console.WriteLine("Todos os drivers encerrados após os testes.");
        }
    }
}
