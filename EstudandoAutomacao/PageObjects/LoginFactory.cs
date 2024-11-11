using OpenQA.Selenium;

namespace EstudandoAutomacao.PageObjects
{
    public class LoginFactory
    {       
        public ILoginFactory ReturnInstance(IWebDriver webDriver, LoginType loginType)
        {
            switch (loginType)
            {
                case LoginType.LoginPage:
                    return new LoginPage(webDriver);
                default: throw new ArgumentException("");
            }
        }
    }
}