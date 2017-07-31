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

            //GenerateCard();


           // Instantiate(Resources.Load())
        }
    }
}