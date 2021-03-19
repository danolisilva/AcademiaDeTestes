using AcademiaDeTestes.Abstracoes;
using AcademiaDeTestes.Models;
using AcademiaDeTestes.Pages;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaDeTestes.Tests
{
    public class segundoTest : SuperClass
    {
        private HomePage_Model home;
        public segundoTest() : base ()
        {
            home = new HomePage_Model(this.driver);
        }


        [Test]
        public void primeiro()
        {

            home.navegaCriaUsuario();

            home.criaUsuario("Teste", "teste", "teste@teste.com");

            driver.Dispose();
        }
    }
}
