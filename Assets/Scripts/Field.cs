using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards;

public class Field : MonoBehaviour {

    public CameraController CC;
    protected RoundData RD;
    public FieldProperties FP;

    public List<GameObject> cardsOnField = new List<GameObject>();

    bool lastPlayer = true;

    // Use this for initialization
    void Start() {
        GameObject FieldIndicatorParent = GameObject.Find("FieldIndicator");

        GameObject Startcard = (GameObject)Instantiate(Resources.Load("pf_startpunkt"));
        Startcard.AddComponent<Startpoint>();
        Startcard.transform.parent = this.transform;
        Startcard.name = "Startpunkt 0,0";
        Startcard.transform.localScale = new Vector3(0.3f, 0.3f, 0);

        for (int x = (((FP._size - 1) / 2) * -1); x < ((FP._size - 1) / 2); x++) {
            for (int y = (((FP._size - 1) / 2) * -1); y < ((FP._size - 1) / 2); y++) {
                GameObject FieldIndicator = (GameObject)Instantiate(Resources.Load("emptycards/pf_black"));
                FieldIndicator.transform.parent = FieldIndicatorParent.transform;
                FieldIndicator.transform.position = new Vector3(x, y, -1);
                FieldIndicator.name = "FieldIndicator " + x + "," + y;
                FieldIndicator.transform.localScale = new Vector3(0.320f, 0.320f, 0);
            }
        }

        //CC.CenterCamera();
        print(cardsOnField.Count);
        cardsOnField.Add(Startcard);
        print(cardsOnField.Count);





    }

    // Update is called once per frame
    void Update() {
        //if (lastPlayer != RD.currentPlayer) {
        //    lastPlayer = RD.currentPlayer;
        //    CC.CenterCamera();
        //    print("Kamera korrigiert");
        //}
        if (Input.GetKeyDown(KeyCode.Mouse0)) ToggleMouseField();
    }

    private Card GetCardData(int x, int y) {
        //foreach (Card card in cardsOnField) {
        //    if (card.x == x && card.y == y) {
        //        return card;
        //    }
        //}
        //cardsOnField.Find(index => x == 0 && y == 0);
        return null;
    }

    public void ToggleMouseField() {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float indexX = (float)mouseWorldPos.x;
        float indexY = (float)mouseWorldPos.y;
        print(indexX + "," + indexY);
        print(RoundIt(indexX) + "," + RoundIt(indexY));
    }

    public int RoundIt(float roundme) {
        float floatresult = 0;
        float remains = roundme % 1;
        print(remains);
        if (roundme > 0) {
            if (remains < 0.5) {
                floatresult = roundme - remains;
            } else {
                floatresult = roundme + (1 - remains);
            }
        } else {
            if (remains > -0.5) {
                floatresult = roundme + (remains * -1);
            } else {
                floatresult = roundme - (1 + remains);
            }
        }

        int result = (int)floatresult;

        return result;
    }


}
