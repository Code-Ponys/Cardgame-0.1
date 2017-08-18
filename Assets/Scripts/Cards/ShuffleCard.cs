﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class ShuffleCard : Card {
        private bool cardprocessdone;
        GameObject F;
        GameObject CardLeft;
        GameObject CardRight;
        GameObject CardDown;
        GameObject CardUp;
        GameObject CardIndicatorLeft;
        GameObject CardIndicatorRight;
        GameObject CardIndicatorDown;
        GameObject CardIndicatorUp;

        // Use this for initialization
        void Start() {
            F = GameObject.Find("Field");
            F.GetComponent<GameManager>().cardlocked = true;
            F.GetComponent<GameManager>().currentChoosedCard = CardID.none;
            CardLeft = GameObject.Find(Slave.GetCardName(CardID.Card, x - 1, y));
            CardRight = GameObject.Find(Slave.GetCardName(CardID.Card, x + 1, y));
            CardDown = GameObject.Find(Slave.GetCardName(CardID.Card, x, y - 1));
            CardUp = GameObject.Find(Slave.GetCardName(CardID.Card, x, y + 1));
            CardIndicatorLeft = GameObject.Find(Slave.GetCardName(CardID.CardIndicator, x - 1, y));
            CardIndicatorRight = GameObject.Find(Slave.GetCardName(CardID.CardIndicator, x + 1, y));
            CardIndicatorDown = GameObject.Find(Slave.GetCardName(CardID.CardIndicator, x, y - 1));
            CardIndicatorUp = GameObject.Find(Slave.GetCardName(CardID.CardIndicator, x, y + 1));

        }

        // Update is called once per frame
        void Update() {

            if (CardLeft != null && CardIndicatorLeft.GetComponent<Indicator>().indicatorColor != IndicatorColor.yellowcovered) {
                if (CardLeft.GetComponent<Card>().cardid == CardID.Pointcard || CardLeft.GetComponent<Card>().cardid == CardID.Pointcard
                    && CardLeft.GetComponent<Card>().team == F.GetComponent<GameManager>().currentPlayer) {
                    CardIndicatorLeft.GetComponent<Indicator>().indicatorColor = IndicatorColor.yellowcovered;
                    print("CardIndicatorLeft is yellowcovered");
                }
            }
            if (CardRight != null && CardIndicatorRight.GetComponent<Indicator>().indicatorColor != IndicatorColor.yellowcovered) {
                if (CardRight.GetComponent<Card>().cardid == CardID.Pointcard || CardRight.GetComponent<Card>().cardid == CardID.Pointcard
                    && CardRight.GetComponent<Card>().team == F.GetComponent<GameManager>().currentPlayer) {
                    CardIndicatorRight.GetComponent<Indicator>().indicatorColor = IndicatorColor.yellowcovered;
                    print("CardIndicatorRight is yellowcovered");
                }
            }
            if (CardDown != null && CardIndicatorDown.GetComponent<Indicator>().indicatorColor != IndicatorColor.yellowcovered) {
                if (CardDown.GetComponent<Card>().cardid == CardID.Pointcard || CardDown.GetComponent<Card>().cardid == CardID.Pointcard
                    && CardDown.GetComponent<Card>().team == F.GetComponent<GameManager>().currentPlayer) {
                    CardIndicatorDown.GetComponent<Indicator>().indicatorColor = IndicatorColor.yellowcovered;
                    print("CardIndicatorDown is yellowcovered");
                }
            }
            if (CardUp != null && CardIndicatorUp.GetComponent<Indicator>().indicatorColor != IndicatorColor.yellowcovered) {
                if (CardUp.GetComponent<Card>().cardid == CardID.Pointcard || CardUp.GetComponent<Card>().cardid == CardID.Pointcard
                    && CardUp.GetComponent<Card>().team == F.GetComponent<GameManager>().currentPlayer) {
                    CardIndicatorUp.GetComponent<Indicator>().indicatorColor = IndicatorColor.yellowcovered;
                    print("CardIndicatorUp is yellowcovered");
                }
            }

            if (cardprocessdone) return;
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                if (F.GetComponent<GameManager>().cardlocked == true) {
                    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    int indexX = F.GetComponent<Field>().RoundIt(mouseWorldPos.x);
                    int indexY = F.GetComponent<Field>().RoundIt(mouseWorldPos.y);
                    GameObject CardIndicator = GameObject.Find(Slave.GetCardName(CardID.CardIndicator, indexX, indexY));
                    GameObject Card = GameObject.Find(Slave.GetCardName(CardID.Card, indexX, indexY));
                    if (Card == null) return;

                    if (CardIndicator.GetComponent<Indicator>().currentcolor == IndicatorColor.yellowcovered) {
                        GameObject FirstCard = GameObject.Find(Slave.GetCardName(CardID.Card, x, y));
                        GameObject SecondCard = Card;
                        int x1 = FirstCard.GetComponent<Card>().x;
                        int y1 = FirstCard.GetComponent<Card>().y;
                        int x2 = SecondCard.GetComponent<Card>().x;
                        int y2 = SecondCard.GetComponent<Card>().y;

                        FirstCard.transform.position = new Vector3(x2, y2, -2);
                        SecondCard.transform.position = new Vector3(x1, y1, -2);

                        FirstCard.name = Slave.GetCardName(CardID.Card, x2, y2);
                        SecondCard.name = Slave.GetCardName(CardID.Card, x1, y1);

                        FirstCard.GetComponent<Card>().x = x2;
                        FirstCard.GetComponent<Card>().y = y2;
                        SecondCard.GetComponent<Card>().x = x1;
                        SecondCard.GetComponent<Card>().y = y1;

                        cardprocessdone = true;
                        F.GetComponent<GameManager>().currentChoosedCard = CardID.Shufflecard;
                        F.GetComponent<GameManager>().animationDone = true;
                        F.GetComponent<GameManager>().RemoveCard(GameObject.Find(Slave.GetCardName(CardID.Shufflecard, x, y)));
                    }
                }
            }
        }
    }
}