using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class Startpoint : Card {

        public new int x = 0;
        public new int y = 0;
        public Team team = Team.system;
        public State state = State.field;

        public void Start() {
            //GenerateCard();
        }
    }
}