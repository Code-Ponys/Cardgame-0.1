﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class BlankCard : Card {

        private void Start() {
            GameObject F = GameObject.Find("Field");
            F.GetComponent<GameManager>().animationDone = true;
        }
    }
}
