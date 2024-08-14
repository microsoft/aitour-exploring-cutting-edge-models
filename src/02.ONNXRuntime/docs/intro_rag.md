# Introduce GraphRAG

## What is GraphRAG? 

GraphRAG is an AI-based content interpretation and search capability. Using LLMs, it parses data to create a knowledge graph and answer user questions about a user-provided private dataset. 

## What are GraphRAG’s intended use? 

* GraphRAG is intended to support critical information discovery and analysis use cases where the information required to arrive at a useful insight spans many documents, is noisy, is mixed with mis and/or dis-information, or when the questions users aim to answer are more abstract or thematic than the underlying data can directly answer. 
* GraphRAG is designed to be used in settings where users are already trained on responsible analytic approaches and critical reasoning is expected. GraphRAG is capable of providing high degrees of insight on complex information topics, however human analysis by a domain expert of the answers is needed in order to verify and augment GraphRAG’s generated responses. 
* GraphRAG is intended to be deployed and used with a domain specific corpus of text data. GraphRAG itself does not collect user data, but users are encouraged to verify data privacy policies of the chosen LLM used to configure GraphRAG. 

## How was GraphRAG evaluated? What metrics are used to measure performance? 

GraphRAG has been evaluated in multiple ways.  The primary concerns are 1) accurate representation of the data set, 2) providing transparency and  groundedness of responses, 3) resilience to prompt and data corpus injection attacks, and 4) low hallucination rates.  Details on how each of these has been evaluated is outlined below by number. 

1) Accurate representation of the dataset has been tested by both manual inspection and automated testing against a “gold answer” that is created from randomly selected subsets of a test corpus. 

2) Transparency and groundedness of responses is tested via automated answer coverage evaluation and human inspection of the underlying context returned.  

3) We test both user prompt injection attacks (“jailbreaks”) and cross prompt injection attacks (“data attacks”) using manual and semi-automated techniques. 

4) Hallucination rates are evaluated using claim coverage metrics, manual inspection of answer and source, and adversarial attacks to attempt a forced hallucination through adversarial and exceptionally challenging datasets. 