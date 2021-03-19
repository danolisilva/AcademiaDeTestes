using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace AcademiaDeTestes.Abstracoes
{
    public class SuperClass : IDisposable
    {
        protected IWebDriver driver { get; }
        public SuperClass()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/treinamento/home");
        }

        public void Dispose()
        {
            driver?.Quit();
            driver?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
