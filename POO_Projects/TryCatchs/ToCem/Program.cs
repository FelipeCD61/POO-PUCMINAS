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
                string entrada = Console.ReadLine();

                if (entrada.ToLower() == "sair")
                {
                    Console.WriteLine("\nVocê escolheu sair do programa.");
                    break;
                }

                // a) Tratamento de exceção para lidar com a entrada de dados
                numeroAtual = double.Parse(entrada);

                // Verifica se adicionar o próximo número ultrapassaria 100
                if (soma + numeroAtual > 100)
                {
                    // c) Lança a exceção ExcecaoAcimaDeCem quando a soma for superior a 100
                    throw new ExcecaoAcimaDeCem($"A soma ({soma} + {numeroAtual}) excederia 100. A soma atual é {soma}.");
                }

                soma += numeroAtual;
                contador++;
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Entrada inválida. Por favor, digite um número real ou 'sair'.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erro: O número digitado é muito grande ou muito pequeno. Tente novamente.");
            }
            catch (ExcecaoAcimaDeCem ex)
            {
                Console.WriteLine($"\n{ex.Message}");
                // A exceção foi lançada, então a soma já atingiu ou ultrapassou 100.
                // Não adicionamos o último número que causaria o estouro.
                break; // Sai do loop após a exceção personalizada
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        Console.WriteLine($"\n--- Resultados Finais ---");
        Console.WriteLine($"Soma total (antes de ultrapassar 100): {soma:F2}");
        Console.WriteLine($"Número de valores somados: {contador}");

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