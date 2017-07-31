using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class Startpoint : Card {

        public new int x = 0;
        public new int y = 0;
        protected override CardID? GetType() {
            return CardID.Startpoint;
        }

        protected override Team? GetTeam() {
            return Team.system;
        }

        protected override State? GetState() {
            return State.field;
        }

        public void Start() {
            print("we want to generate2");
            GenerateCard();
            print("Startpoint created");

           // Instantiate(Resources.Load())
        }

        public override void GenerateCard() {
            SpriteRenderer rend = this.GetComponent<SpriteRenderer>();
            rend.sprite = Resources.Load<Sprite>("startpunkt");
            Debug.Log(Resources.Load("startpunkt") + "," + rend.material.mainTexture + "," + (Resources.Load("startpunkt") as Texture));
            this.transform.position = new Vector3(0, 0, -1);
            this.name = "Startpunkt";
        }

        //private void OnEnable() {

        //}
    }
}