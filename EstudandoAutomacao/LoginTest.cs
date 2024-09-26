using OpenQA.Selenium.Chrome;

namespace EstudandoAutomacao
{
    public class Tests
    {
        LoginPage _loginPage;
        LoginPage2 _loginPage2;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage(new ChromeDriver());
            _loginPage2 = new LoginPage2(new ChromeDriver());
        }

        [TearDown]
        public void TearDown()
        {
            _loginPage?.Dispose();
            _loginPage2?.Dispose();
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

        [Test]
        public void LogInPage2()
        {
            //Arrange
            _loginPage2.GoToLoginPage();

            //Act
            _loginPage2.EnterUsername();
            _loginPage2.EnterPassword();
            _loginPage2.ClickLoginButton();

            //Assert
            Assert.IsTrue(_loginPage2.ValidateIfIsLogged(), "Redirecionamento falhou");
        }
    }
}