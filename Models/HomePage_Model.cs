using AcademiaDeTestes.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaDeTestes.Models
{
    public class HomePage_Model
    {
        private IWebDriver driver;
        private HomePage_Page home;
        public HomePage_Model(IWebDriver superDriver)
        {
            driver = superDriver;
            home = new HomePage_Page(driver);
        }

        

        public void navegaCriaUsuario()
        {
            Assert.IsTrue(home.linkFormulario().Displayed);
            home.linkFormulario().Click();
            home.linkCriarUsuario().Click();
        }

        public void criaUsuario(String sNome, String sSobrenome, String sEmail)
        {
            Assert.IsTrue(home.txtNome().Displayed);
            home.txtNome().SendKeys(sNome);
            home.txtSobrenome().SendKeys(sSobrenome);
            home.txtEmail().SendKeys(sEmail);
            home.btnSubmit().Click();
        }
    }
}
