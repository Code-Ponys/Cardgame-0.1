using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class DeleteCard : Card {

        // Use this for initialization
        void Start() {
            GameObject F = GameObject.Find("Field");
            GameObject Card = GameObject.Find("Card " + x + "," + y);
            if (Card != null) {
                for (int i = 0; i < F.GetComponent<Field>().cardsOnField.Count; i++) {
                    if (F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().x == x
                        && F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().y == y) {
                        F.GetComponent<Field>().cardsOnField.RemoveAt(i);
                        break;
                    }
                }
                if (Card.GetComponent<Card>().cardid == CardID.Blockcard) {
                    Block blockdirection = GameObject.Find("Card " + x + "," + y).GetComponent<BlockCard>().blockDirection;
                    switch (blockdirection) {
                        case Block.right:
                            GameObject.Find("FieldIndicator " + (x + 1) + "," + y).GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                            break;
                        case Block.left:
                            GameObject.Find("FieldIndicator " + (x - 1) + "," + y).GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                            break;
                        case Block.up:
                            GameObject.Find("FieldIndicator " + x + "," + (y + 1)).GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                            break;
                        case Block.down:
                            GameObject.Find("FieldIndicator " + x + "," + (y - 1)).GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                            break;
                    }
                }
                Destroy(GameObject.Find("Card " + x + "," + y));
            }
            Destroy(GameObject.Find("DeleteCard " + x + "," + y));
        }


        // Update is called once per frame
        void Update() {

        }
    }
}
