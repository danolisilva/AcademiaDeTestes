using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaDeTestes
{
    public class primeiroTeste
    {
        public primeiroTeste()
        {

        }

        [Test]
        public void primeiro()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/treinamento/home");

            //driver.FindElement(By.XPath("//a[text()='Formulário']")).Click();
            Assert.IsTrue(driver.FindElement(By.LinkText("Formulário")).Displayed);
            driver.FindElement(By.LinkText("Formulário")).Click();

            driver.FindElement(By.XPath("//a[text()='Criar Usuários']")).Click();
            Assert.IsTrue(driver.FindElement(By.Id("user_name")).Displayed);
            driver.FindElement(By.Id("user_name")).SendKeys("Teste");
            driver.FindElement(By.Id("user_lastname")).SendKeys("Teste");
            driver.FindElement(By.Id("user_email")).SendKeys("teste@teste.com");
            driver.FindElement(By.Name("commit")).Click();


            driver.Dispose();
        }
    }
}
