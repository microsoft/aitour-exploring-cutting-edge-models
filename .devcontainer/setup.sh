curl -s https://packagecloud.io/install/repositories/github/git-lfs/script.deb.sh | sudo bash

sudo apt-get update

sudo apt-get install git-lfs

pip install -r ./.devcontainer/requirements.txt

mkdir ./src/Models

cd ./src/Models

git lfs install

git clone https://huggingface.co/microsoft/Phi-3.5-vision-instruct-onnx

git clone https://huggingface.co/microsoft/Phi-3.5-mini-instruct-onnx

cd ../02.ONNXRuntime/01.WebGPUChatRAG

mkdir models

cd models

mkdir Microsoft

mkdir Xenova

cd Microsoft

git clone https://huggingface.co/microsoft/Phi-3-mini-4k-instruct-onnx-web

cd ../Xenova

git clone https://huggingface.co/Xenova/jina-embeddings-v2-base-en

cd ../../../../04.CloudNativeRAG/

mkdir libs

cd ./libs

wget https://github.com/Kitware/CMake/releases/download/v3.30.4/cmake-3.30.4.tar.gz

tar -zxvf cmake-3.30.4.tar.gz

cd cmake-3.30.4

./bootstrap

make

sudo make install

cd ../

git clone https://github.com/microsoft/onnxruntime.git

cd onnxruntime

./build.sh --build_shared_lib --skip_tests --parallel --config Release

cd ../

git clone https://github.com/microsoft/onnxruntime-genai

cd onnxruntime-genai

mkdir ort

cd ort

mkdir include

mkdir lib

cp ../../onnxruntime/include/onnxruntime/core/session/onnxruntime_c_api.h ./include

cp ../../onnxruntime/build/Linux/Release/libonnxruntime*.so* ./lib

cd ../

python build.py
