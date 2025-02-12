using System;
using System.Linq;
public class Carta {
    private int number;

    public Carta(int n) {
        number = n;
    }

    public int getNum() {
        return number;
    }

    public void setNum(int n) {
        number = n;
    }
}