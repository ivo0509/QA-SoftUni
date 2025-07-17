using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace HTMLElements03
{
    [TestFixture]
    public class WorkingWithDropDown
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            // Create object of ChromeDriver
            driver = new ChromeDriver();

            // Add implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void TestSelectFromDropDown()
        {
            // Launch Chrome browser with the given URL
            driver.Url = "http://practice.bpbonline.com/";

            //Create a text file to save manufacturer information
            string path = Directory.GetCurrentDirectory() + "/manufacturer.txt";

            // If the file exists in the location, delete it
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //Locate the dropdown element by its name attribute
            SelectElement manufDropdown = new SelectElement(driver.FindElement(By.Name("manufacturers_id")));

            // Fetch all the options from drop down
            IList<IWebElement> allManufacturers = manufDropdown.Options;

            // Create a string list to fill in all manufacturers
            List<string> manufNames = new List<string>();

            // Fetch all manufacturer names in a List
            foreach (IWebElement manufName in allManufacturers)
            {
                manufNames.Add(manufName.Text);
            }
            // Remove the "Please Select" option from the list
            manufNames.RemoveAt(0);

            // Iterate through the manufacturers to fetch the product information related to it

            foreach (string mname in manufNames)
            {
                manufDropdown.SelectByText(mname);
                manufDropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));

                if (driver.PageSource.Contains("There are no products available in this category."))
                {
                    File.AppendAllText(path, $"The manufacturer {mname} has no products\n");
                }
                else
                {
                    // Create the table element
                    IWebElement productTable = driver.FindElement(By.ClassName("productListingData"));

                    // Fetch all table rows
                    File.AppendAllText(path, $"\n\nThe manufacturer {mname} products are listed--\n");
                    ReadOnlyCollection<IWebElement> rows = productTable.FindElements(By.XPath("//tbody/tr"));

                    // Print the product information in the file
                    foreach (IWebElement row in rows)
                    {
                        File.AppendAllText(path, row.Text + "\n");
                    }
                }
            }

            // Quit the driver
            driver.Dispose();
        }
    }
}