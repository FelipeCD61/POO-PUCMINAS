using System;
public class Primo
{
    public static void Main(string[] args)
    {
        int n;
        while (true)
        {
            try
            {
                Console.Write("Digite um valor inteiro: ");
                n = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Entrada inválida, digite um número inteiro");
            }
        }
        if (EhPrimo(n))
        {
            Console.WriteLine($"\n{n} É primo!");
        }
        else
        {
            Console.WriteLine($"\n{n} NÃO é primo!");
        }
    }

    public static bool EhPrimo(int numero)
    {
        if (numero <= 1)
        {
            return false;
        }

        for (int i = 2; i * i <= numero; i++)
        {
            if (numero % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}