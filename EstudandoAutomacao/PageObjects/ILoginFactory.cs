using OpenQA.Selenium;

namespace EstudandoAutomacao.PageObjects
{
    public interface ILoginFactory
    {
        public void LoadUsers();
        public void ReturnToHomePage(IWebDriver webDriver);
    }
}