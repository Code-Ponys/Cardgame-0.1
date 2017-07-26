using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {

    protected 

    List<Card> field = new List<Card>();

    // Use this for initialization
    void Start() {
        field.Add(new Startpoint());
    }

    // Update is called once per frame
    void Update() {



    }

    private int GetCardData(int x, int y) {
        field.Find(index => x == 0 && y == 0);
        return 0;
    }
}
