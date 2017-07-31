using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideBarMove : MonoBehaviour {

    private void Start() {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector3(240, 0, 0);
    }

    public void MovePanelOut() {
        print("MovePanelOut");
        Vector3 goal = new Vector3(240, 0, 0);
        Vector3 point = new Vector3(-300, 0, 0);
        Physics.queriesHitTriggers = true;
        if (point != goal) {
            RectTransform var = GetComponent<RectTransform>();
            var.anchoredPosition = goal;
            print("MovePanelOut Moved");
        }
    }

    public void MovePanelIn() {
        print("MovePanelIn");
        Vector3 point = new Vector3(240, 0, 0);
        Vector3 goal = new Vector3(-300, 0, 0);
        Physics.queriesHitTriggers = true;
        if (point != goal) {
            RectTransform var = GetComponent<RectTransform>();
            var.anchoredPosition = goal;
            print("MovePanelIn Moved");
        }
    }
}
