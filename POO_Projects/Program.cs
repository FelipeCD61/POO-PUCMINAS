using System;
    class Program{
        public static void Main (String[] args){
        Random random = new Random();
        int[] vetor = new int[20];
        int[] xPositions = new int[20];
        int num, max=int.MinValue, min=int.MaxValue, firstNum=0, repeats=0;

        for(int i=0; i<20; i++){
            vetor[i] = random.Next(0, 11);
            Console.Write(vetor[i] + " ");
        }

        do{
            Console.WriteLine("\nDigite um número entre 0 e 10:");
            num=int.Parse(Console.ReadLine());
            if (num<0 || num>10){
                Console.WriteLine("Por favor, digite um número entre 0 e 10.");        
            }
        } while (num<0 || num>10);

        for(int i=0; i<20; i++){
            if(vetor[i] > max){
                max = vetor[i];
            }
            if(vetor[i] < min){
                min = vetor[i];
            }
        }

        for(int i=0; i<20; i++){ //Análise da primeira ocorrência do elemento x ou num
            if(vetor[i] == num){
                firstNum = i;
                break;
            }
        }

        for(int i=0; i<20; i++){ //Análise das posições de x no vetor e de quantas vezes aparece
            if(vetor[i] == num){
                xPositions[repeats] = i;
                repeats++;
            }
        }

        Console.WriteLine("\nO maior valor do vetor é {0} e o menor é {1}", max, min);
        Console.WriteLine("A primeira ocorrência de {0} no vetor é na posição {1}", num, firstNum);
        Console.Write($"O elemento {num} ocorre nas posições ");
        for(int i=0; i<repeats; i++){
            Console.Write(xPositions[i] + " ");
        }
        Console.WriteLine($"\nO elemento {num} aparece {repeats} vezes");

    }
}