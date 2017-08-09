using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {

    public class BlockCard : Card {

        public Block blockDirection;

        private void Start() {
            GameObject IndicatorLeft = GameObject.Find("FieldIndicator " + (x - 1) + "," + y);
            if (IndicatorLeft != null) {
                SpriteRenderer rend1 = IndicatorLeft.GetComponent<SpriteRenderer>();
                rend1.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorLeft.GetComponent<Indicator>().indicatorState = IndicatorState.reachable;
            }

            GameObject IndicatorRight = GameObject.Find("FieldIndicator " + (x + 1) + "," + y);
            if (IndicatorRight != null) {
                SpriteRenderer rend2 = IndicatorRight.GetComponent<SpriteRenderer>();
                rend2.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorRight.GetComponent<Indicator>().indicatorState = IndicatorState.reachable;
            }

            GameObject IndicatorDown = GameObject.Find("FieldIndicator " + x + "," + (y - 1));
            if (IndicatorDown != null) {
                SpriteRenderer rend3 = IndicatorDown.GetComponent<SpriteRenderer>();
                rend3.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorDown.GetComponent<Indicator>().indicatorState = IndicatorState.reachable;
            }

            GameObject IndicatorUp = GameObject.Find("FieldIndicator " + x + "," + (y + 1));
            if (IndicatorUp != null) {
                SpriteRenderer rend4 = IndicatorUp.GetComponent<SpriteRenderer>();
                rend4.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorUp.GetComponent<Indicator>().indicatorState = IndicatorState.reachable;
            }
        }
    }
}
