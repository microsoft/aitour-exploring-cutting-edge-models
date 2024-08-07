curl -s https://packagecloud.io/install/repositories/github/git-lfs/script.deb.sh | sudo bash

sudo apt-get update

sudo apt-get install git-lfs

pip install -r ./.devcontainer/requirements.txt

cd ./src/Models

git lfs install

git clone https://huggingface.co/microsoft/Phi-3-mini-128k-instruct

git clone https://huggingface.co/microsoft/Phi-3-vision-128k-instruct-onnx-cpu