using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards;

public class Player : MonoBehaviour {



    List<Card> Deck;

    List<Card> Hand = new List<Card>();

    // Use this for initialization
    void Start() {
        Deck = GetDeck();
        

        //Deckerstellung
    }

    // Update is called once per frame
    void Update() {

    }

    private List<Card> GetDeck() {
        List<Card> generatedDeck = new List<Card>();
        for (int x = 0; x < 15; x++) {
            generatedDeck.Add(new BlankCard() { x = 0, y = 0, team = 0, state = 0 });
            generatedDeck.Add(new PointCard() { x = 0, y = 0, team = 0, state = 0 });
        }

        return generatedDeck;
    }
}
