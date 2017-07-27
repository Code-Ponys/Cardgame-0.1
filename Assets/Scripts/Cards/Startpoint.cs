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
            print("we want to generate");
            GenerateCard();
            print("Startpoint created");
        }

        public override void GenerateCard() {
            Renderer rend = this.GetComponent<Renderer>();
            rend.material.mainTexture = Resources.Load("startpunkt") as Texture;
            this.transform.position = new Vector3(0, 0, -1);
            this.name = "Startpunkt";
        }

        //private void OnEnable() {

        //}
    }
}