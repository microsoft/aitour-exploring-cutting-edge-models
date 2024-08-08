# Demo-03 : Cloud Native RAG Solutions with Phi-3

## Getting Started with Phi-3 and .NET Aspire

### Navigate to the Project Directory:
```
cd 03.CloudNativeRAG/Phi3DotNETAspire/Phi3.Aspire.AppHost
```

### Build the Project:

```
dotnet build
```

### Copy Necessary Libraries:

Ensure you are in the .../src/03.CloudNativeRAG/Phi3DotNETAspire/Phi3.Aspire.AppHost folder

```
cp -r ../../libs/* ../Phi3.Aspire.ModelService/bin/Debug/net8.0/runtimes/linux-x64/native
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

### Enter the token

You will be prompted to enter a login token this can be found in your terminal output.

Example will be as follows
```
Login to the dashboard at http://localhost:15147/login?t=65d752d2a8345d9f3t5656ef78e4777
```

In this case the login code is 
```
65d752d2a8345d9f3f10680ef78e4777
```

### View the Portal:
Setting Up Vue Portal in Codespaces
![PortSettings](/src/imgs/0302.png)

### Configure Your Ports: 
![Configure Ports](/src/imgs/0303.png)

### Chat with Phi-3
Start Chatting: 
![Chat with Phi-3](/src/imgs/0304.png)