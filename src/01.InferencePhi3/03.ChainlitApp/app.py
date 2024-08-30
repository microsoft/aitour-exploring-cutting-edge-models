import os
import chainlit as cl
from chainlit.input_widget import Select

from llama_index.core import (
    Settings,
    StorageContext,
    VectorStoreIndex,
    SummaryIndex,
    SimpleDirectoryReader,
    load_index_from_storage,
    get_response_synthesizer,
)
from llama_index.core.query_engine import RouterQueryEngine
from llama_index.core.selectors import LLMSingleSelector
from llama_index.core.retrievers import VectorIndexRetriever, SummaryIndexRetriever
from llama_index.core.response_synthesizers import ResponseMode
from llama_index.llms.azure_inference import AzureAICompletionsModel
from llama_index.embeddings.azure_inference import AzureAIEmbeddingsModel
from llama_index.core.query_engine.retriever_query_engine import RetrieverQueryEngine
from llama_index.core.callbacks import CallbackManager
from llama_index.core.tools import QueryEngineTool

try:
    # rebuild storage context
    storage_context = StorageContext.from_defaults(persist_dir="./storage")
    # load index
    vector_index = load_index_from_storage(storage_context, index_id="vector_index")
    summary_index = load_index_from_storage(storage_context, index_id="summary_index")
except (FileNotFoundError, KeyError, Exception):
    vector_index = None
    summary_index = None
    pass

github_inference_url = "https://models.inference.ai.azure.com"
# If using GitHub Personal access token add your token in the "" below
github_token = os.getenv("GITHUB_TOKEN", "")
github_models_names = {
    "AI21 Labs": "AI21-Jamba-Instruct",
    "Cohere-command-r": "Cohere-command-r",
    "Cohere-command-r-plus": "Cohere-command-r-plus",
    "Cohere-embed-v3-multilingual": "Cohere-embed-v3-multilingual",
    "Meta-Llama-3-70B-Instruct": "Meta-Llama-3-70B-Instruct",
    "Meta-Llama-3-8B-Instruct": "Meta-Llama-3-8B-Instruct",
    "Meta-Llama-3.1-405B-Instruct": "Meta-Llama-3.1-405B-Instruct",
    "Meta-Llama-3.1-70B-Instruct": "Meta-Llama-3.1-70B-Instruct",
    "Meta-Llama-3.1-8B-Instruct": "Meta-Llama-3.1-8B-Instruct",
    "Mistral-large": "Mistral-large",
    "Mistral-large-2407": "Mistral-large-2407",
    "Mistral-Nemo": "Mistral-Nemo",
    "Mistral-small": "Mistral-small",
    "gpt-4o": "gpt-4o",
    "gpt-4o-mini": "gpt-4o-mini",
    "Phi-3-medium-128k-instruct": "Phi-3-medium-128k-instruct",
    "Phi-3-medium-4k-instruct": "Phi-3-medium-4k-instruct",
    "Phi-3-mini-128k-instruct": "Phi-3-mini-128k-instruct",
    "Phi-3-mini-4k-instruct": "Phi-3-mini-4k-instruct",
    "Phi-3-small-128k-instruct": "Phi-3-small-128k-instruct",
    "Phi-3-small-8k-instruct": "Phi-3-small-8k-instruct",
    "Phi-3.5-mini-instruct": "Phi-3.5-mini-instruct",
}


