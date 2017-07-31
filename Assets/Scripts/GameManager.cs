using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cards;

public class GameManager : MonoBehaviour {
    public List<Card> Cards = new List<Card>();
    public Field Field;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    public void ChangeToScene(string SceneToChangeTo) {
        SceneManager.LoadScene(SceneToChangeTo);
    }

    public void QuitGame() {
        Application.Quit();
    }

    //private void OnMouseDown() {
    //    print("klick");
    //    Physics.queriesHitTriggers = true;
    //    ChangeGameCard();
    //}


    //private void ChangeGameCard() {
    //    GameObject g1 = GameObject.Find("HandCard1");
    //    Renderer rend1 = g1.GetComponent<Renderer>();
    //    rend1.material.mainTexture = Resources.Load("startpunkt") as Texture;

    //    GameObject g2 = GameObject.Find("HandCard2");
    //    SpriteRenderer rend2 = g2.GetComponent<SpriteRenderer>();
    //    rend2.sprite = Resources.Load<Sprite>("startpunkt");
    //    g2.transform.localScale = new Vector3(1, 1, 1);
    //}

    public virtual GameObject GenerateFieldCard(CardID cardid, int x, int y) {
        string pf_path;
        string Cardname;
        switch (cardid) {
            default:
                Cardname = "Error " + x + "," + y;
                pf_path = "cards/pf_Errorcard";
                break;
            case CardID.Blankcard:
                Cardname = "Blankcard " + x + "," + y;
                pf_path = "cards/pf_Blankcard";
                break;
            case CardID.Pointcard:
                Cardname = "Pointcard " + x + "," + y;
                pf_path = "cards/pf_PointCard";
                break;
            case CardID.Startpoint:
                Cardname = "Startpoint " + x + "," + y;
                pf_path = "cards/pf_Startpoint";
                break;
            case CardID.Blockcard:
                Cardname = "Blockcard " + x + "," + y;
                pf_path = "cards/pf_Blockcard";
                break;
            case CardID.Indicator:
                pf_path = "emptycards/pf_black";
                Cardname = "FieldIndicator " + x + "," + y;
                break;
        }
        GameObject Card = (GameObject)Instantiate(Resources.Load(pf_path));
        if (cardid == CardID.Indicator) {
            GameObject FieldIndicatorParent = GameObject.Find("FieldIndicator");
            Card.transform.parent = FieldIndicatorParent.transform;
            Card.transform.position = new Vector3(x, y, -1);
        } else {
            GameObject FieldParent = GameObject.Find("Field");
            Card.transform.parent = FieldParent.transform;
            Card.transform.position = new Vector3(x, y, -2);
        }
        Card.transform.localScale = new Vector3(0.320f, 0.320f, 0);
        Card.name = Cardname;

        switch (cardid) {
            default:
                Card.AddComponent<NotImplemented>();
                break;
            case CardID.Blankcard:
                Card.AddComponent<BlankCard>();
                break;
            case CardID.Pointcard:
                Card.AddComponent<PointCard>();
                break;
            case CardID.Startpoint:
                Card.AddComponent<Startpoint>();
                break;
            case CardID.Blockcard:
                Card.AddComponent<BlockCard>();
                break;
            case CardID.Indicator:
                break;
        }
        return Card;
    }

    public virtual void GenerateHandCard(CardID CardID, int x, int y) {
        string pf_path;
        string Cardname;

    }
}
