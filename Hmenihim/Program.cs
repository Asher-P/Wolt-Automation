using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Hmenihim
{
    class Program
    {
        static void Main(string[] args)
        {
            //Change the Path according your chrome User Data location
            string chromeUserDataPath = "C:/Users/asher.p/AppData/Local/Google/Chrome/User Data";
            
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-web-security");
            options.AddArgument($"--user-data-dir={chromeUserDataPath}");
            options.AddArgument("--allow-running-insecure-content");
            var Driver = new ChromeDriver(Path.Combine(Directory.GetCurrentDirectory(), "../../../"), options);
            //Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://wolt.com/he/");

            try
            {
                try
                {
                    IWebElement cookies = Driver.FindElement(By.CssSelector("div[class='Button__Content-sc-a3fg5q-3 cCtovS']"));
                    cookies.Click();
                }
                catch (Exception)
                {
                }
                Thread.Sleep(2000);
                IWebElement loginButton = Driver.FindElement(By.CssSelector("button[class='UserStatus-module__button___qtP1R']"));
                loginButton.Click();
                Thread.Sleep(2000);

                IWebElement googleLogin = Driver.FindElement(By.CssSelector("a[class='StepMethodSelect-module__googleLink___KU6Ye']"));
                //IWebElement googleLogin = Driver.FindElement(By.CssSelector("#app > div > div > div.MainContentWrapper-module__modalWrapper___2tc-5 > div > div.ModalWithAnimation-module__root___EuTXD > div > div > div.StateMachine-module__stepContainer___1D-5Y > div > div.Step-module__contentContainer___3ww-8 > div > button.Button-module__button___QloF7.ButtonJankless-module__button___3gp6D.StepMethodSelect-module__googleButton___2ZDxk.Button-module__outline___2ypX6"));
                googleLogin.Click();
                Thread.Sleep(2000);
              
            }
            catch (Exception)
            {
                Console.WriteLine("Logged In");
                IWebElement search = Driver.FindElement(By.CssSelector("input[class='SearchInput__Input-sc-1up9knj-2 ftBRqC']"));
                search.SendKeys("gift card");
                Thread.Sleep(1500);
                List<IWebElement> searchResults = new List<IWebElement>(Driver.FindElements(By.CssSelector("a[class='SearchResultItem__RootLink-sc-wb236u-9 dASHKL']")));
                var GiftCard = searchResults.Find(r => r.FindElement(By.CssSelector("div[class='SearchResultItem__Name-sc-wb236u-4 fckXxu']")).Text == "Wolt Gift Card");
                GiftCard.Click();
                Thread.Sleep(2500);
                var giftCards = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class='MenuItem-module__itemContainer____1T8k']")));
                IWebElement GiftCard40 = giftCards.Find(gc => gc.FindElement(By.CssSelector("p[class='MenuItem-module__name___iqvnU']")).Text == "‫גיפט קארד - 30 ₪");
                GiftCard40.Click();
                Thread.Sleep(800);
                var AddToCart = Driver.FindElement(By.CssSelector("button[class='Button__Root-sc-a3fg5q-2 kjNIeb ProductViewFooter__FooterButton-sc-xe19rn-4 bvtgDZ']"));
                AddToCart.Click();
                Thread.Sleep(2000);
                var GoToPay = Driver.FindElement(By.CssSelector("button[class='Button__Root-sc-a3fg5q-2 kjNIeb']"));
                GoToPay.Click();
                var gotopay = Driver.FindElement(By.CssSelector(
	                "button[class='Button__Root-sc-a3fg5q-2 kjNIeb CartViewModal__FooterNextStepButton-sc-1c8ky8o-4 cgOWHa']"));
                gotopay.Click();
                Thread.Sleep(1000);
                //var orderData = new List<IWebElement>(Driver.FindElements(By.CssSelector("a[class='ListItem__RootLinkRoot-sc-1fgc907-0 gWhpUd ListItem-module__container___jS788 ListItem-module__rootLink___M3yRn ListItem-module__rootLink___M3yRn']")));
                var extendPayOptions = Driver.FindElement((By.CssSelector("svg[class='PaymentMethods-module__paymentMethodIcon___wExTL']")));
                extendPayOptions.Click();
                Thread.Sleep(1200);
                var cibusOption = Driver.FindElement(By.CssSelector("path[d='M23.54 0h11.77v49.8H23.54z']"));
                cibusOption.Click();
                var pay = Driver.FindElement(By.CssSelector(
	                "button[class='SendOrderButton-module__orderButton___ogLN1 SendOrderButton-module__interactable___nzvdR'"));
                pay.Click();
                Thread.Sleep(2000);
                var frame = Driver.SwitchTo().Frame("cibus-frame");
                var acceptCibusPay = Driver.FindElement(By.Id("pnlBtnPay"));
                acceptCibusPay.Click();
            }
            Console.WriteLine("Logged In");

            Console.ReadLine();
        }
    }
}
