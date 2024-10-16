using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace SemanticKernelFromLocalToCloud;

public class Program
{
    static async Task Main()
    {
        var basePath = System.IO.Directory.GetCurrentDirectory();
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Select the service to use (AzureOpenAI, OpenAI, Google Gemini, Groq, or Local Ollama)
        var service = "Groq"; // Change this to "GoogleGemini" or "Ollama" to switch services

        // Create a kernel and connect it to the selected service
        var kernel = CreateKernel(configuration, service);

        // Add Function to the Kernel | Only model with function call capability
        kernel.ImportPluginFromType<PersonalPlugin>();
        kernel.ImportPluginFromType<GeneralPlugin>();

        // Enable Automatic Function Calling
        OpenAIPromptExecutionSettings executionSettings = new()
        {
            ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
            ChatSystemPrompt = "You are a helpfull assistant",
            Temperature = 0.5,
            MaxTokens = null // For OpenAI function calling must be null 
        };

        // Init conversation
        var chatCompletion = kernel.GetRequiredService<IChatCompletionService>(); // Retrieve the chat completion service

        // Create History Object
        var chatHistory = new ChatHistory();

        while(true)
        {
            Console.Write("Tú: ");
            var userInput = Console.ReadLine();

            if(string.IsNullOrEmpty(userInput))
            {
                break;
            }

            if(chatHistory != null)
            {
                chatHistory.AddUserMessage(userInput);
                var response = await chatCompletion.GetChatMessageContentAsync(chatHistory, executionSettings, kernel);
                Console.WriteLine("AI: " + response);
            }
        }
    }

    static Kernel CreateKernel(IConfiguration configuration, string service)
    {
        var builder = Kernel.CreateBuilder();

        switch(service)
        {
            case "AzureOpenAI":
                return builder.AddAzureOpenAIChatCompletion(
                    configuration["AI:AzureOpenAI:Model"],
                    configuration["AI:AzureOpenAI:ServiceId"],
                    configuration["AI:AzureOpenAI:ApiKey"])
                    .Build();
            case "OpenAI":
                return builder.AddOpenAIChatCompletion(
                    configuration["AI:OpenAI:Model"],
                    configuration["AI:OpenAI:ApiKey"])
                    .Build();
            case "GoogleGemini":
                #pragma warning disable SKEXP0070
                return builder.AddGoogleAIGeminiChatCompletion(
                    configuration["AI:Google:Model"],
                    configuration["AI:Google:ApiKey"])
                    .Build();
            case "Ollama":
                return builder.AddOllamaChatCompletion(
                    configuration["AI:Ollama:Model"],
                    new Uri(configuration["AI:Ollama:Endpoint"]))
                    .Build();
            case "Groq":
                HttpClient httpClient = new(new CustomDelegatingHandler());

                return builder.AddOpenAIChatCompletion(
                    configuration["AI:Groq:Model"],
                    configuration["AI:Groq:ApiKey"],
                    httpClient: httpClient)
                    .Build();
            default:
                throw new ArgumentException("Invalid service selected", nameof(service));
        }
    }

    public class CustomDelegatingHandler() : DelegatingHandler(new HttpClientHandler())
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.RequestUri = new Uri(
                request.RequestUri.ToString().Replace("https://api.openai.com/v1", "https://api.groq.com/openai/v1"));
            return await base.SendAsync(request, cancellationToken);
        }
    }
}