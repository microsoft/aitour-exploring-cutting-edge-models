# Getting Started with Demo Source Code

## Overview of Demos
This repository contains sample code for the AI Tour Session - Exploring Cutting Edge Models. Each demo folder has a README file with more details. Additional demo videos will be available for use in PowerPoint presentations if live demos are not possible.

## Setting Up the Environment Using Codespaces
We have provided a complete Codespaces environment in the repository. You can also download the devcontainer for local installation by clicking on the devcontainer link.

### Codespace Environment:

- 32 Core CPU
- 128GB of Memory

**Note:** Please wait for Codespaces to initialize and for the setup scripts to complete. We are downloading and installing LLM and SLM models directly to Codespaces, so it may take some time.

## Demo-01: Inference with Phi-3 ONNX
This demo covers scenarios involving iOS apps and RAG (WebGPU) with Phi-3-Instruct and Phi-3-Vision.

| <div style="width:280px">Resources</div>          | <div style="width:180px">Links</div>                           | Description |
|-------------------|----------------------------------|-------------------|
| 01. Introduce Phi-3  | [01.Phi-3 Instruct](../src/01.InferencePhi3/01.notebooks/01.Phi3_Instruct.ipynb) <br/><br/> [02.Phi-3 Vision](../src/01.InferencePhi3/01.notebooks/02.Phi3_Vision.ipynb) <br/><br/> [03.Phi-3 vs GPT-4o](../src/01.InferencePhi3/01.notebooks/03.GPT4o_Vision.ipynb) | Introduce Phi-3,including instruct and vision samples. We can compare the generation result with Phi-3 Vision and GPT-4o  |
| 02. Using iPhone to create copilot application    | [Code](../src/01.InferencePhi3/02.ios/) | Create iPhone chat apps witn Phi-3 mini |
| 03. Create RAG App with WebGPU   | [Code](../src/01.InferencePhi3/03.chat/) | Create RAG app with WebGPU |


## Demo 1. Notebooks Demos for Phi-3 and GPT4o

## 01. Notebooks comparing models
`01.Phi3_Instruct.ipynb` & `02.Phi3_Vision.ipynb`: Just run these notebooks.
`03.GPT4o_Vision:` Requires an Azure OpenAI Service Subscription or GitHub Models. Compare the results of Phi-3-Vision and GPT-4o to see Phi-3-Vision’s strong code and image understanding capabilities.

### 02.iOS
Use macOS to build this sample.

### 03.WebGPU
Required Environment:

**Supported browsers:** 
- Google Chrome 113+
- Microsoft Edge 113+
- Safari 18 (macOS 15)
- Firefox Nightly.

### Enable WebGPU:
- In Chrome/Microsoft Edge, enable the `chrome://flags/#enable-unsafe-webgpu` flag.
- For Linux, launch the browser with `--enable-features=Vulkan`.
- Safari 18 (macOS 15) has WebGPU enabled by default.
- In Firefox Nightly, enter about:config in the address bar and `set dom.webgpu.enabled to true`.

Run the following command to get strated 
```
npm run build
```
```
npm run dev
```

### WebGPU Demo

**Note:** The model needs to be cached in the browser, so it may take some time to load. Upload the markdown file `intro_rag.md` to complete the RAG solution.

## Demo-02 : Fine-tuning Phi-3 with AI Tools VSCode Extensions

Using Azure AI Tools & Microsoft VS Code 

This demo guides you through the process of fine-tuning the Phi-3 model using AI Tools VSCode Extensions, including steps for fine-tuning, inference, and deployment using Azure Machine Learning Service. Ensure your Azure subscription has access to an Azure Compute A100 GPU to complete this demo.

This demo provides a structured approach to fine-tuning the Phi-3 model using AI Tools VSCode Extensions and deploying it with Azure Machine Learning Service

***Note*** Please Ensure your Azure Subscription has access to an Azure Compute A100 GPU to complete this demo.

