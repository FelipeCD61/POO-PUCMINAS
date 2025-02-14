using System;
using System.Threading;

public static class Program
{
    class Carta
    {
        private static Random random = new Random();
        public int Valor { get; }

        public Carta()
        {
            Valor = random.Next(1, 12);
        }
    }

    class Jogador
    {
        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private int maototal;
        public int MaoTotal
        {
            get { return maototal; }
            set { maototal = value; }
        }
        private Carta carta1;
        public Carta Carta1 { get { return carta1; } }

        private Carta carta2;
        public Carta Carta2 { get { return carta2; } }

        private int pontuacao = 0;
        public int Pontuacao
        {
            get { return pontuacao; }
            set { pontuacao = value; }
        }


        // Função de atribuir nome ao jogador e somar suas cartas
        public Jogador(string nome)
        {
            this.Nome = nome;
            carta1 = new Carta();
            carta2 = new Carta();
            MaoTotal = carta1.Valor + carta2.Valor;
        }

        // Função de pegar carta
        public void PegarNovaCarta()
        {
            Carta novaCarta = new Carta();
            MaoTotal += novaCarta.Valor;
            Console.WriteLine($"\n{Nome} pegou uma nova carta: {novaCarta.Valor}");
            Console.WriteLine($"Total agora: {MaoTotal}");
        }
        // Função para limpar a mão
        public void ResetarMao()
        {
            carta1 = new Carta();
            carta2 = new Carta();
            MaoTotal = carta1.Valor + carta2.Valor;
        }
    }

    class BlackJack
    {
        static void Main(string[] args)
        {
            bool jogarNovamente = true;
            int pontuacaoJogador = 0;
            int pontuacaoComputador = 0;
            Jogador player = new Jogador("Jogador");
            Jogador computador = new Jogador("Computador");

            while (jogarNovamente)
            {
                Console.Clear(); // Limpa o console para começar um novo jogo
                player.ResetarMao();
                computador.ResetarMao();
                Console.WriteLine("\nBem-vindo ao BlackJack!");
                Console.WriteLine($"Suas cartas somam: {player.MaoTotal}");
                Console.WriteLine($"O computador tem: {computador.MaoTotal} (oculto)");

                // Turno do jogador
                while (player.MaoTotal < 21)
                {
                    Console.WriteLine("\n1 - Comprar nova carta");
                    Console.WriteLine("2 - Parar");
                    Console.Write("Escolha: ");
                    int op = int.Parse(Console.ReadLine());

                    if (op == 1)
                    {
                        player.PegarNovaCarta();
                        if (player.MaoTotal > 21)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Você estourou! O computador venceu.");
                            Console.ResetColor();
                            computador.Pontuacao++;
                            break;
                        }

                        Thread.Sleep(2000);
                        // Após o jogador pegar a carta, o computador também pega uma
                        computador.PegarNovaCarta();

                        // Verifica se o computador estourou
                        if (computador.MaoTotal > 21)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("O computador estourou! Você venceu.");
                            Console.ResetColor();
                            player.Pontuacao++;
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Você decidiu parar.");
                        break;
                    }
                    Thread.Sleep(1500);
                }

                // Determinar vencedor caso o jogador tenha parado ou estourado
                if (player.MaoTotal <= 21 && computador.MaoTotal <= 21)
                {
                    Console.WriteLine($"\nTotal do {player.Nome}: {player.MaoTotal}");
                    Console.WriteLine($"Total do {computador.Nome}: {computador.MaoTotal}");

                    if (player.MaoTotal > computador.MaoTotal)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Você venceu!");
                        Console.ResetColor();
                        player.Pontuacao++;
                    }
                    else if (computador.MaoTotal > player.MaoTotal)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O Computador venceu!");
                        Console.ResetColor();
                        computador.Pontuacao++;
                    }
                    else
                    {
                        Console.WriteLine("Empate! Ninguém venceu.");
                    }
                }

                // Exibir a pontuação de ambos os jogadores
                Console.WriteLine($"\nPontuação Atual: Jogador {player.Pontuacao} x {computador.Pontuacao} Computador");

                // Perguntar se deseja jogar novamente
                Console.Write("\nJogar novamente? (s/n): ");
                string resposta = Console.ReadLine().ToLower();
                jogarNovamente = resposta == "s";
            }
        }
    }
}