@cl.on_chat_start
async def start():
    global vector_index
    global summary_index

    cl_settings = await cl.ChatSettings(
        [
            Select(
                id="llm",
                label="LLM model",
                description="The LLM used for generation",
                items={
                    "AI21 Labs": "AI21-Jamba-Instruct",
                    "Cohere Command R": "Cohere-command-r",
                    "Cohere Command R+": "Cohere-command-r-plus",
                    "Meta Llama 3 70B Instruct": "Meta-Llama-3-70B-Instruct",
                    "Meta Llama 3 8B Instruct": "Meta-Llama-3-8B-Instruct",
                    "Meta Llama 3.1 405B Instruct": "Meta-Llama-3.1-405B-Instruct",
                    "Meta Llama 3.1 70B Instruct": "Meta-Llama-3.1-70B-Instruct",
                    "Meta Llama 3.1 8B Instruct": "Meta-Llama-3.1-8B-Instruct",
                    "Mistral Large": "Mistral-large",
                    "Mistral Large 2407": "Mistral-large-2407",
                    "Mistral Nemo": "Mistral-Nemo",
                    "Mistral Small": "Mistral-small",
                    "GPT 4o": "gpt-4o",
                    "GPT 4o Mini": "gpt-4o-mini",
                    "Phi 3 Medium 128k Instruct": "Phi-3-medium-128k-instruct",
                    "Phi 3 Medium 4k Instruct": "Phi-3-medium-4k-instruct",
                    "Phi 3 Mini 128k Instruct": "Phi-3-mini-128k-instruct",
                    "Phi 3 Mini 4k Instruct": "Phi-3-mini-4k-instruct",
                    "Phi 3 Small 128k Instruct": "Phi-3-small-128k-instruct",
                    "Phi 3 Small 8k Instruct": "Phi-3-small-8k-instruct",
                    "Phi-3.5-mini-instruct": "Phi-3.5-mini-instruct",
                },
                initial_value="Cohere Command R",
            ),
            Select(
                id="router_llm",
                label="Router LLM",
                description="The LLM model used for routing the requests.",
                items={
                    "AI21 Labs": "AI21-Jamba-Instruct",
                    "Cohere Command R": "Cohere-command-r",
                    "Cohere Command R+": "Cohere-command-r-plus",
                    "Meta Llama 3 70B Instruct": "Meta-Llama-3-70B-Instruct",
                    "Meta Llama 3 8B Instruct": "Meta-Llama-3-8B-Instruct",
                    "Meta Llama 3.1 405B Instruct": "Meta-Llama-3.1-405B-Instruct",
                    "Meta Llama 3.1 70B Instruct": "Meta-Llama-3.1-70B-Instruct",
                    "Meta Llama 3.1 8B Instruct": "Meta-Llama-3.1-8B-Instruct",
                    "Mistral Large": "Mistral-large",
                    "Mistral Large 2407": "Mistral-large-2407",
                    "Mistral Nemo": "Mistral-Nemo",
                    "Mistral Small": "Mistral-small",
                    "GPT 4o": "gpt-4o",
                    "GPT 4o Mini": "gpt-4o-mini",
                    "Phi 3 Medium 128k Instruct": "Phi-3-medium-128k-instruct",
                    "Phi 3 Medium 4k Instruct": "Phi-3-medium-4k-instruct",
                    "Phi 3 Mini 128k Instruct": "Phi-3-mini-128k-instruct",
                    "Phi 3 Mini 4k Instruct": "Phi-3-mini-4k-instruct",
                    "Phi 3 Small 128k Instruct": "Phi-3-small-128k-instruct",
                    "Phi 3 Small 8k Instruct": "Phi-3-small-8k-instruct",
                    "Phi-3.5-mini-instruct": "Phi-3.5-mini-instruct",
                },
                initial_value="Cohere Command R+",
            ),
        ]
    ).send()
    # Read environment variables from GitHub Codespaces
    # if os.getenv("CODESPACES", "") == "true":
    #     Settings.llm = AzureAICompletionsModel(
    #         endpoint=github_inference_url,
    #         credential=github_token,
    #         temperature=0.1,
    #         max_tokens=1024,
    #         streaming=True,
    #         model_name=github_models_names.get("Cohere-command-r", "Cohere-command-r"),
    #     )
    #     # Temporary fix for the model name issue: https://github.com/run-llama/llama_index/issues/15169#issuecomment-2299571873
    #     Settings.llm._model_name = github_models_names.get(
    #         "Cohere-command-r-plus", "Cohere-command-r-plus"
    #     )
    #     Settings.embed_model = AzureAIEmbeddingsModel(
    #         endpoint=github_inference_url,
    #         credential=github_token,
    #         model_name=github_models_names.get(
    #             "Cohere-embed-v3-multilingual", "Cohere-embed-v3-multilingual"
    #         ),
    #     )
    #     Settings.callback_manager = CallbackManager([cl.LlamaIndexCallbackHandler()])
    #     Settings.context_window = 4096
    # else:
    Settings.llm = AzureAICompletionsModel(
            endpoint=github_inference_url,
            credential=github_token,
            temperature=0.1,
            max_tokens=1024,
            streaming=True,
            model_name=github_models_names.get("Cohere-command-r", "Cohere-command-r"),
        )
        # Temporary fix for the model name issue: https://github.com/run-llama/llama_index/issues/15169#issuecomment-2299571873
    Settings.llm._model_name = github_models_names.get(
            "Cohere-command-r-plus", "Cohere-command-r-plus"
    )
    Settings.embed_model = AzureAIEmbeddingsModel(
            endpoint=github_inference_url,
            credential=github_token,
            model_name=github_models_names.get(
                "Cohere-embed-v3-multilingual", "Cohere-embed-v3-multilingual"
            ),
    )
    Settings.callback_manager = CallbackManager([cl.LlamaIndexCallbackHandler()])
    Settings.context_window = 4096

    if not vector_index:
        documents = SimpleDirectoryReader("data/paul_graham/").load_data(
            show_progress=True
        )

        vector_index = VectorStoreIndex.from_documents(documents)
        vector_index.set_index_id("vector_index")
        vector_index.storage_context.persist()
        summary_index = SummaryIndex.from_documents(documents)
        summary_index.set_index_id("summary_index")
        summary_index.storage_context.persist()

    query_engine = build_query_engine_with_router()
    cl.user_session.set("query_engine", query_engine)
    cl.user_session.set("settings", cl_settings)

    await cl.Message(
        author="Assistant",
        content="Hello! I'm an AI assistant. I will try to answer questions about the life of Paul Graham. For specific questions I will use a vector index, but for more comprehensive questions I will use a summary index. I use a LLM to analyze you queston and decide which strategy I should use based on the complexity of the query. Use the settings section to change the model I use to decide.",
    ).send()


