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
        else if (word == "+")
        {
            stack.Push(stack.Pop() + stack.Pop());
        }
        else if (word == "-")
        {
            stack.Push(- stack.Pop() + stack.Pop());
        }
    }
}