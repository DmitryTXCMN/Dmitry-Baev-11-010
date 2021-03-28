using System;
using System.IO;
using System.Collections.Generic;

namespace BracketStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> brackets = new Stack<char>();
            string input;
            using (StreamReader sr = new StreamReader(@"C:\Users\draku\source\repos\BracketStack\BracketStack\text.txt"))
            {
                input = sr.ReadLine();
            }
            foreach (char symbol in input)
            {
                switch (symbol)
                {
                    case '(':
                        brackets.Push('(');
                        break;
                    case '[':
                        brackets.Push('[');
                        break;
                    case '{':
                        brackets.Push('{');
                        break;
                    case ')':
                        if (brackets.Peek() != '(')
                            throw new Exception();
                        brackets.Pop();
                        break;
                    case ']':
                        if (brackets.Peek() != '[')
                            throw new Exception();
                        brackets.Pop();
                        break;
                    case '}':
                        if (brackets.Peek() != '{')
                            throw new Exception();
                        brackets.Pop();
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("all good");
        }
    }
}
