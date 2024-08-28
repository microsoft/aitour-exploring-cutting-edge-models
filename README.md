# BRK453 Exploring cutting-edge models: LLMs, SLMs, local development and more


[![Azure AI Community Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4?WT.mc_id=aiml-137032-kinfeylo)

[![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/microsoft/aitour-exploring-cutting-edge-models)
[![Open in Dev Containers](https://img.shields.io/static/v1?style=for-the-badge&label=Dev%20Containers&message=Open&color=blue&logo=visualstudiocode)](https://vscode.dev/redirect?url=vscode://ms-vscode-remote.remote-containers/cloneInVolume?url=https://github.com/microsoft/aitour-exploring-cutting-edge-models)

![Title](./images/explorecuttingedge.png)

## Session Desciption
Today, there are many Generative AI models to choose from: Large Language Models (LLMs), Small Language Models (SLMs), proprietary models, open models, models in the cloud, models on devices, text models, code models, image models, and multimodal models. In this session, we'll provide guidance to help you choose the right model to fit your needs, and tools you can use to evaluate and compare models for your specific tasks.

### Abstract:
There are many Generative AI models: LLMs, SLMs, proprietary, open, cloud-based, on-device, text, code, image, and multimodal. Learn how to choose the right model for your needs and about tools to evaluate and compare models for specific tasks.
 
### Duration: 
45 minutes

### [Slide Deck](https://aka.ms/AArxlic)

## Learning Outcomes
 
### Understanding of Generative AI Models:
Attendees should leave with a clear understanding of what generative AI models are, how they work, and their significance in various applications.
### Model Selection Criteria:
Participants will learn how to choose the right model for specific tasks based on factors such as task requirements, model capabilities, and performance metrics.
### Awareness of Model Types:
We’ll explore different types of generative models, including Large Language Models (LLMs) like GPT-3, Small Language Models (SLMs), and multimodal models that handle text, code, and images.
### Fine-Tuning Techniques:
Attendees will see how fine-tuning can improve model performance and adapt it to specific use cases.
### Evaluation and Comparison Tools:
We’ll discuss industry-standard evaluation metrics and tools like Azure AI Studio for accurate model measurement.
### Real-World Case Studies:
Examples of successful model applications will provide insights into practical deployment scenarios.
### The Future of Generative AI:
We’ll wrap up with thoughts on where this field is headed and its potential impact.

## Technology Used
- [AI Studio](https://ai.azure.com)
- [Azure Model Catalog](https://learn.microsoft.com/azure/ai-studio/how-to/model-catalog-overview)
- [GitHub Model Catalog](https://github.com/marketplace/models) 
- Large Language Models - GPT 3.5 GPT 4/4v/4o
- Small Language Models - Phi-3 
- [ONNXRuntime](https://onnxruntime.ai/)
- [OLIVE](https://github.com/microsoft/OLive)
- [Windows AI PC SDK](https://aka.ms/wcr) 

## Session Overview

### Introduction (5 min)
- Brief overview of Generative AI models
- Importance of choosing the right model for specific tasks
- Multimodal and GPT Prompts vs DALL-E Outcomes

### Types of Generative AI Models (8min)
- Large Language Models (LLMs)
- Small Language Models (SLMs)
- Proprietary vs. Open Models
- Cloud-based vs. On-device Models
- Text, Code, Image, and Multimodal Models
 
[**DEMO- Inference Phi-3-mini-instruct & Phi-3-vision** (3 min)](/src/01.InferencePhi3/01.notebooks/) 
Comparing SLMs vs LLMs Inference using text and vision building cross platform solution
- [Notebooks](/src/01.InferencePhi3/01.notebooks/)
- [Model Chat Demo Video](https://aka.ms/AArzlav)
This demo takes an image png and then converts the image to code using Phi3 Onnx model local hosted vs GPT4o (Azure/GitHub Models Cloud hosted) the image is then converted to create a matplot python version of the image.

[**DEMO- Chainlit RAG Chat App which is using GitHub Models and Inference API** (2 min)](/src/01.InferencePhi3/03.ChainlitApp/readme.md) 
Comparing SLMs vs LLMs Inference using text from a RAGChat web application
- [Notebooks](/src/01.InferencePhi3/03.ChainlitApp/llama_index_selector_gh_models.ipynb)
- [ChainLit App](/src/01.InferencePhi3/03.ChainlitApp/app.py)
- [Model Chat Demo Video](TBD)
This demo is a RAG chat demo using text files and compairing the difference of LLM and SLM model outputs you can select the LLM or SLM to utilise and compare results.

- The opportunity of SLMs and LLMs

[**DEMO- ONNXRuntime WebGL + AI PC** (5 min)](/src/02.ONNXRuntime/01.WebGPUChatRAG/Readme.md)
- [AIPC Sample Source Code](https://github.com/microsoft/ai-powered-notes-winui3-sample) 
- [AI PC Video Demo for non AI PC users]()
- [WebGPU RAG Chat Demo](/src/02.ONNXRuntime/)
- [Video WebGPU RAG Chat Demo](https://aka.ms/AArz5vh)
- [Video AI PC Demo](https://aka.ms/AArzlas)

### Criteria for Choosing the Right Model (10 min)
- Task requirements and model capabilities
- Performance metrics and evaluation methods
- Iterative refinement and validation processes
- Fine-tuning options for model improvement

- [**DEMO - Phi-3 Fine-tuning** (5 min)](/src/03.AIToolsSolutionE2E/Readme.md)
- [Video of Fine-Tuning Demo](https://aka.ms/AArzdl0)

Cloud Based FineTuning using Azure AI Compute and Local based Fine Tuning using Microsoft Olive

### Tools for Model Evaluation and Comparison ( 5-8 min)
- Azure Machine Learning for model accuracy measurement
- Industry-standard evaluation metrics for different model types
- Experimentation and validation techniques for model selection

### Case Studies (8-10 min)
- Examples of successful model applications
- Lessons learned from model deployment and usage

- [**DEMO - Cloud Native Distributed Application using Phi-3 & .NET Aspire to undertake RAG**  (5 min)](/src/04.CloudNativeRAG/Readme.md)
- [Video Cloud Native](https://aka.ms/AArz5vo)

RAG Aspire demo(Deployment of Phi-3 as Models as a Service and .using .NET Aspire to create Cloud Native Distribution Application)

The RAG Aspire demo showcases the deployment of Phi-3 as a service and the use of .NET Aspire to create a cloud-native distributed application chat application. This demonstration aligns with Azure’s capabilities, highlighting the seamless integration and deployment of advanced AI models like Phi-3 within the Azure ecosystem. It also emphasizes the versatility of .NET Aspire in building scalable, cloud-native applications, catering to the growing demand for intelligent and responsive chat applications in various industries.

### Conclusion (3 min)
- Recap of key points
- Final thoughts on the future of Generative AI models

### Q&A
- Open floor for questions and discussion

## Session Resources and Continued Learning

| Resources          | Links                             | Description        |
|:-------------------|:----------------------------------|:-------------------|
| Phi-3 CookBook  | [Phi-3CookBook](https://aka.ms/phi-3cookbook) | Learn more about Phi-3 samples, models and deployments |
| Windows AI PC and Copilot SDK  | [Windows Copilot SDK](https://aka.ms/wcr) | Use powerful AI APIs with Windows Copilot Library|
| ONNX Runtime  | [ONNXRuntime](https://onnxruntime.ai/) | Accelerated Mobile Machine Learning Production-grade AI engine to speed up training and inferencing in your existing technology stack.|
| AI Studio | [AI Studio ](https://ai.azure.com) | Azure AI Studio is a platform for building, evaluating, and deploying generative AI solutions and custom copilots. |
| AI Studio Model Catalog  | [AI Studio Model Catalog](https://ai.azure.com/explore/models) | Find the right model to build your custom AI solution|
| AI Toolkit for VsCode | [AI Toolkit](https://marketplace.visualstudio.com/items?itemName=ms-windows-ai-studio.windows-ai-studio) | AI Toolkit for VS Code streamlines generative AI app development by integrating tools and models from Azure AI Studio and Hugging Face. Browse and download public models, fine-tune, test, and use them in your Windows applications.|
| GitHub Model Catalog | [GitHub Model Catalog](https://github.com/marketplace/models) | Models Try, test, and deploy from a wide range of model types, sizes, and specializations.| 

## Fine-Tuning

| Requirement                        | Start with                            | Why?                                                                                                                                                                                                        |
| ---------------------------------- | ------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Steer model with a few examples    | Prompt engineering                    | Easy to craft and quick experimentation, very low barrier to entry                                                                                                                                          |
| Simple & quick implementation      | Prompt engineering, RAG               | Easy tooling with Azure OpenAI on Your Data, PromptFlow, LangChain                                                                                                                                          |
| Improve model relevancy            | RAG                                   | Retrieve relevant information from your own datasets to insert into prompts                                                                                                                                 |
| Up to date information             | RAG                                   | Query up to date information from your own databases, search engineers, etc. to insert into prompts                                                                                                         |
| Factual grounding                  | RAG                                   | Ability to reference & inspect retrieved data                                                                                                                                                               |
| Optimize for specific tasks        | Fine tuning                           | Fine tuning is great at steering your model for specific tasks like summarizing data in a specific format                                                                                                   |
| Instructions won't fit in a prompt | Fine tuning                           | Fine tuning moves few-shot examples into the training step but increases the quantity of examples are needed to train.                                                                                      |
| Lower costs                        | It depends                            | ⚠️Prompt engineering & RAG have lower upfront costs but long prompts are more expensive; training for FT is expensive but may cut prompt length. The choice will always depend on the use case & data.      |
| Complex, novel data or domains     | Prompt Engineering + RAG+ Fine Tuning | ⚠️ This is a high risk area. Fine tuning can retrain the model to recognize new domains, but RAG is needed to avoid plausible confabulations. Make sure customers don't try to retrain for unapproved uses! |

### Benchmark Tools and Resources

| Benchmarks          | Description                                                                                                                                                            | Reference URL                                                                        |
| ------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------ |
| GLUE Benchmark      | GLUE (General Language Understanding Evaluation) benchmark provides a standardized set of diverse NLP tasks to evaluate the effectiveness of different language models | [https://gluebenchmark.com/](https://gluebenchmark.com/)                             |
| SuperGLUE Benchmark | Compares more challenging and diverse tasks with GLUE, with comprehensive human baselines                                                                              | [https://super.gluebenchmark.com/](https://super.gluebenchmark.com/)                 |
| HellaSwag           | Evaluates how well an LLM can complete a sentence                                                                                                                      | [https://rowanzellers.com/hellaswag/](https://rowanzellers.com/hellaswag/)           |
| TruthfulQA          | Measures truthfulness of model responses                                                                                                                               | [https://github.com/sylinrl/TruthfulQA](https://github.com/sylinrl/TruthfulQA)       |
| MMLU                | MMLU ((Massive Multitask Language Understanding) evaluates how well the LLM can multitask                                                                              | [https://github.com/hendrycks/test](https://github.com/hendrycks/test)               |
| KILT                | Library for Knowledge intestive language tasks                                                                                                                         | [https://github.com/facebookresearch/KILT](https://github.com/facebookresearch/KILT) |

## Evaluation Frameworks

| Frameworks / Platforms                 | Description                                                                                                                                                                                                                                                    | Tutorials/lessons                                                                                                                            | Reference                                       |
| -------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------- |
| Azure AI Studio Evaluation (Microsoft) | Azure AI Studio is an all-in-one AI platform for building, evaluating, and deploying generative AI solutions and custom copilots.Technical Landscape: No code: model catalog in AzureML studio & AI studio, Low-code: as CLI, Pro-code: as azureml-metrics SDK | [Tutorials](https://learn.microsoft.com/en-us/azure/ai-studio/concepts/evaluation-approach-gen-ai)                                           | [Link](https://ai.azure.com/)                   |
| Prompt Flow (Microsoft)                | A suite of development tools designed to streamline the end-to-end development cycle of LLM-based AI applications, from ideation, prototyping, testing, and evaluation to production, deployment, and monitoring.                                              | [Tutorials](https://microsoft.github.io/promptflow/how-to-guides/quick-start.html)                                                           | [Link](https://github.com/microsoft/promptflow) |
| Weights & Biases(Weights & Biases)     | A Machine Learning platform to quickly track experiments, version and iterate on datasets, evaluate model performance, reproduce models, visualize results and spot regressions, and share findings with colleagues.                                           | [Tutorias](https://docs.wandb.ai/tutorials), <br> [DeepLearning.AI Lesson](https://learn.deeplearning.ai/evaluating-debugging-generative-ai) | [Link](https://docs.wandb.ai/)                  |

### ONNX & GGUF
| ONNX Runtime (Open Neural Network Exchange)                                                                                                                                                                                                 | GGUF (GGML Unified Format)                                                                                                                                                   |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Purpose:  ONNX Runtime is an inference engine designed to run models in the ONNX (Open Neural Network Exchange) format. It supports multiple backends and optimizations, making it versatile for various hardware and deployment scenarios. | Purpose: GGUF is part of the GGML ecosystem, which includes tools like llama.cpp for running inference on large language models (LLMs). It is optimized for local inference. |
| Optimization: ONNX Runtime includes features for model optimization, such as quantization and hardware acceleration.                                                                                                                        | Optimization: GGUF supports 4-bit quantization and is designed to work efficiently with specific hardware setups, such as M-series GPUs on Apple Silicon                     |
| Compatibility: It supports a wide range of frameworks like PyTorch, TensorFlow, and others, making it versatile for various backend ML frameworks.                                                                                          | Compatibility: GGUF (formerly GGML) is designed to be highly compatible with various environments and tools, particularly for efficient inference of large language models   |
| Inference: ONNX models can be run using ONNX Runtime, which supports multiple backends and optimizations.                                                                                                                                   | Inference: GGUF is tightly integrated with GGML and related tools, providing a streamlined experience for inference.                                                         |

### Quick Guide to Choosing Model Optimization Techniques

| Memory Optimization                                                                                                                                                                                                                                                                                                                                              | Efficiency Optimization                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Low Ranking Adaptation (LoRA): LoRA is a technique to fine tune large language models. It uses low-rank approximation methods to reduce the computational and financial costs of adapting models with billions of parameters, such as GPT-3, to specific tasks or domains.                                                                                       | DeepSpeed:  is a deep learning software library that accelerates the training of large language models. It includes ZeRO (Zero Redundancy Optimizer), a memory-efficient approach for distributed training. DeepSpeed can automatically optimize fine-tuning jobs that use Hugging Face’s Trainer API, and offers a drop-in replacement script to run existing fine-tuning scripts.                                                                              |
| Quantized LoRA (QLoRA): QLoRA is an efficient finetuning approach for large language models (LLMs) that significantly reduces memory usage while maintaining the performance of full 16-bit finetuning. It achieves this by backpropagating gradients through a frozen, 4-bit quantized pretrained language model into Low Rank Adapters.                        | ZeRO: ZeRO is a set of memory optimization techniques that enable effective training of large models with trillions of parameters, such as GPT-2 and Turing-NLG 17B. A key appeal of ZeRO is that no model code modifications are required. It’s a memory-efficient form of data parallelism that gives you access to the aggregate GPU memory of all the GPU devices available to you, without inefficiency caused by the data replication in data parallelism. |
| Parameter Efficient Fine Tuning (PEFT): PEFT is an NLP technique that adapts pre-trained language models adjusting key parameters for specific tasks, and delivers comparable performance to full fine-tuning across modalities like image classification and stable diffusion. It's a valuable approach for high performance with minimal trainable parameters. | DORA: Weight-Decomposed Low-Rank Adaptation (DoRA). DoRA initially decomposes the pre-trained weight into its magnitude and directional components and finetunes both of them. Because the directional component is large in terms of parameter numbers, we further decompose it with LoRA for efficient finetuning.                                                                                                                                             |
## Content Owners

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->

<table>
<tr>
    <td align="center"><a href="http://learnanalytics.microsoft.com">
        <img src="https://avatars.githubusercontent.com/u/2511341?v=4" width="100px;" alt="Lee Stott
"/><br />
        <sub><b>Lee Stott
</b></sub></a><br />
            <a href="https://github.com/leestott" title="talk">📢</a> 
    </td>
   <td align="center"><a href="http://learnanalytics.microsoft.com">
        <img src="https://avatars.githubusercontent.com/u/93169410?v=4" width="100px;" alt="Kinfey Lo"
"/><br />
        <sub><b>Kinfey Lo
</b></sub></a><br />
            <a href="https://github.com/kinfey" title="talk">📢</a> 
    </td>
     
</tr></table>

<!-- ALL-CONTRIBUTORS-LIST:END -->

## Responsible AI 

Microsoft is committed to helping our customers use our AI products responsibly, sharing our learnings, and building trust-based partnerships through tools like Transparency Notes and Impact Assessments. Many of these resources can be found at [https://aka.ms/RAI](https://aka.ms/RAI).
Microsoft’s approach to responsible AI is grounded in our AI principles of fairness, reliability and safety, privacy and security, inclusiveness, transparency, and accountability.

Large-scale natural language, image, and speech models - like the ones used in this sample - can potentially behave in ways that are unfair, unreliable, or offensive, in turn causing harms. Please consult the [Azure OpenAI service Transparency note](https://learn.microsoft.com/legal/cognitive-services/openai/transparency-note?tabs=text) to be informed about risks and limitations.

The recommended approach to mitigating these risks is to include a safety system in your architecture that can detect and prevent harmful behavior. [Azure AI Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/overview) provides an independent layer of protection, able to detect harmful user-generated and AI-generated content in applications and services. Azure AI Content Safety includes text and image APIs that allow you to detect material that is harmful. We also have an interactive Content Safety Studio that allows you to view, explore and try out sample code for detecting harmful content across different modalities. The following [quickstart documentation](https://learn.microsoft.com/azure/ai-services/content-safety/quickstart-text?tabs=visual-studio%2Clinux&pivots=programming-language-rest) guides you through making requests to the service.

Another aspect to take into account is the overall application performance. With multi-modal and multi-models applications, we consider performance to mean that the system performs as you and your users expect, including not generating harmful outputs. It's important to assess the performance of your overall application using [generation quality and risk and safety metrics](https://learn.microsoft.com/azure/ai-studio/concepts/evaluation-metrics-built-in).

You can evaluate your AI application in your development environment using the [prompt flow SDK](https://microsoft.github.io/promptflow/index.html). Given either a test dataset or a target, your generative AI application generations are quantitatively measured with built-in evaluators or custom evaluators of your choice. To get started with the prompt flow sdk to evaluate your system, you can follow the [quickstart guide](https://learn.microsoft.com/azure/ai-studio/how-to/develop/flow-evaluate-sdk). Once you execute an evaluation run, you can [visualize the results in Azure AI Studio](https://learn.microsoft.com/azure/ai-studio/how-to/evaluate-flow-results).
