using Microsoft.SemanticKernel;
using System;
using System.ComponentModel;
using System.Linq;

namespace SemanticKernelFromLocalToCloud
{
    public sealed class GeneralPlugin
    {

        [KernelFunction]
        [Description("Retrieves the current time in UTC")]
        public string GetCurrentUtcTime() => DateTime.UtcNow.ToString("R");


        [KernelFunction]
        [Description("Gets the current weather for the specified city")]
        public string GetWeatherForCity(string cityName) =>
        cityName switch
        {
            "Boston" => "61 and rainy",
            "London" => "55 and cloudy",
            "Miami" => "80 and sunny",
            "Paris" => "60 and rainy",
            "Tokyo" => "50 and sunny",
            "Sydney" => "75 and sunny",
            "Tel Aviv" => "80 and sunny",
            _ => "31 and snowing",
        };
    }

    public sealed class PersonalPlugin
    {

        [KernelFunction]
        [Description("Answer question about me")]
        static string AnswerQuestionAboutMe(string name)
        {
            return SearchInDataBase(name);
        }

        // Database simulator
        static string SearchInDataBase(string name)
        {
            // Logic
            return $"Tu nombre es Pedro Hernandez. y tu pregunta fué {name}";
        }
    }

}

