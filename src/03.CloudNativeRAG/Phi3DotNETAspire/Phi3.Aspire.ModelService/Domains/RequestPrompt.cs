namespace Phi3.Aspire.ModelService.Domains
{
    public class RequestPrompt
    {
        public string inputs { get; set; }
    }

    public class ChatRequestPrompt
    {
        public IList<ChatMessage> Messages { get; set; }
        public string Model { get; set; }
    }

    public class ChatMessage
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }

    public class KBInfo
    {
        public string KB { get; set; }

        public string Content { get; set; }
    }

    public class Usage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }

    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }

    public class Choice
    {
        public Message message { get; set; }
        public string finish_reason { get; set; }
        public int index { get; set; }
    }

    public class RootObject
    {
        public string @object { get; set; }
        public string model { get; set; }
        public Usage usage { get; set; }
        public IList<Choice> choices { get; set; }
    }

    public class RepsonseChatJson
    {
        public string Role { get; set; }

        public string InnerContent { get; set; }
    }

    
}