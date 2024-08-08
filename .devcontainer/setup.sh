curl -s https://packagecloud.io/install/repositories/github/git-lfs/script.deb.sh | sudo bash

sudo apt-get update

sudo apt-get install git-lfs

pip install -r ./.devcontainer/requirements.txt

mkdir ./src/Models

cd ./src/Models

git lfs install

git clone https://huggingface.co/microsoft/Phi-3-vision-128k-instruct-onnx-cpu

git clone https://huggingface.co/microsoft/Phi-3-mini-128k-instruct-onnx

cd ../01.InferencePhi3/03.chat

mkdir models

cd models

mkdir Microsoft

mkdir Xenova

cd Microsoft

git clone https://huggingface.co/microsoft/Phi-3-mini-4k-instruct-onnx-web

cd ../Xenova

git clone https://huggingface.co/Xenova/jina-embeddings-v2-base-en

