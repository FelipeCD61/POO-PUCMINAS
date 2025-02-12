using System;
using System.Collections.Generic;
using System.Linq;
class Jogo21{
    public static void Main (String[] args){
        Jogador jogadorYou = new Jogador();
        Jogador jogadorPC = new Jogador();

        bool status = true;
    
        while(true){
            int op=0;
            Console.WriteLine($"Suas cartas: {jogadorYou.getCards()}");
            
            do{
                Console.WriteLine("O que deseja? \n1 - Pedir Cartas \n2 - Parar");
                op = int.Parse(Console.ReadLine());
            }while(op < 1 || op > 2);

            switch(op) {
                case 1:
                    jogadorYou.pedirCarta();
                    break;
                case 2:
                    status = jogadorYou.parar();
                    break;
            }

            if(!status) break;

            //Logica do PC
        }
    }
}