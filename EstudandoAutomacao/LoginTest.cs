using OpenQA.Selenium.Chrome;

namespace EstudandoAutomacao
{
    public class Tests
    {
        LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage(new ChromeDriver());
        }

        [TearDown]
        public void TearDown()
        {
            _loginPage.Dispose();
        }

        [Test]
        public void LogInPage()
        {
            //Arrange
            _loginPage.GoToLoginPage();       
            
            //Act
            _loginPage.EnterUsername();
            _loginPage.EnterPassword();
            _loginPage.ClickLoginButton();

            //Assert
            Assert.IsTrue(_loginPage.ValidateIfIsLogged(), "Redirecionamento falhou");
        }
    }
}