using IPPLabThree.Models;
using System;
using System.Text.Json;

namespace IPPLabThree.Serializers
{
    public static class UserMessageSerializer
    {
        public static string SerializeUserMessage(UserMessage userMessage)
        {
            string serializedUserMessage = string.Empty;
            try
            {
                serializedUserMessage = JsonSerializer.Serialize(userMessage);
            }
            catch (Exception) { }
            return serializedUserMessage;
        }
        public static UserMessage DeserializeUserMessage(string serializedUserMessage)
        {
            UserMessage userMessage = null;
            try
            {
                userMessage = JsonSerializer.Deserialize<UserMessage>(serializedUserMessage);
            }
            catch (Exception) { }
            return userMessage;
        }
    }
}