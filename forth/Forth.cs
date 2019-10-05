using System;
using System.Collections.Generic;
using System.Linq;

public static class Forth
{
    public static string Evaluate(string[] instructions)
    {
        return new Evaluator().Evaluate(instructions);
    }
}

public class Evaluator
{
    private readonly Dictionary<string, Action<Stack<int>>> operations = new Dictionary<string, Action<Stack<int>>>
    {
        { "+", st => st.Push(st.Pop() + st.Pop()) },
        { "-", st => st.Push(- st.Pop() + st.Pop()) },
        { "*", st => st.Push(st.Pop() * st.Pop()) },
        { "/", st =>
            {
                var denom = st.Pop();
                if (denom == 0)
                {
                    throw new InvalidOperationException("Cannot divide by 0");
                }
                var num = st.Pop();
                st.Push(num / denom);
            }
        },
        { "dup", st => st.Push(st.Peek()) },
        { "drop", st => st.Pop() },
        { "swap", st =>
            {
                var n1 = st.Pop();
                var n2 = st.Pop();
                st.Push(n1);
                st.Push(n2);
            }
        },
        { "over", st =>
            {
                var n1 = st.Pop();
                var n2 = st.Peek();
                st.Push(n1);
                st.Push(n2);
            }
        },
        { ";", st => {/* ignore semicolons */} }
    };

    public string Evaluate(string[] instructions)
    {
        var stack = new Stack<int>();
        foreach (var instruction in instructions)
        {
            if (instruction.StartsWith(":"))
            {
                // define new word
                var parts = instruction.Split(" ");
                var newWord = parts[1];
                Action<Stack<int>> newOperation = st => {
                    foreach (var word in parts.Skip(2))
                    {
                        HandleWord(word, st);
                    }
                };
                operations[newWord] = newOperation;
            }
            else
            {
                // evaluate expession
                var words = instruction.Split(" ");
                foreach (var word in words)
                {
                    HandleWord(word, stack);
                }
            }
        }

        return String.Join(" ", stack.Reverse());
    }

    private void HandleWord(string word, Stack<int> stack)
    {
        // is it a number?
        if (int.TryParse(word, out var n))
        {
            stack.Push(n);
        }
        else if (operations.ContainsKey(word))
        {
            operations[word](stack);
        }
        else
        {
            throw new InvalidOperationException($"Don't know how to handle {word}");
        }
    }
}