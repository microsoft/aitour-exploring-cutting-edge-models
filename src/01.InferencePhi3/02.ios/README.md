## Steps to Run phi3-mini on iPhone

### A. Preparation
- **macOS 14+:** Make sure your Mac is running macOS version 14 or higher.
- **Xcode 15+:** Install Xcode version 15 or higher from the App Store.
- **iOS SDK 17.x:** Ensure you have the iOS SDK version 17.x installed (comes with Xcode).
- **Install Python 3.10+:** Install Python version 3.10 or higher. Using Conda is recommended for easy management.
- **Install Python Library:** Install the python-flatbuffers library. You can do this by running:
```
pip install flatbuffers
```
- Install CMake: Install CMake, a tool to manage the build process. You can download it from CMake’s website.

### B. Compiling ONNX Runtime for iOS
**Clone the Repository:** Download the ONNX Runtime source code by running:
```
git clone https://github.com/microsoft/onnxruntime.git
```

**Navigate to the Directory:** Move into the ONNX Runtime directory:

```
cd onnxruntime
```

**Build ONNX Runtime:** Run the build script with the following command:

```
./build.sh --build_shared_lib --ios --skip_tests --parallel --build_dir ./build_ios --ios --apple_sysroot iphoneos --osx_arch arm64 --apple_deploy_target 17.4 --cmake_generator Xcode --config Release
```

**Important:** Before compiling, make sure Xcode is set up correctly. Run this command in the terminal:
```
sudo xcode-select -switch /Applications/Xcode.app/Contents/Developer
```

### C. Compiling Generative AI with ONNX Runtime for iOS
**Clone the Repository:** Download the Generative AI source code by running:
```
git clone https://github.com/microsoft/onnxruntime-genai
```

**Navigate to the Directory:** Move into the Generative AI directory:
```
cd onnxruntime-genai
```
**Checkout the Specific Branch:** Switch to the branch for iOS build:
```
git checkout yguo/ios-build-genai
```

**Build Generative AI:** Run the build script with the following command:
```
python3 build.py --parallel --build_dir ./build_ios_simulator --ios --ios_sysroot iphoneos --osx_arch arm64 --apple_deployment_target 17.4 --cmake_generator Xcode
```
### D. Create an App in Xcode
- **Open Xcode:** Create a new App project in Xcode.
- **Choose Objective-C:** Select Objective-C as the development language for better compatibility with the C++ API. You can also use Swift with bridging.

### E. Add the ONNX Model to Your Project
- **Download the Model:** Download the INT4 quantized model in ONNX format.
- **Add to Project:** Add the downloaded model to the Resources directory of your Xcode project.

### F. Add the C++ API in ViewControllers
- **Add Header Files:** Include the necessary C++ header files in your project.
- **Add ONNX Runtime Library:** Add the onnxruntime-genai dynamic library (dylib) in Xcode.
- **Modify ViewController:** Change ViewController.m to ViewController.mm to use C++ code.

Here’s a sample code snippet to get you started:
```
NSString *llmPath = [[NSBundle mainBundle] resourcePath];
char const *modelPath = llmPath.cString;

auto model = OgaModel::Create(modelPath);
auto tokenizer = OgaTokenizer::Create(*model);

const char* prompt = "<|system|>You are a helpful AI assistant.<|end|><|user|>Can you introduce yourself?<|end|><|assistant|>";

auto sequences = OgaSequences::Create();
tokenizer->Encode(prompt, *sequences);

auto params = OgaGeneratorParams::Create(*model);
params->SetSearchOption("max_length", 100);
params->SetInputSequences(*sequences);

auto output_sequences = model->Generate(*params);
const auto output_sequence_length = output_sequences->SequenceCount(0);
const auto* output_sequence_data = output_sequences->SequenceData(0);
auto out_string = tokenizer->Decode(output_sequence_data, output_sequence_length);

auto tmp = out_string;
```

### G. Run the App
**Run on Device:** Make sure to run the app on an iPhone with iOS 17.4.