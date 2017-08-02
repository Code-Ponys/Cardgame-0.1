using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class Indicator : MonoBehaviour {

        public bool blocked = true;

        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update() {

        }
        public bool isBlocked() {
            return blocked;
        }
    }
}
