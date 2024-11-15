﻿using EstudandoAutomacao.PageObjects;
using EstudandoAutomacao.PageObjects.Pages.Login;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;


public class LoginPage : BasePage, ILoginFactory
{
    private By UserName { get; } = By.Name(PageIds.UsernameFieldId);
    private By Password { get; } = By.Name(PageIds.PasswordFieldId);
    private By LoginButton { get; } = By.ClassName(PageIds.LoginButtonId);

    private PageProperties _properties;

    public LoginPage(IWebDriver driver) : base(driver)
    {
        _properties = GetConfigurationSection(nameof(PageProperties)).Get<PageProperties>()!;
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

    public void LoadUsers()
    {
        GoToLoginPage();
        EnterUsername();
        EnterPassword();
        ClickLoginButton();
    }

    public void ReturnToHomePage(IWebDriver webDriver)
    {
        webDriver.Navigate().GoToUrl("https://www.google.com.br/");
    }
}
