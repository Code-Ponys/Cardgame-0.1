using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class PointCard : Card {

        public new int x { get; set; }
        public new int y { get; set; }
        public State state;

        public Team team;

        private void Start() {
            //GenerateCard();
        }
    }
}

