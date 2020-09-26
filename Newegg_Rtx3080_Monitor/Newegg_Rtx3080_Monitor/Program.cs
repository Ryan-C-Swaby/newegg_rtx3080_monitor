using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Newegg_Rtx3080_Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var driver = new ChromeDriver())
            {
                bool keepChecking = true;
                while (keepChecking)
                {
                    // This will open up the URL 
                    //driver.Url = "https://www.newegg.com/p/pl?d=rtx+3070+super";
                    driver.Url = "https://www.newegg.com/p/pl?d=rtx+3080";

                    try
                    {
                        // Look for button with Add to cart text
                        var addToCartButton = driver.FindElement(By.XPath("//button[.=\"Add to cart \"]"));

                        // Alert beeps
                        for (int i = 0; i < 30; i++)
                        {
                            Console.Beep();
                            Console.Beep();
                            Console.Beep();
                            Thread.Sleep(2000);
                        }
                        // end loop
                        keepChecking = false;
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(30000);
                        driver.Navigate().Refresh();
                    }
                }

                driver.Close();
                driver.Dispose();
            }
        }
    }
}
