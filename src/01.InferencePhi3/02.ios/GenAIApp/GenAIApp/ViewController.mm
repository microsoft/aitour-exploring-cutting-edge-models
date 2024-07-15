//
//  ViewController.m
//  genaidemo
//
//  Created by lokinfey on 5/4/24.
//

#import "ViewController.h"
#include "ort_genai_c.h"
#include "ort_genai.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    NSString *llmPath = [[NSBundle mainBundle] resourcePath];
    char const *modelPath = llmPath.cString;
//
    auto model =  OgaModel::Create(modelPath);
//
    auto tokenizer = OgaTokenizer::Create(*model);
//
    const char* prompt = "<|system|>You are a helpful AI assistant.<|end|><|user|>Can you introduce yourself?<|end|><|assistant|>";
//
    auto sequences = OgaSequences::Create();
    tokenizer->Encode(prompt, *sequences);
//
    auto params = OgaGeneratorParams::Create(*model);
    params->SetSearchOption("max_length", 100);
    params->SetInputSequences(*sequences);
//
    auto output_sequences = model->Generate(*params);
    const auto output_sequence_length = output_sequences->SequenceCount(0);
    const auto* output_sequence_data = output_sequences->SequenceData(0);
    auto out_string = tokenizer->Decode(output_sequence_data, output_sequence_length);
    
    auto tmp = out_string;
    
    
//    NSLog(@"%@", out_string);
}


@end
