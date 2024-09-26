using EstudandoAutomacao.PageObjects.Pages.Login;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

public class LoginPage2 : BasePage
{
    private By UserName { get; } = By.Name(PageIds2.UsernameFieldId);
    private By Password { get; } = By.Name(PageIds2.PasswordFieldId);
    private By LoginButton { get; } = By.ClassName(PageIds2.LoginButtonId);

    private PageProperties2 _properties;

    public LoginPage2(IWebDriver driver) : base(driver) 
    {
        _properties = GetConfigurationSection(nameof(PageProperties2)).Get<PageProperties2>()!;
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_properties.TimeOut);       
    }

    public void GoToLoginPage()
    {
        GoToUrl(_properties.Url);
    }

    public void EnterUsername()
    {
        EnterText(UserName, _properties.UserName);
    }

    public void EnterPassword()
    {
        EnterText(Password, _properties.Password);
    }

    public void ClickLoginButton()
    {
        ClickButton(LoginButton);
    }

    public bool ValidateIfIsLogged()
    {
        return driver.Url.Contains("/dashboard");
    }
}
