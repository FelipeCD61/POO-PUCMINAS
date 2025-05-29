using System;

public class PreencherVetor
{
    public static void Main(string[] args)
    {
        int[] vetor = new int[10];
        int valor,posicao;

        Console.WriteLine("Preencha um vetor de 10 posições.");

        for (int i = 0; i < vetor.Length; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"\nDigite o valor para colocar no vetor: ");
                    valor = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro inesperado ao ler o valor: {ex.Message}");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write($"Digite a posição (1 a {vetor.Length}) para inserir o valor {valor}: ");
                    posicao = int.Parse(Console.ReadLine());

                    if (posicao < 0 || posicao >= vetor.Length)
                    {
                        throw new IndexOutOfRangeException($"A posição {posicao} é inválida. Digite um número entre 0 e {vetor.Length - 1}.");
                    }

                    vetor[posicao] = valor;
                    Console.WriteLine($"Valor {valor} inserido na posição {posicao}.");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro para a posição.");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Digito fora de uma posição existente do vetor {ex.Message}.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro inesperado ao ler a posição: {ex.Message}.");
                }
            }
        }

        Console.WriteLine("\nVetor completo:");
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.WriteLine($"Posição {i}: {vetor[i]}");
        }
    }
}