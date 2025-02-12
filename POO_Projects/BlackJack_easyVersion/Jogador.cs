using System; 
using System.Collections.Generic;
using System.Linq;
public class Jogador {
    private List<Carta> cartas;
    private int score;
    private Random random;

    public Jogador() {
        cartas = new List<Carta>();
        random = new Random();
        cartas.Add(new Carta(random.Next(1, 12)));
        cartas.Add(new Carta(random.Next(1, 12)));
    }

    public void pedirCarta(){
        int picked = random.Next(1, 12);
        cartas.Add(new Carta(picked));
    }

    public bool parar(){ 
        return false;   
    }

    public List<Carta> getCards() {
        return cartas;
    }

    public int getScore() {
        return score;
    }

    public void setScore(int n) {
        score = n;
    }
}