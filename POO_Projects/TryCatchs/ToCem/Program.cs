using System;

public class Program
{
    public class ExcecaoAcimaDeCem : Exception
    {
        public ExcecaoAcimaDeCem(string message) : base(message)
        {
        }
    }

    public static void Main(string[] args)
    {
        double soma = 0;
        int contador = 0;
        double numeroAtual;

        Console.WriteLine("Vamos somar números até que a soma ultrapasse 100.");
        Console.WriteLine("O programa informará a soma antes de exceder 100, a quantidade de números e a média.");

        while (true)
        {
            try
            {
                Console.Write("Digite um número (ou 'sair' para encerrar): ");
                double entrada = double.Parse(Console.ReadLine());

                if (entrada.ToLower() == "sair")
                {
                    Console.WriteLine("\nVocê escolheu sair do programa.");
                    break;
                }

                num = double.Parse(entrada);

                if (soma + num > 100)
                {
                    throw new ExcecaoAcimaDeCem($"A soma ({soma} + {num}) excederia 100. A soma atual é {soma}.");
                }

                soma += num;
                contador++;
            }
            catch (FormatException)
            {
                Console.WriteLine("Digite um número real ou 'sair'.");
            }
            catch (ExcecaoAcimaDeCem ex)
            {
                Console.WriteLine($"\n{ex.Message}");
                break; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inédito: {ex.Message}");
            }
        }

        Console.WriteLine($"Soma total (antes de ultrapassar 100): {soma:F2}");
        Console.WriteLine($"Número de valores somados: {int.Parse(contador)}");

        if (contador > 0)
        {
            double media = soma / contador;
            Console.WriteLine($"Média dos valores somados: {media:F2}");
        }
        else
        {
            Console.WriteLine("Nenhum número válido foi somado.");
        }
    }
}