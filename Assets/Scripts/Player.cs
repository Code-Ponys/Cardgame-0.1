using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    List<Card> Deck = new List<Card>();

    List<Card> Hand = new List<Card>();

    // Use this for initialization
    void Start() {
        for (int x = 0; x < 15; x++) {
            Deck.Add(new BlankCard() { x = 0, y = 0, team = 0, state = 0 });
            Deck.Add(new PointCard() { x = 0, y = 0, team = 0, state = 0 });
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
