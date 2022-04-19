# LightningAlert
A Case Study Project For Lightning Strike Alert System,
Microsoft.NET.Sdk.Web Project

---

### Get Started

Project was written with .Net 5 Sdk and it is available from the link below:
```
https://dotnet.microsoft.com/en-us/download/dotnet/5.0
```

### Publish Application
In Release folder, use publish.bat to publish the an exe output for windows pc,
Edit the bat file if using another Os types


### Run And Usage
Project Listens 5001 port by default, 
and only has one controller /LithningStrike accepts post methods with LightningStrike object body,

LightningStrike Object Prototype :
```
{
  int flashType,
  long strikeTime,
  double latitude,
  double longitude,
  int peakAmps,
  string reserved,
  int icHeight,
  long receivedTime,
  int numberOfSensors,
  int multiplicity,
}
```


Swagger Option is enabled for test purpose, While Exe is running, Open the link below to use swagger utility and send new LightningStrike Events:
```
https://127.0.0.1:5001/swagger
```

### Dependency
As This is a case study, Project not working with a read database, 
assets.json file supplied for simple assets information, please keep the file with the same directory of exe
