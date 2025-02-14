using System;
using System.Collections.Generic;
using System.Linq;
class Jogo21{
    public static void Main (String[] args){
        
    int gameScorePC=0,gameScoreYou=0;

        while(true){    

            Jogador jogadorYou = new Jogador();
            Jogador jogadorPC = new Jogador();

            bool statusPlayer = true;
            bool statusPC = true;

            while(statusPlayer){ //Loop do jogador
                int op=0;
                Console.WriteLine("\nSuas cartas:");
                jogadorYou.mostrarCartas();
                
                do{
                    Console.WriteLine("\nO que deseja? \n1 - Pedir Cartas \n2 - Parar");
                    op = int.Parse(Console.ReadLine());
                }while(op < 1 || op > 2);

                switch(op) {
                    case 1:
                        jogadorYou.pedirCarta();
                        break;
                    case 2:
                        statusPlayer = jogadorYou.parar();
                        break;
                    default:
                        break;
                }
            }

            while(statusPC){ //Loop do computador
                if (jogadorPC.getScore() <= 17){
                    jogadorPC.pedirCarta();
                } else {
                    statusPC = jogadorPC.parar();
                }
            }

            Console.WriteLine("\nCartas do computador:");
            jogadorPC.mostrarCartas();
            Console.WriteLine("\nSuas cartas:");
            jogadorYou.mostrarCartas();
            Console.WriteLine();

            int next21You = Math.Abs(21 - jogadorYou.getScore());
            int next21PC = Math.Abs(21 - jogadorPC.getScore());
            
            if(jogadorYou.getScore()>21 && jogadorPC.getScore()>21){
                Console.WriteLine("\nNinguém venceu...");
            } 
            else if(jogadorYou.getScore()>21 && jogadorPC.getScore()<=21){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nO computador venceu!");
                Console.ResetColor();
                gameScorePC++;
            } 
            else if (jogadorPC.getScore() > 21){
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nVocê venceu!");
                Console.ResetColor();
                gameScoreYou++;
            } 
            else {
                Console.WriteLine();
                if(next21You < next21PC){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Você venceu!");
                    Console.ResetColor();
                    gameScoreYou++;
                } 
                else if(next21PC < next21You){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O computador venceu!");
                    Console.ResetColor();
                    gameScorePC++;
                } 
                else {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Empatou!");
                    Console.ResetColor();
                }
            }

            Console.WriteLine($"\nJogador {gameScoreYou} X {gameScorePC} Computador");

            Console.WriteLine("\nJogar mais? \n1 - sim \n2 - não");
            int more = int.Parse(Console.ReadLine());

            if(more!=1) break; Console.Clear();
        }
    }
}