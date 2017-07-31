using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMove : MonoBehaviour {

    private void Start() {
        transform.position = new Vector3(15f, 0, -0.5f);
    }

    public void OnMouseEnter() {
        Vector3 point = new Vector3(15f, 0, -0.5f);
        Vector3 goal = new Vector3(9f, 0, -0.5f);
        Physics.queriesHitTriggers = true;
        point = this.transform.position;
        if (point != goal) {
            transform.Translate(-3, 0, 0);
        }
    }

    public void OnMouseExit() {
        Physics.queriesHitTriggers = true;
        transform.Translate(3f, 0, 0);
    }
   
}
