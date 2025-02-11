using System; 
public class Jogador {
    private ArrayList<Carta> cartas;
    private int score;

    Random random = new Random();

    Jogador() {
        cartas = new ArrayList<Carta>;
        int picked1 = random.Next(0, 12);
        int picked2 = random.Next(0, 12);

        cartas.add(picked1, picked2);
    }

    public void pedirCarta(){
        int picked = random.Next(0, 12);
        caratas.add(new carta(picked));
    }

    public bool parar(){ 
        return false;   
    }

    public ArrayList<Card> getCards() {
        return cartas;
    }

    public void setCards(ArrayList<Carta> cartas) {
        this.cartas = cartas;
    }

    public int getScore() {
        return score;
    }

    public void setScore(int n) {
        score = n;
    }
}