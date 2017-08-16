using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class CancerCard : Card {

        GameObject F;
        GameObject Card;
        GameObject Cardchange;
        SpriteRenderer SpriteRenderer;


        // Use this for initialization
        void Start() {
            F = GameObject.Find("Field");
            Card = GameObject.Find(Slave.GetCardName(CardID.Changecard, x, y));

            for (int i = 0; i < F.GetComponent<Field>().cardsOnField.Count; i++) {
                Cardchange = F.GetComponent<Field>().cardsOnField[i];
                if (Cardchange.GetComponent<Card>().x == x || Cardchange.GetComponent<Card>().y == y) {
                    if (Cardchange.GetComponent<Card>().cardid == CardID.Startpoint || Cardchange.GetComponent<Card>().cardid == CardID.Blankcard) {
                        continue;
                    }

                    switch (Cardchange.GetComponent<Card>().cardid) {
                        case CardID.Blockcard:
                            Block blockdirection = Cardchange.GetComponent<BlockCard>().blockDirection;
                            switch (blockdirection) {
                                case Block.right:
                                    GameObject.Find(Slave.GetCardName(CardID.FieldIndicator, Cardchange.GetComponent<Card>().x + 1, Cardchange.GetComponent<Card>().y)).GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                                    GameObject.Find(Slave.GetCardName(CardID.FieldIndicator, Cardchange.GetComponent<Card>().x + 1, Cardchange.GetComponent<Card>().y)).GetComponent<Indicator>().team = Team.system;
                                    break;
                                case Block.left:
                                    GameObject.Find(Slave.GetCardName(CardID.FieldIndicator, Cardchange.GetComponent<Card>().x - 1, Cardchange.GetComponent<Card>().y)).GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                                    GameObject.Find(Slave.GetCardName(CardID.FieldIndicator, Cardchange.GetComponent<Card>().x - 1, Cardchange.GetComponent<Card>().y)).GetComponent<Indicator>().team = Team.system;
                                    break;
                                case Block.up:
                                    GameObject.Find(Slave.GetCardName(CardID.FieldIndicator, Cardchange.GetComponent<Card>().x, Cardchange.GetComponent<Card>().y + 1)).GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                                    GameObject.Find(Slave.GetCardName(CardID.FieldIndicator, Cardchange.GetComponent<Card>().x, Card.GetComponent<Card>().y + 1)).GetComponent<Indicator>().team = Team.system;
                                    break;
                                case Block.down:
                                    GameObject.Find(Slave.GetCardName(CardID.FieldIndicator, Cardchange.GetComponent<Card>().x, Cardchange.GetComponent<Card>().y - 1)).GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                                    GameObject.Find(Slave.GetCardName(CardID.FieldIndicator, Cardchange.GetComponent<Card>().x, Cardchange.GetComponent<Card>().y - 1)).GetComponent<Indicator>().team = Team.system;
                                    break;
                            }
                            Cardchange.AddComponent<BlankCard>();
                            Cardchange.GetComponent<Card>().cardid = CardID.Blankcard;
                            SpriteRenderer = Cardchange.GetComponent<SpriteRenderer>();
                            SpriteRenderer.sprite = Resources.Load<Sprite>(Slave.GetImagePath(CardID.Blankcard, Cardchange.GetComponent<Card>().team));
                            DestroyImmediate(Cardchange.GetComponent<BlockCard>());
                            break;
                        case CardID.Anchorcard:
                            Team cardteam = Cardchange.GetComponent<Card>().team;
                            int xcord = Cardchange.GetComponent<Card>().x;
                            int ycord = Cardchange.GetComponent<Card>().y;
                            for (int a = 0; a < F.GetComponent<Field>().cardsOnField.Count; a++) {
                                if (F.GetComponent<Field>().cardsOnField[a].GetComponent<Card>().x == xcord
                                    && F.GetComponent<Field>().cardsOnField[a].GetComponent<Card>().y == ycord) {
                                    F.GetComponent<Field>().cardsOnField.RemoveAt(a);
                                    break;
                                }
                            }
                            DestroyImmediate(Cardchange);
                            F.GetComponent<GameManager>().GenerateFieldCard(CardID.Blankcard, xcord, ycord, cardteam);
                            break;
                        case CardID.Pointcard:
                            Cardchange.AddComponent<BlankCard>();
                            Cardchange.GetComponent<Card>().cardid = CardID.Blankcard;
                            SpriteRenderer = Cardchange.GetComponent<SpriteRenderer>();
                            SpriteRenderer.sprite = Resources.Load<Sprite>(Slave.GetImagePath(CardID.Blankcard, Cardchange.GetComponent<Card>().team));
                            DestroyImmediate(Cardchange.GetComponent<PointCard>());
                            break;
                    }
                }
            }
            print(GameObject.Find(Slave.GetCardName(CardID.Cancercard, x, y)).name);
            F.GetComponent<GameManager>().lastSetCard = CardID.Cancercard;
            F.GetComponent<GameManager>().animationDone = true;
            DestroyImmediate(GameObject.Find(Slave.GetCardName(CardID.Cancercard, x, y)));
        }

        // Update is called once per frame
        void Update() {

        }
    }
}
