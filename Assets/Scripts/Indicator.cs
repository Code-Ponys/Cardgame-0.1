using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class Indicator : MonoBehaviour {
        int x;
        int y;

        public IndicatorState indicatorState = IndicatorState.unreachable;

        public bool isFieldDeleteable = false;

        public Team team = Team.system;

        public IndicatorType indicatorType;

        bool blocked = true;
        bool reachableMarked = false;

        bool anchorvisible = false;

        GameObject Card;
        SpriteRenderer SpriteRenderer;

        // Use this for initialization
        void Start() {
            Card = GameObject.Find(Slave.GetCardName(CardID.FieldIndicator, x, y));
            SpriteRenderer = Card.GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update() {
            if (indicatorType == IndicatorType.field) {
                StateUpdate();
            }

        }
        public void setData(int xcord, int ycord, Team cardteam, IndicatorType type) {
            x = xcord;
            y = ycord;
            team = cardteam;
            indicatorType = type;
        }


        void StateUpdate() {
            if (indicatorState == IndicatorState.blocked
                && blocked == true
                && GameObject.Find("Field").GetComponent<GameManager>().currentPlayer == team) {
                SpriteRenderer.sprite = Resources.Load<Sprite>(Slave.GetImagePath(CardID.FieldIndicatorGreen, Team.system));
                blocked = false;
            }
            if (indicatorState == IndicatorState.blocked
                && blocked == false
                && GameObject.Find("Field").GetComponent<GameManager>().currentPlayer != team) {
                SpriteRenderer.sprite = Resources.Load<Sprite>(Slave.GetImagePath(CardID.FieldIndicatorRed, Team.system));
                blocked = true;
            }
            if (indicatorState == IndicatorState.anchorfield
                && GameObject.Find("Field").GetComponent<GameManager>().currentChoosedCard == CardID.Anchorcard
                && anchorvisible == false) {
                SpriteRenderer.sprite = Resources.Load<Sprite>(Slave.GetImagePath(CardID.FieldIndicatorYellow, Team.system));
                anchorvisible = true;
            }
            if (anchorvisible == true
                && indicatorState == IndicatorState.anchorfield
                && GameObject.Find("Field").GetComponent<GameManager>().currentChoosedCard != CardID.Anchorcard) {
                SpriteRenderer.sprite = Resources.Load<Sprite>(Slave.GetImagePath(CardID.FieldIndicatorBlack, Team.system));
                anchorvisible = false;
            }
            if (indicatorState == IndicatorState.reachable
                && reachableMarked == false) {
                SpriteRenderer.sprite = Resources.Load<Sprite>(Slave.GetImagePath(CardID.FieldIndicatorGreen, Team.system));
                reachableMarked = true;
            }
            if (indicatorState == IndicatorState.unreachable
                && reachableMarked == true) {
                SpriteRenderer.sprite = Resources.Load<Sprite>(Slave.GetImagePath(CardID.FieldIndicatorBlack, Team.system));
                reachableMarked = false;
            }
            if (indicatorState == IndicatorState.anchorfield
                && reachableMarked == true) {
                SpriteRenderer.sprite = Resources.Load<Sprite>(Slave.GetImagePath(CardID.FieldIndicatorBlack, Team.system));
                reachableMarked = false;
            }
        }
    }
}
