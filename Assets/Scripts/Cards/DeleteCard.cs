using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class DeleteCard : Card {

        // Use this for initialization
        void Start() {
            GameObject F = GameObject.Find("Field");
            if (GameObject.Find("Pointcard " + x + "," + y) != null) {
                for (int i = 0; i < F.GetComponent<Field>().cardsOnField.Count; i++) {
                    if (F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().x == x
                        && F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().y == y) {
                        F.GetComponent<Field>().cardsOnField.RemoveAt(i);
                        break;
                    }
                }
                Destroy(GameObject.Find("Pointcard " + x + "," + y));
            }
            if (GameObject.Find("Blankcard " + x + "," + y) != null) {
                for (int i = 0; i < F.GetComponent<Field>().cardsOnField.Count; i++) {
                    if (F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().x == x
                        && F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().y == y) {
                        F.GetComponent<Field>().cardsOnField.RemoveAt(i);
                        break;
                    }
                }
                Destroy(GameObject.Find("Blankcard " + x + "," + y));
            }
            for (int i = 0; i < F.GetComponent<Field>().cardsOnField.Count; i++) {
                if (F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().x == x
                    && F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().y == y) {
                    F.GetComponent<Field>().cardsOnField.RemoveAt(i);
                        break;
                }
            }
            if (GameObject.Find("Anchorcard " + x + "," + y) != null) {
                for (int i = 0; i < F.GetComponent<Field>().cardsOnField.Count; i++) {
                    if (F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().x == x
                        && F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().y == y) {
                        F.GetComponent<Field>().cardsOnField.RemoveAt(i);
                        break;
                    }
                }
                Destroy(GameObject.Find("Anchorcard " + x + "," + y));
            }
            if (GameObject.Find("Blockcard " + x + "," + y) != null) {
                Block blockdirection = GameObject.Find("Blockcard " + x + "," + y).GetComponent<BlockCard>().blockDirection;
                for (int i = 0; i < F.GetComponent<Field>().cardsOnField.Count; i++) {
                    if (F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().x == x
                        && F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().y == y) {
                        F.GetComponent<Field>().cardsOnField.RemoveAt(i);
                        break;
                    }
                }
                Destroy(GameObject.Find("Blockcard " + x + "," + y));
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
            Destroy(GameObject.Find("Deletecard " + x + "," + y));
        }
        

        // Update is called once per frame
        void Update() {

        }
    }
}
