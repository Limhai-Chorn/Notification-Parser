
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        
        string[] inputText = {
            "[BE][FE][Urgent] there is error",
            "[BE][QA][HAHA][Urgent] there is error"
        };

        foreach (var input in inputText)
        {
            string outputText = findNotificationChannel(input);
            Console.WriteLine(outputText);
        }
    }

    static string findNotificationChannel(string text)
    {
        // declare list notification channels
        List<string> channels = new List<string> { "BE", "FE", "QA", "Urgent" };

        // Use regex to find all tags in square brackets
        MatchCollection matches = Regex.Matches(text, @"\[(.*?)\]");
        List<string> returnChannels = new List<string>();

        foreach (Match match in matches)
        {
            string tag = match.Groups[1].Value;
            if (channels.Contains(tag))
            {
                returnChannels.Add(tag);
            }
        }

        string result = "Receive channels: " + string.Join(", ", returnChannels);
        return result;
    }
}
