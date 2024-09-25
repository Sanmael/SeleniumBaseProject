using OpenQA.Selenium;

namespace EstudandoAutomacao.PageObjects.Interfaces
{
    public interface IPage
    {
        void GoToUrl(string url);
        void ClickButton(By selector);
        void EnterText(By selector, string text);
        string GetElementText(By selector);
    }
}