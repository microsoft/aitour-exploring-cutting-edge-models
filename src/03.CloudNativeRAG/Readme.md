# Demo-03 : Cloud Native RAG Solutions with Phi-3

## Getting Started with Phi-3 and .NET Aspire

### Navigate to the Project Directory:
```
cd Phi3DotNETAspire/Phi3.Aspire.AppHost
```

### Build the Project:

```
dotnet build
```

### Copy Necessary Libraries:
```
cp -r ../../libs/* ./Phi3DotNETAspire/Phi3.Aspire.ModelService/bin/Debug/net8.0/runtimes/linux-x64/native
```

### Set Environment Variable:
```
export ASPIRE_ALLOW_UNSECURED_TRANSPORT=true
```

### Run the Application:
```
dotnet run --launch-profile http
```

### Accessing the .NET Aspire Portal
Click the Link to open the .NET Aspire Portal: 
![Open Portal](/src/imgs/0301.png)

### View the Portal: !Portal View
Setting Up Vue Portal in Codespaces
![PortSettings](/src/imgs/0302.png)

### Configure Your Ports: 
![Configure Ports](/src/imgs/0303.png)

### Chat with Phi-3
Start Chatting: 
![Chat with Phi-3](/src/imgs/0304.png)