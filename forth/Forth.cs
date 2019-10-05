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
                DefineNewWord(instruction);
            }
            else
            {
                EvaluateExpression(stack, instruction);
            }
        }

        return String.Join(" ", stack.Reverse());
    }

    private void DefineNewWord(string instruction)
    {
        var parts = instruction.Split(" ");
        var newWord = parts[1];
        // is it a number?
        if (int.TryParse(newWord, out var n))
        {
            throw new InvalidOperationException($"Cannot redefine number {newWord}");
        }
        var actions = parts.Skip(2)
            .Select(GetOperation)
            // we need to materialize this to a list
            // so that each word is mapped to its current operation
            .ToList();
        operations[newWord.ToLowerInvariant()] = stack =>
        {
            foreach (var action in actions)
            {
                action.Invoke(stack);
            }
        };
    }

    private void EvaluateExpression(Stack<int> stack, string instruction)
    {
        var words = instruction.Split(" ");
        foreach (var word in words)
        {
            GetOperation(word).Invoke(stack);
        }
    }

    private Action<Stack<int>> GetOperation(string word)
    {
        // is it a number?
        if (int.TryParse(word, out var n))
        {
            return stack => stack.Push(n);
        }
        else if (operations.ContainsKey(word.ToLowerInvariant()))
        {
            return operations[word.ToLowerInvariant()];
        }
        else
        {
            throw new InvalidOperationException($"Don't know how to handle {word}");
        }
    }
}