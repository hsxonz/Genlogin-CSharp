using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genlogin_CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Genlogin_CSharp
{
    internal class example
    {
        static public async Task Main(String[] args)
        {
            var gen = new Genlogin("");
            var profile = await gen.GetProfiles(1, 0);
            JObject jsonObject = JObject.Parse((string)profile);
            int profileID = (int)jsonObject["data"]["lst_profile"][0]["id"];
            var profileRun = await gen.runProfile(profileID);
            JObject jsonObjectprofileRun = JObject.Parse((string)profileRun);
            string wsEndpoint = ((string)jsonObjectprofileRun["wsEndpoint"]).Split('/')[2];
            var chromeDriverPath = "chromedriver.exe"; 
            var chromeOptions = new ChromeOptions();
            chromeOptions.DebuggerAddress = wsEndpoint;
            var service = ChromeDriverService.CreateDefaultService(chromeDriverPath);
            var driver = new ChromeDriver(service, chromeOptions);

            driver.Navigate().GoToUrl("https://genlogin.com");

            gen.stopProfile(profileID);

            driver.Quit();
        }
    }
}
