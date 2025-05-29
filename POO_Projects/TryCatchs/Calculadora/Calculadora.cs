using System;

public class Calculadora
{
    public static void Main(string[] args)
    {
        double num1, num2, resultado = 0;
        char op;
        while (true)
        {
            try
            {
                Console.Write("Digite o 1° número: ");
                num1 = double.Parse(Console.ReadLine());
                Console.Write("Digite o 2° número: ");
                num2 = double.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Entrada inválida. Por favor, digite um número real.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erro: O número digitado é muito grande ou muito pequeno. Tente novamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        while (true)
        {
            try
            {
                Console.Write("\nEscolha uma operação: \n+ > Soma \n- > Subtração \n* > Multiplicação \n/ > Divisão \n% > Modúlo \n>> ");
                op = char.Parse(Console.ReadLine());

                if (op == '+' || op == '-' || op == '*' || op == '/' || op == '%')
                {
                    break;
                }
                else
                {
                    throw new InvalidOperationException("Digite um dos símbolos mostrados!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Digite corretamente uma operação. {ex.Message}");
            }
        }
        while (true)
        {
            try
            {
                switch (op)
                {
                    case '+':
                        resultado = num1 + num2;
                        break;
                    case '-':
                        resultado = num1 - num2;
                        break;
                    case '*':
                        resultado = num1 * num2;
                        break;
                    case '/':
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException("Não é possível dividir por zero.");
                        }
                        resultado = num1 / num2;
                        break;
                    case '%':
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException("Não é possível calcular o módulo por zero.");
                        }
                        resultado = num1 % num2;
                        break;
                    default:
                        Console.WriteLine("Operação inválida. Por favor, escolha uma das opções fornecidas.");
                        break;
                }

                Console.WriteLine($"\nResultado: {num1} {op} {num2} = {resultado}");
                break;
            }
            catch (Exception ex)
            {
                // Captura qualquer outra exceção inesperada durante a operação
                Console.WriteLine($"Ocorreu um erro inesperado durante a operação: {ex.Message}");
            }
        }
    }
    public class InvalidOperationException : Exception
    {
        public InvalidOperationException(string message) : base(message)
        {
        }
    }
}