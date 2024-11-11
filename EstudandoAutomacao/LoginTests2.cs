using EstudandoAutomacao.PageObjects.Pages;

namespace EstudandoAutomacao
{
    [Parallelizable(scope: ParallelScope.Children)]
    public class Tests2 
    {
        [OneTimeSetUp]
        public async Task SetupAsync()
        {

        }

        [OneTimeTearDown]
        public void TearDown()
        {

        }

        [Test]
        public async Task LogInPage1Async()
        {
            using (var driverWrapper = await UserLoggedService.GetAvailableDriver())
            {
                var driver = driverWrapper._driver;
                var _loginPage2 = new LoginPage2(driver);

                //Arrange
                _loginPage2.GoToLoginPage();

                //Act         
                Thread.Sleep(1000);
                //Assert
                Assert.IsTrue(_loginPage2.ValidateIfIsLogged(), "Redirecionamento falhou");
            }
        }

        [Test]
        public async Task LogInPage2Async()
        {
            using (var driverWrapper = await UserLoggedService.GetAvailableDriver())
            {
                var driver = driverWrapper._driver;
                var _loginPage2 = new LoginPage2(driver);

                //Arrange
                _loginPage2.GoToLoginPage();

                //Act         
                Thread.Sleep(1000);
                //Assert
                Assert.IsTrue(_loginPage2.ValidateIfIsLogged(), "Redirecionamento falhou");
            }
        }

        [Test]
        public async Task LogInPage5Async()
        {
            using (var driverWrapper = await UserLoggedService.GetAvailableDriver())
            {
                var driver = driverWrapper._driver;
                var _loginPage2 = new LoginPage2(driver);

                //Arrange
                _loginPage2.GoToLoginPage();

                //Act         
                Thread.Sleep(1000);
                //Assert
                Assert.IsTrue(_loginPage2.ValidateIfIsLogged(), "Redirecionamento falhou");
            }
        }
    }
}