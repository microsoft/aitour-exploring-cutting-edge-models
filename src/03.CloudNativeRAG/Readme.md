# Demo-03 : Cloud Native RAG Solutions with Phi-3

## Getting Started with Phi-3 and .NET Aspire

### Navigate to the Project Directory:
```
cd src/03.CloudNativeRAG/Phi3DotNETAspire/Phi3.Aspire.AppHost
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
Open up the brower windows and you will see the .NET Aspire Portal with a list of services and ports, select the vue services. You will see Endpoint as per the example below http://localhost:42811, copy port number 42811
![PortSettings](/src/imgs/0302.png)

### Configure Your Ports: 
You know need to configure your GitHub Codespaces ports. 
To set up port forwarding for http://localhost:42811 in GitHub Codespaces, follow these steps:
![Configure Ports](/src/imgs/0303.png)
**Open your codespace:** Start your codespace in GitHub Codespaces.

**Access the PORTS tab:**

- If you’re using Visual Studio Code, click on the PORTS tab in the bottom panel.
- If you’re using the browser, you can find the PORTS tab in the sidebar.

**Add the port:**

- Click on Add port.
- Enter 42811 as the port number and press Enter.

**Access the forwarded port:**

Once the port is forwarded, you can access it via a URL provided by GitHub Codespaces. This URL will be displayed in the PORTS tab and can be clicked to open in your browser.
Optional

**Change port protocol:**

If you need to use HTTPS instead of HTTP, right-click the port in the PORTS tab, hover over Change Port Protocol, and select HTTPS.
For more detailed information, you can refer to the GitHub Docs on forwarding ports in [Codespaces](https://docs.github.com/en/codespaces/developing-in-a-codespace/forwarding-ports-in-your-codespace)

### Chat with Phi-3
Start Chatting: 
![Chat with Phi-3](/src/imgs/0304.png)
