using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaDeTestes.Pages
{
    public class HomePage_Page
    {
        private IWebDriver driver;
        public HomePage_Page(IWebDriver superDriver)
        {
            driver = superDriver;
        }

        public IWebElement linkFormulario()
        {
            return driver.FindElement(By.LinkText("Formulário"));
        }

        public IWebElement linkCriarUsuario()
        {
            return driver.FindElement(By.XPath("//a[text()='Criar Usuários']"));
        }

        public IWebElement txtNome()
        {
            return driver.FindElement(By.Id("user_name"));
        }

        public IWebElement txtSobrenome()
        {
           return driver.FindElement(By.Id("user_lastname"));
        }

        public IWebElement txtEmail()
        {
            return driver.FindElement(By.Id("user_email"));
        }

        public IWebElement btnSubmit()
        {
            return driver.FindElement(By.Name("commit"));
        }


     
    }
}
