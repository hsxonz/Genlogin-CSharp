# Library <a href="https://genlogin.com" target="_blank">Genlogin API</a>
# Official Package

## Getting Started

Genlogin supports MacOS and Windows platforms.

### Example

```csharp
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
```

### Full GoLogin API
- Swagger: <a href="http://localhost:55550/api-docs" target="_blank">Link here</a> 

### Methods:
LOCAL_URL = "http://localhost:55550/profiles"

- ### getProfiles(limit=1000,offset=0)
  - return { profiles :[...],pagination: [...]}
- ### getProfiles(id)
  - return { id: ..., user_id: ...,profile_data:{...},...}
- ### getWsEndpoint(id)
  - return { success: true, data: { wsEndpoint: 'xxx' } }
- ### runProfile(id)
  - return {success: true, wsEndpoint: 'xxx'}
- ### stopProfile(id)
  - return { success: true }
- ### getProfilesRunning()
  - return { success: true, data: [...] }
