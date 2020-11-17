using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;


namespace TestAutomation.TestSuite.FrontEnd
{
    public static class Objects_Amazon
    {
        public static By HomePage_Search_TextBox = By.XPath("//input[@id='twotabsearchtextbox']");
        public static By HomePage_Search_Button = By.XPath("//input[@value='Go']");


        public static By SearchResults_ResultItem_Image = By.XPath("//span[@data-component-type='s-product-image']//a");

        public static By ProductDescription_ProductTitle_Text = By.XPath("//span[@id='productTitle']");
    }
}
