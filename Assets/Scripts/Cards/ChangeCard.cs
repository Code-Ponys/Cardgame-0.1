using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Cards {
    public class ChangeCard : Card {

        GameObject F;
        GameObject Card;
        GameObject Cardbelow;
        SpriteRenderer SpriteRenderer;
        private bool cardprocessdone;

        // Use this for initialization
        void Start() {
            F = GameObject.Find("Field");
            Card = GameObject.Find(Slave.GetCardName(CardID.Changecard, x, y));


            Cardbelow = GameObject.Find(Slave.GetCardName(CardID.Card, x, y));
            Cardbelow.GetComponent<Card>().cardid = CardID.Blankcard;
            SpriteRenderer = Cardbelow.GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = Resources.Load<Sprite>(Slave.GetImagePath(CardID.Blankcard, Cardbelow.GetComponent<Card>().team));
            F.GetComponent<GameManager>().animationDone = true;

            DestroyImmediate(Card);
        }

        // Update is called once per frame
        void Update() {
        }
    }
}
