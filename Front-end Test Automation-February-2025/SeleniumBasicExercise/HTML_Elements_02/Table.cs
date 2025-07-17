using System.Collections.ObjectModel;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HTML_Elements_02
{
    [TestFixture]
    public class WorkingWithWebTable
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
        public void TestExtractProductInformation()
        {
            // Launch Chrome browser with the given URL
            driver.Url = "http://practice.bpbonline.com/";

            // Identify the web table
            IWebElement productTable = driver.FindElement(By.XPath("//*[@id='bodyContent']/div/div[2]/table"));

            // Find the number of rows
            ReadOnlyCollection<IWebElement> tableRows = productTable.FindElements(By.XPath("//tbody/tr"));

            // Path to save the CSV file
            string path = System.IO.Directory.GetCurrentDirectory() + "/productinformation.csv";

            // If the file exists in the location, delete it
                        if (File.Exists(path))
                File.Delete(path);

            // Traverse through table rows to find the table columns
               foreach (IWebElement trow in tableRows)
            {
                ReadOnlyCollection<IWebElement> tableCols = trow.FindElements(By.XPath("td"));
                foreach (IWebElement tcol in tableCols)
                {
                    // Extract product name and cost
                    String data = tcol.Text;
                    String[] productinfo = data.Split('\n');
                    String printProductinfo = productinfo[0].Trim() + "," + productinfo[1].Trim() + "\n";

                    // Write product information extracted to the file
                    File.AppendAllText(path, printProductinfo);
                }
            }

            // Verify the file was created and has content
            Assert.That(File.Exists(path), Is.True, "CSV file was not created.");
            Assert.That(new FileInfo(path).Length, Is.GreaterThan(0), "CSV file is empty.");
        }

        [TearDown]
        public void TearDown()
        {
            // Quit the driver
            driver.Dispose();
        }
    }
}