[Sample Code](./02.AIToolsSolutionE2E/)

| Step | Description | Operation |
|-------------------|----------------------------------|-------------------|
|01.Installation| Please follow this step to set your env|[Go](./02.AIToolsSolutionE2E/qa_e2e/docs/01.Installation.md)|
|02.Prepare your QA datasets| Prepare your datasets, and tell you how to clean your datasets|[Go](./02.AIToolsSolutionE2E/qa_e2e/docs/02.PrepareDatasets.md)|
|03.Use Microsoft Olive to architect SLMOps | Using Microsoft Olive tools to fit your SLMOps cycle|[Go](./02.AIToolsSolutionE2E/qa_e2e/docs/03.E2E_LoRA&QLoRA_Config_With_Olive.md)|
|04.Inference your Fine-tuning models| Inference your onnx model after fine tuning|[Go](./02.AIToolsSolutionE2E/qa_e2e/docs/04.E2E_Inference_ORT.md)|


## Demo-03 : Cloud Native RAG Solutions with Phi-3

Using Cloud Native Solutions with Phi-3, including .NET Aspire, Semantic Kernel and RAG

[Sample Code](./03.CloudNativeRAG/)

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

cp ../../libs/onnxruntime-genai/build/Linux/RelWithDebInfo/libonnxruntime-genai.so ../Phi3.Aspire.ModelService/bin/Debug/net8.0/runtimes/linux-x64/native

cp ../../libs/onnxruntime-genai/build/Linux/RelWithDebInfo/libonnxruntime.so ../Phi3.Aspire.ModelService/bin/Debug/net8.0/runtimes/linux-x64/native

cp ../../libs/onnxruntime-genai/build/Linux/RelWithDebInfo/libonnxruntime.so.1 ../Phi3.Aspire.ModelService/bin/Debug/net8.0/runtimes/linux-x64/native

cp ../../libs/onnxruntime-genai/build/Linux/RelWithDebInfo/libonnxruntime.so.1.20.0 ../Phi3.Aspire.ModelService/bin/Debug/net8.0/runtimes/linux-x64/native

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
Click the Follow Link in the terminal to open the .NET Aspire Portal: 

Eample of the follow link in the info section of the output in your terminal 
```
Login to the dashboard at http://localhost:15147/login?t=65d752d2a8345d9f3t5656ef78e4777
```
![Open Portal](./imgs/0301.png)

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
![PortSettings](../imgs/0302.png)

### Configure Your Ports: 
You know need to configure your GitHub Codespaces ports. 
To set up port forwarding for http://localhost:42811 in GitHub Codespaces, follow these steps:
![Configure Ports](./imgs/0303.png)

**Access the PORTS tab:**

- If you’re using Visual Studio Code, click on the PORTS tab in the bottom panel.
- If you’re using the browser, you can find the PORTS tab in terminal window.

**Add the port:**

You can manually forward a port that wasn't forwarded automatically.

- Open the terminal in your codespace.
- Click the PORTS tab.

Under the list of ports, click Add port.
- Click on Add port.
- Enter 42811 as the port number and press Enter.

**Access the forwarded port:**

Once the port is forwarded, you can access it via a URL provided by GitHub Codespaces. This URL will be displayed in the PORTS tab and can be clicked to open in your browser.

**Change port protocol:**

If you need to use HTTPS instead of HTTP, right-click the port in the PORTS tab, hover over Change Port Protocol, and select HTTPS.
For more detailed information, you can refer to the GitHub Docs on forwarding ports in [Codespaces](https://docs.github.com/en/codespaces/developing-in-a-codespace/forwarding-ports-in-your-codespace)

### Chat with Phi-3

**Start Chatting:** 

- You need to open the newly created port 
![Created Port](./imgs/0306.png)
- In the terminal select the newly created port forwarding address and select open browser
![OpenBrowser](./imgs/0305.png)

You can now start to chat
![Chat with Phi-3](./imgs/0304.png)
