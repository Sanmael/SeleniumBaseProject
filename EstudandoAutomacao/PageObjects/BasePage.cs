using EstudandoAutomacao.PageObjects.Interfaces;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

public class BasePage : IPage, IDisposable
{
    protected readonly IWebDriver driver;
    protected readonly IConfiguration configuration;

    public BasePage(IWebDriver driver, [CallerFilePath] string callerPath = "")
    {
        string directoryPath = Regex.Replace(callerPath, @"[^\\]+$", "");

        var builder = new ConfigurationBuilder()
           .SetBasePath(directoryPath)
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        configuration = builder.Build();

        this.driver = driver;
        this.configuration = builder.Build();
    }

    public IConfigurationSection GetConfigurationSection(string key)
    {
        return configuration.GetSection(key);
    }

    public void GoToUrl(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    public void ClickButton(By selector)
    {
        driver.FindElement(selector).Click();
    }

    public void EnterText(By selector, string text)
    {
        driver.FindElement(selector).SendKeys(text);
    }

    public string GetElementText(By selector)
    {
        return driver.FindElement(selector).Text;
    }

    public void Dispose()
    {
        driver.Dispose();
    }
}
