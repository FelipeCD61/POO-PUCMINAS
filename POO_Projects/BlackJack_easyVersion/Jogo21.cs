using System;
class Jogo21{
    public static void Main (String[] args){
        jogadorYou = new Jogador();
        jogadorPC = new Jogador();
    
        while(true){
            bool status;
            Console.WriteLine($"Suas cartas: {jogadorYou.getCards()}");
            do{
                Console.WriteLine("O que deseja? \n1 - Pedir Cartas \n2 - Parar");
                int op = int.Parse(Console.ReadLine());
            }while(op < 1 || op > 2);

            switch(op) {
                case 1:
                    jogadorYou.pedirCarta();
                case 2:
                    status = jogadorYou.parar();
            }

            if(!status) break;

            //Logica do PC
        }
    }
}