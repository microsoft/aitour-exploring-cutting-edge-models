namespace Phi3.Aspire.ModelService.Agents;

using System;
using System.Threading.Tasks;

using Microsoft.ML.OnnxRuntimeGenAI;
using Phi3.Aspire.ModelService.Domains;


public class Phi3Agent
{

    private static string modelPath = @"/workspaces/workshop-aitour-exploring-cutting-edge-models/src/Models/Phi-3.5-mini-instruct-onnx/cpu_and_mobile/cpu-int4-awq-block-128-acc-level-4"; 

    private static Microsoft.ML.OnnxRuntimeGenAI.Model model = null;
    private static Microsoft.ML.OnnxRuntimeGenAI.Tokenizer  tokenizer = null;


   
    public static void InitPhi3()
    {
        if(model == null)
        {
            model = new Model(modelPath);
            tokenizer = new Tokenizer(model);
        }

    }

     public static RepsonseJson ChatWithPhi3OpenAIAsync(IList<ChatMessage> messages)
    {
        InitPhi3();

        string userPrompt = "";
        string systemPrompt =  "";
        string chatTemplate = "";

        foreach(var item in messages)
        {
            if(item.Role == "system")
            {
                systemPrompt = item.Content;
            }
            else
            {
                userPrompt = item.Content;
            }
        }

        if(string.IsNullOrEmpty(systemPrompt))
        {
            chatTemplate = $"<|system|>\n{systemPrompt}\n<|end|><|user|>\n{userPrompt}<|end|><|assistant|>\n";
        }
        else
        {
            chatTemplate = $"<|user|>\n{userPrompt}<|end|><|assistant|>\n";
        }

        var tokens = tokenizer.Encode(chatTemplate);

        var generatorParams = new GeneratorParams(model);
        generatorParams.SetSearchOption("max_length", 13000);
        generatorParams.SetInputSequences(tokens);

        var tokenizerStream = tokenizer.CreateStream();
        var generator = new Generator(model, generatorParams);

        string outputString="";

        while (!generator.IsDone())
        {
            generator.ComputeLogits();
            generator.GenerateNextToken();
            outputString += tokenizerStream.Decode(generator.GetSequence(0)[^1]);
            Console.Write(tokenizerStream.Decode(generator.GetSequence(0)[^1]));
        }


        // var outputSequences = model.Generate(generatorParams);

        // var outputString = tokenizer.Decode(outputSequences[0]);

        // IList<RepsonseJson> response = new List<RepsonseJson>();
        // response.Add(new RepsonseJson{ generated_text = outputString});

        return new RepsonseJson{ generated_text = outputString};
    }

    public static IList<RepsonseJson> ChatWithPhi3HuggingFaceAsync(string userPrompt)
    {
        InitPhi3();

        
        string systemPrompt = "You are my AI assistant, you can help me to do answer questions, or chat with me.";
        
        string chatTemplate = $"<|system|>\n{systemPrompt}\n<|end|><|user|>\n{userPrompt}<|end|><|assistant|>\n";

        var tokens = tokenizer.Encode(chatTemplate);

        var generatorParams = new GeneratorParams(model);
        generatorParams.SetSearchOption("max_length", 13000);
        generatorParams.SetInputSequences(tokens);

        var tokenizerStream = tokenizer.CreateStream();
        var generator = new Generator(model, generatorParams);

        string outputString="";

        while (!generator.IsDone())
        {
            generator.ComputeLogits();
            generator.GenerateNextToken();
            outputString += tokenizerStream.Decode(generator.GetSequence(0)[^1]);
            Console.Write(tokenizerStream.Decode(generator.GetSequence(0)[^1]));
        }


        // var outputSequences = model.Generate(generatorParams);

        // outputString = tokenizer.Decode(outputSequences[0]);

        IList<RepsonseJson> resultList = new List<RepsonseJson>();
        resultList.Add(new RepsonseJson{ generated_text = outputString.ToString()});

        return resultList;
    }
}