def build_simple_query_engine():
    global vector_index

    retriever = VectorIndexRetriever(
        index=vector_index,
        similarity_top_k=2,
    )

    response_synthesizer = get_response_synthesizer(
        response_mode=ResponseMode.COMPACT, streaming=True
    )

    query_engine = RetrieverQueryEngine(
        retriever=retriever,
        response_synthesizer=response_synthesizer,
    )

    return query_engine


def build_summary_query_engine():
    global summary_index

    retriever = SummaryIndexRetriever(
        index=summary_index,
    )

    response_synthesizer = get_response_synthesizer(
        response_mode=ResponseMode.TREE_SUMMARIZE, streaming=True
    )

    query_engine = RetrieverQueryEngine(
        retriever=retriever,
        response_synthesizer=response_synthesizer,
    )

    return query_engine


def build_query_engine_with_router(router_llm=None):
    summary_tool = QueryEngineTool.from_defaults(
        query_engine=build_summary_query_engine(),
        description=(
            "Useful for summarization questions related to Paul Graham eassy on"
            " What I Worked On."
        ),
    )

    vector_tool = QueryEngineTool.from_defaults(
        query_engine=build_simple_query_engine(),
        description=(
            "Useful for retrieving specific context from Paul Graham essay on What"
            " I Worked On."
        ),
    )

    query_engine = RouterQueryEngine(
        selector=LLMSingleSelector.from_defaults(llm=router_llm),
        query_engine_tools=[
            summary_tool,
            vector_tool,
        ],
    )

    return query_engine


@cl.on_message
async def main(message: cl.Message):
    query_engine = cl.user_session.get("query_engine")  # type: RetrieverQueryEngine

    msg = cl.Message(content="", author="Assistant")

    res = await cl.make_async(query_engine.query)(message.content)

    for token in res.response_gen:
        await msg.stream_token(token)
    await msg.send()


@cl.on_settings_update
async def setup_agent(settings):
    cl.user_session.set("settings", settings)

    if settings.get("router_llm", None):
        router_llm_environ = settings["router_llm"]
        # if os.getenv("CODESPACES", "") == "true":
        #     router_llm = AzureAICompletionsModel(
        #         endpoint=github_inference_url,
        #         credential=github_token,
        #         temperature=0.1,
        #         max_tokens=1024,
        #         streaming=True,
        #         model_name=github_models_names.get(router_llm_environ, ""),
        #     )
        #     router_llm._model_name = github_models_names.get(router_llm_environ, "")
        # else:
        router_llm = AzureAICompletionsModel(
                endpoint=github_inference_url,
                credential=github_token,
                temperature=0.1,
                max_tokens=1024,
                streaming=True,
                model_name=github_models_names.get(router_llm_environ, ""),
        )
        router_llm._model_name = github_models_names.get(router_llm_environ, "")

        query_engine = build_query_engine_with_router(router_llm)
        cl.user_session.set("query_engine", query_engine)

        await cl.Message(
            author="Assistant",
            content=f"We are now using {router_llm_environ} for routing queries.",
        ).send()

    if settings.get("llm", None):
        llm_environ = settings["llm"]
        # if os.getenv("CODESPACES", "") == "true":
        #     llm = AzureAICompletionsModel(
        #         endpoint=github_inference_url,
        #         credential=github_token,
        #         temperature=0.1,
        #         max_tokens=1024,
        #         streaming=True,
        #         model_name=github_models_names.get(llm_environ, ""),
        #     )
        #     llm._model_name = github_models_names.get(llm_environ, "")
        # else:
        llm = AzureAICompletionsModel(
                endpoint=github_inference_url,
                credential=github_token,
                temperature=0.1,
                max_tokens=1024,
                streaming=True,
                model_name=github_models_names.get(llm_environ, ""),
            )
        llm._model_name = github_models_names.get(llm_environ, "")

        Settings.llm = llm

        await cl.Message(
            author="Assistant",
            content=f"We are now using {llm_environ} for answering queries.",
        ).send()
