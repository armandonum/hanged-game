using System;
using System.Collections.Generic;

public class WordBank
{
    private List<string> words;

    public WordBank()
    {
        words = new List<string>
        {
            "gato",
            "perro",
            "casa",
            "computadora",
            "programacion",
            "universidad",
        };
    }

    /// <summary>
/// Get a random word from the list of predefined words
/// /// </summary>
    /// <returns>a ramdon word</returns>
    public string GetRandomWord()
    {
        Random random = new Random();
        int index = random.Next(words.Count);
        return words[index];
    }
}
