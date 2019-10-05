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
    private readonly Stack<int> stack = new Stack<int>();

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
    };

    public string Evaluate(string[] instructions)
    {
        foreach (var instruction in instructions)
        {
            var words = instruction.Split(" ");
            foreach (var word in words)
            {
                HandleWord(word);
            }
        }

        return String.Join(" ", stack.Reverse());
    }

    private void HandleWord(string word)
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