using artificial_intelligence;
using OpenAI.Chat;

var modelName = "gpt-4o";
var client = new ChatClient(modelName, Constants.OpenAIKey);

Console.WriteLine("AI: Hello You can ask me anything or press Enter to exit");
Console.WriteLine();
var messages =new List<ChatMessage>(); // here AI dont have state so we are storing prevoios messages

while(true)// infinite loop until user press enter without any input
{
    Console.WriteLine("You: ");
    var input= Console.ReadLine();
    if(string.IsNullOrWhiteSpace(input))// if user press enter without any input then exit
    { 
        break;
    }
    messages.Add(new UserChatMessage(input));// adding user message to the list, so that AI can have state
   
    Console.WriteLine();

    var response = await client.CompleteChatAsync(messages);// sending all the messages to AI
    var aiResponse = response.Value.Content[0].Text;// getting AI response
    Console.WriteLine($"AI: {aiResponse}");
    Console.WriteLine();
    messages.Add(new AssistantChatMessage(aiResponse));// adding AI response to the list, so that AI can have state

}

