using System;
using System.Collections.Generic;
using System.Text;

namespace Katas;

public static class WordCountKata
{
    public static Dictionary<string, int> CountWords(string? text)
    {
        if (text is null)
            throw new ArgumentNullException(nameof(text));

        // Comparer case-insensitive: evita normalizar a mano y mantiene el “contrato” claro.
        var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        if (string.IsNullOrWhiteSpace(text))
            return counts;

        var word = new StringBuilder();

        foreach (char c in text)
        {
            if (char.IsLetterOrDigit(c))
            {
                word.Append(c);
                continue;
            }

            AddWordIfAny(counts, word);
        }

        // Por si el texto termina con una letra/dígito y no con separador.
        AddWordIfAny(counts, word);

        return counts;
    }

    private static void AddWordIfAny(Dictionary<string, int> counts, StringBuilder word)
    {
        if (word.Length == 0)
            return;

        var token = word.ToString();
        word.Clear();

        if (counts.TryGetValue(token, out var current))
            counts[token] = current + 1;
        else
            counts[token] = 1;
    }
}
