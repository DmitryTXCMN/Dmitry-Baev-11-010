using System;

namespace Anonimous
{
    class Program
    {
        delegate int Method();
        delegate int SumMethods(Method[] array);

        static int GetNumber()
        {
            Random rng = new Random((int)DateTime.Now.Ticks);
            return rng.Next(0, 100);
        }

        static void Main(string[] args)
        {
            Method[] dosmthng = new Method[50];
            for (int i = 0; i < dosmthng.Length; i++)
            {
                dosmthng[i] = GetNumber;
            }

            SumMethods answer = delegate (Method[] input)
            {
                int sum = 0;
                for (int i = 0; i < dosmthng.Length; i++)
                {
                    sum += input[i]();
                }
                return sum/dosmthng.Length;
            };

            Console.WriteLine(answer(dosmthng));
        }
    }
}
