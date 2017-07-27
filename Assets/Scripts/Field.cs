using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards;

public class Field : MonoBehaviour {

    protected CameraController CC;
    protected RoundData RD;

    public List<GameObject> cardsOnField = new List<GameObject>();

    bool lastPlayer = true;

    // Use this for initialization
    void Start() {
        GameObject Startcard = GameObject.CreatePrimitive(PrimitiveType.Quad);
        Startcard.transform.parent = this.transform;
        Startcard.AddComponent<Startpoint>();
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


}
