﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cards;

public class Player : MonoBehaviour {

    public List<CardID> Deck;

    // Use this for initialization
    void Start() {
        Deck = GenerateDeck();
        GameObject.Find("Players");
        //Deckerstellung
    }

    // Update is called once per frame
    void Update() {
        int count = 1;
        if (count < 3) {
            while (count != 3) {
                CardID card = CardID.Pointcard;
                //Deck.RemoveAt(0);
                if (GameObject.Find("HandCard" + count).GetComponent<Handcards>().cardid == CardID.none) {
                    GameObject Handcard = GameObject.Find("HandCard" + count);
                    SpriteRenderer rend = Handcard.GetComponent<SpriteRenderer>();
                    rend.sprite = Resources.Load<Sprite>(Slave.GetImagePath(card));
                    count++;
                }
            }
        }
    }


    private List<CardID> GenerateDeck() {
        List<CardID> generatedDeck = new List<CardID>();
        int totalcards = 40;
        int pointcards = 15;
        int blankcards = 15;
        int doublecard = 3;
        int blockcard = 3;
        int deletecard = 3;
        int burncard = 3;
        int infernocard = 2;
        int changecard = 3;
        int cancercard = 1;
        int hotpotatoe = 4;
        int nukecard = 1;
        int vortexcard = 2;
        int anchorcard = 1;
        int specialcards = 10;
        int random = 0;
        bool lastspecialcard = false;
        while (totalcards != 0) {
            random = Random.Range(1, 57);
            if (random >= 1 && random <= 15 && blankcards != 0) {
                generatedDeck.Add(CardID.Blankcard);
                totalcards--;
                blankcards--;
                lastspecialcard = true;
            } else if (random >= 16 && random <= 30 && pointcards != 0) {
                generatedDeck.Add(CardID.Pointcard);
                totalcards--;
                pointcards--;
                lastspecialcard = true;
            } else if (random >= 31 && random <= 33 && specialcards != 0 && doublecard != 0 && lastspecialcard) {
                generatedDeck.Add(CardID.Doublecard);
                totalcards--;
                specialcards--;
                doublecard--;
                lastspecialcard = false;
            } else if (random >= 34 && random <= 36 && specialcards != 0 && blockcard != 0 && lastspecialcard) {
                generatedDeck.Add(CardID.Blockcard);
                totalcards--;
                specialcards--;
                blockcard--;
                lastspecialcard = false;
            } else if (random >= 37 && random <= 39 && specialcards != 0 && deletecard != 0 && lastspecialcard) {
                generatedDeck.Add(CardID.Deletecard);
                totalcards--;
                specialcards--;
                deletecard--;
                lastspecialcard = false;
            } else if (random >= 40 && random <= 42 && specialcards != 0 && burncard != 0 && lastspecialcard) {
                generatedDeck.Add(CardID.Burncard);
                totalcards--;
                specialcards--;
                burncard--;
                lastspecialcard = false;
            } else if (random >= 43 && random <= 44 && specialcards != 0 && infernocard != 0 && lastspecialcard) {
                generatedDeck.Add(CardID.Infernocard);
                totalcards--;
                specialcards--;
                infernocard--;
                lastspecialcard = false;
            } else if (random >= 45 && random <= 47 && specialcards != 0 && changecard != 0 && lastspecialcard) {
                generatedDeck.Add(CardID.Changecard);
                totalcards--;
                specialcards--;
                changecard--;
                lastspecialcard = false;
            } else if (random == 48 && specialcards != 0 && cancercard != 0 && lastspecialcard) {
                generatedDeck.Add(CardID.Cancercard);
                totalcards--;
                specialcards--;
                cancercard--;
                lastspecialcard = false;
            } else if (random >= 49 && random <= 52 && specialcards != 0 && hotpotatoe != 0 && lastspecialcard) {
                generatedDeck.Add(CardID.HotPotatoe);
                totalcards--;
                specialcards--;
                hotpotatoe--;
                lastspecialcard = false;
            } else if (random == 53 && specialcards != 0 && nukecard != 0 && lastspecialcard) {
                generatedDeck.Add(CardID.Nukecard);
                totalcards--;
                specialcards--;
                nukecard--;
                lastspecialcard = false;
            } else if (random >= 54 && random <= 55 && specialcards != 0 && vortexcard != 0 && lastspecialcard) {
                generatedDeck.Add(CardID.Vortexcard);
                totalcards--;
                specialcards--;
                vortexcard--;
                lastspecialcard = false;
            } else if (random == 56 && specialcards != 0 && anchorcard != 0 && lastspecialcard) {
                generatedDeck.Add(CardID.Anchorcard);
                totalcards--;
                specialcards--;
                anchorcard--;
                lastspecialcard = false;
            }
        }
        return generatedDeck;
    }
}