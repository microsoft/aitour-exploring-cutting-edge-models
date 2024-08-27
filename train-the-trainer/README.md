## How To Use

Welcome,

We're glad you are here and look forward to your delivery of this amazing content. 

As an experienced presenter, we know you know HOW to present so this guide will focus on WHAT you need to present. It will provide you a full run-through of the presentation created by the presentation design team.

Along with the video of the presentation, this document will link to all the assets you need to successfully present including PowerPoint slides and demo instructions &
code.

## Session overview 

Here is a summary of the selected slides:

### Session Flow:

**Introduction:** Brief overview of Generative AI models and the importance of choosing the right model for specific tasks.

**Types of Generative AI Models:** Discussion on LLMs, SLMs, proprietary vs. open, cloud-based vs. on-device, and multi-modal models. Includes a demo comparing SLMs vs. LLMs and inference using text and vision.

**Common Scenarios and Processes:** Criteria to help guide towards the right model, including task requirements, model capabilities, performance metrics, evaluation methods, iterative refinement, and validation processes. Includes a demo on fine-tuning using local and cloud resources.

**Tools for Model Evaluation and Comparison:** Azure ML for model accuracy measurement, industry-standard evaluation metrics for different model types, and experimentation and validation techniques for model selection.

**Case Studies:** Examples of successful model applications and lessons learned from deployment. Includes a demo of the .NET Aspire RAG Solution.

**Conclusion:** Recap of key points and final thoughts on the future of Generative AI models.

**Session Goals:** Provide a comprehensive understanding of Generative AI models, their types, and the criteria for selecting the right model for specific tasks.

**Demos:** Demonstrate AI’s integration with Azure services, enhancing cloud management and sales engagement.

**Key Audience Takeaways:** Grasp the essentials of Generative AI models, including the importance of model selection for specific tasks and the differences between various model types. Learn about the criteria for choosing the right model and discover tools for model evaluation. Gain real-world insights into model applications and optimization techniques through case studies.

# Getting Started
1.  Read document in its entirety.
2.  Watch the video presentation
3.  Ask questions of the Lead Presenter

## File Summary

| Resources          | Links                            | Description |
|-------------------|----------------------------------|-------------------|
| PowerPoint        | [Presentation](https://aka.ms/AArxlic) | Slides |
| PPT Recording     | Coming soon | Video Recording of the PowerPoint slides with no audio |
| Videos            | Coming soon | Example Presetations of this Session |
| Demos             | [Demo Setup and Preperation](../src/) | 
| Demo Recordings   | [Demo 1](https://aitourassetstore.blob.core.windows.net/assets/BRK453%20Exploring%20cutting-edge%20models%3A%20LLMs,%20SLMs,%20local%20development%20and%20more/Demo1_V1.0.mp4) | Recording of the Demo 1 |
| Demo Recordings   | [Demo 2](https://aitourassetstore.blob.core.windows.net/assets/BRK453%20Exploring%20cutting-edge%20models%3A%20LLMs,%20SLMs,%20local%20development%20and%20more/Demo%202_V1.0.mp4) | Recording of the Demo 2 |
| Demo Recordings   | [Demo 2b](https://aitourassetstore.blob.core.windows.net/assets/BRK453%20Exploring%20cutting-edge%20models%3A%20LLMs,%20SLMs,%20local%20development%20and%20more/Demo%202b_V1.0.mp4) | Recording of the Demo 2b |
| Demo Recordings   | [Demo 3](https://aitourassetstore.blob.core.windows.net/assets/BRK453%20Exploring%20cutting-edge%20models%3A%20LLMs,%20SLMs,%20local%20development%20and%20more/Demo%203_V1.0.mp4) | Recording of the Demo 3 |
| Demo Recordings   | [Demo 4](https://aitourassetstore.blob.core.windows.net/assets/BRK453%20Exploring%20cutting-edge%20models%3A%20LLMs,%20SLMs,%20local%20development%20and%20more/Demo%204_V1.0.mp4) | Recording of the Demo 4 |
This training repository is divided in to the following sections:

| [Slides](#slides) | [Demos](demos/README.md) | [Deployment](deployment/README.md) | 
|-------------------|---------------------------|--------------------------------------
| 36 slides - 30 minutes| 4 demos - 15 minutes | [Demo setup](../src/README.md)

## Slides

The [slides](https://aka.ms/AArxlic) have presenter notes in each part of the session

### Timing


| Time        | Description 
--------------|-------------
0:00 - 5:00   | Introduction
5:00 - 12:00  | Types of Generative AI Models
12:00 - 22:00 | Criteria for Choosing the Right Model
22:00 - 30:00 | Tools for Model Evaluation and Comparisson
30:00 - 40:00 | Case Study
40:00 - 45:00 | Conclusion

## Deployment / Preparation

>**What's Here?** Deploying the demo environment on Azure - including the prerequisites.

[The provided Codespaces and Devcontainer enviroment and prerequisites are outlined here](../Environment.md).

## Demos

> **What's Here?** Pre-delivery preparation, stage ready videos, required files (such as JSON templates), and walk-through videos

Detailed explanations of each demonstration associated with this presentation can be found in this section. There are 3 "live from stage" technical demonstrations that utilize a number of tools both in and out of Azure. [You can get a high level overview of the tools and how we will be using them here](../src/README.md).


| <div style="width:280px">Resources</div>          | <div style="width:180px">Links</div>                           | Description |
|-------------------|----------------------------------|-------------------|
| 01. Introduce Phi-3  | [01.Phi-3 Instruct](../src/01.InferencePhi3/01.notebooks/01.Phi3_Instruct.ipynb) <br/><br/> [02.Phi-3 Vision](../src/01.InferencePhi3/01.notebooks/02.Phi3_Vision.ipynb) <br/><br/> [03.Phi-3 vs GPT-4o](../src/01.InferencePhi3/01.notebooks/03.GPT4o_Vision.ipynb) | Introduce Phi-3,including instruct and vision samples. We can compare the generation result with Phi-3 Vision and GPT-4o  |
| 02. ONNXRuntime WebGPU + AI PC    | [Code](../src/02.ONNXRuntime/01.WebGPUChatRAG/Readme.md) | FineTuning using Olive |
| 03. Fine Tuning on Local Machine or Cloud    | [Code](..//src/03.AIToolsSolutionE2E/Readme.md) | FineTuning using Olive |
| 04. Cloud Native Distributed Application | [Code](../src/04.CloudNativeRAG/Readme.md) | Cloud Native create a .NET Apsire RAG app with WebGPU |
