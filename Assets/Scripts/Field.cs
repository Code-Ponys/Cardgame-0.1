using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {

    protected CameraController CC;
    protected RoundData RD;

    public List<Card> cardsOnField = new List<Card>();
    bool lastPlayer = true;

    // Use this for initialization
    void Start() {
        CC.CenterCamera();
        
        print("Kamera ausgerichtet");
    }

    // Update is called once per frame
    void Update() {
        //if (lastPlayer != RD.currentPlayer) {
        //    lastPlayer = RD.currentPlayer;
        //    CC.CenterCamera();
        //    print("Kamera korrigiert");
        //}
    }

    private Card GetCardData(int x, int y) {
        foreach (Card card in cardsOnField) {
            if (card.x == x && card.y == y) {
                return card;
            }
        }
        //cardsOnField.Find(index => x == 0 && y == 0);
        return null;
    }


}
