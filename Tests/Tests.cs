using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Text;

namespace AcademiaDeTestes.Tests
{
    class Tests
    {
        private IWebDriver driver;


        public void CriarUsuario(string ANome, string Asobrenome)
        {
            Random numAleatorio = new Random();
            int valor = numAleatorio.Next(100000);

            driver.FindElement(By.XPath("//a[@class='login']")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys(valor.ToString() + "@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys(ANome);
            driver.FindElement(By.Id("customer_lastname")).SendKeys(Asobrenome);
            driver.FindElement(By.Id("passwd")).SendKeys("12345");
            driver.FindElement(By.Id("days")).Click();
            driver.FindElement(By.XPath("//select[@id='days']/option[@value='3']")).Click();
            driver.FindElement(By.Id("months")).Click();
            driver.FindElement(By.XPath("//select[@id='months']/option[@value='9']")).Click();
            driver.FindElement(By.Id("years")).Click();
            driver.FindElement(By.XPath("//select[@id='years']/option[@value='1981']")).Click();
            driver.FindElement(By.Id("newsletter")).Click();
            driver.FindElement(By.Id("optin")).Click();

            //endereço
            driver.FindElement(By.Id("company")).SendKeys("NONE");
            driver.FindElement(By.Id("address1")).SendKeys("Rua do norte");
            driver.FindElement(By.Id("address2")).SendKeys("NONE");
            driver.FindElement(By.Id("city")).SendKeys("98765");
            driver.FindElement(By.Id("id_state")).Click();
            driver.FindElement(By.XPath("//select[@id='id_state']/option[@value='1']")).Click();
            driver.FindElement(By.Id("postcode")).SendKeys("12345");
            driver.FindElement(By.Id("id_country")).Click();
            driver.FindElement(By.XPath("//select[@id='id_country']/option[@value='21']")).Click();
            driver.FindElement(By.Id("other")).SendKeys("NONE");
            driver.FindElement(By.Id("phone")).SendKeys("99999-9999");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("99999-9999");
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("Endereço Principal");
            driver.FindElement(By.Id("submitAccount")).Click();

            Assert.IsTrue(driver.FindElement(By.XPath("//h1[text()='My account']")).Displayed);
        }

        public void InserirCompraCarrinho()
        {
            driver.FindElement(By.Id("search_query_top")).SendKeys("Faded Short Sleeve T-shirts");
            driver.FindElement(By.Name("submit_search")).Click();
            driver.FindElement(By.XPath("//ul[@class='product_list grid row']/li[1]")).Click();
            driver.FindElement(By.Id("add_to_cart")).Click();
            driver.FindElement(By.XPath("//div[@class='button-container']/a")).Click();

            Assert.IsTrue(driver.FindElement(By.Id("cart_title")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='1 Product']")).Displayed);
        }

        public void RealizarLogin(string AEmail, string ASenha)
        {
            driver.FindElement(By.XPath("//a[@class='login']")).Click();
            driver.FindElement(By.Id("email")).SendKeys(AEmail);
            driver.FindElement(By.Id("passwd")).SendKeys(ASenha);
            driver.FindElement(By.Id("SubmitLogin")).Click();

            Assert.IsTrue(driver.FindElement(By.XPath("//h1[text()='My account']")).Displayed);
        }

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [TearDown]
        public void teardown()
        {
            driver.Dispose();
        }

        [Test]
        public void Teste_1()  //Abrir um item da Home Page;
        {
            driver.FindElement(By.XPath("(//div[@class='tab-content']//img)[1]")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='fancybox-overlay fancybox-overlay-fixed']")).Displayed);
        }

        [Test]
        public void Teste_2() //Realizar uma busca por algum item e abrir um item;
        {
            driver.FindElement(By.Id("search_query_top")).SendKeys("Blouse");
            driver.FindElement(By.Name("submit_search")).Click();
            driver.FindElement(By.XPath("//img[@title='Blouse']")).Click();

            Assert.IsTrue(driver.FindElement(By.XPath("//h1[text()='Blouse']")).Displayed);
        }

        [Test]
        public void Teste_3() //Realizar a navegação por um departamento e abrir um item;
        {
            driver.FindElement(By.XPath("//div[@id='block_top_menu']//a[@title='Women']")).Click();
            driver.FindElement(By.XPath("//div[@id='subcategories']//a[@title='Dresses']")).Click();
            driver.FindElement(By.XPath("//div[@id='subcategories']//a[@title='Summer Dresses']")).Click();
            driver.FindElement(By.XPath("(//img[@title='Printed Summer Dress'])[1]")).Click();

            driver.PageSource.Contains("Model demo_5");
        }

        [Test]
        public void Teste_4() //Abrir um item e adicionar no carrinho;
        {
            InserirCompraCarrinho();
        }

        [Test]
        public void Teste_5() //Criar usuário;
        {
            CriarUsuario("Daniel", "Silva");

        }

        [Test]
        public void Teste_6() //Realizar uma compra completa de um produto;
        {
            RealizarLogin("danolisilva@gmail.com", "12345");
            InserirCompraCarrinho();
            driver.FindElement(By.XPath("//span[text()='Proceed to checkout']")).Click();
            driver.FindElement(By.Name("processAddress")).Click();
            driver.FindElement(By.Id("cgv")).Click();
            driver.FindElement(By.Name("processCarrier")).Click();
            driver.FindElement(By.XPath("//a[@title='Pay by bank wire']")).Click();
            driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();

            driver.PageSource.Contains("Your order on My Store is complete.");
        }
    }

}
