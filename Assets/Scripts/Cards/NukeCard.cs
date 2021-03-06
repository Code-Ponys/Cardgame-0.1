﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Cards {
    public class NukeCard : Card {

        // Use this for initialization
        void Start() {
            GameObject F = GameObject.Find("Field");
            while (F.GetComponent<Field>().cardsOnField.Count != 0) {
                GameObject RemoveCard = F.GetComponent<Field>().cardsOnField[0];
                F.GetComponent<GameManager>().RemoveCard(RemoveCard);
            }
            F.GetComponent<GameManager>().GenerateFieldCard(CardID.Startpoint, 0, 0);
            F.GetComponent<GameManager>().animationDone = true;
            F.GetComponent<GameManager>().RemoveCard(GameObject.Find(Slave.GetCardName(CardID.Nukecard, x, y)));
        }

        // Update is called once per frame
        void Update() {

        }
    }
}
