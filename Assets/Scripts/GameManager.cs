using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cards;

public class GameManager : MonoBehaviour {
    public List<Card> Cards = new List<Card>();
    public Field Field;
    public MousePos MP;
    public CameraManager CameraController;

    public Player player1;
    public Player player2;

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

    public virtual GameObject GenerateFieldCard(CardID cardid, int x, int y) {
        string pf_path = Slave.GetImagePath(cardid);
        string Cardname;
        int cord_x = x;
        int cord_y = y;
        switch (cardid) {
            default:
                Cardname = "Error " + x + "," + y;
                break;
            case CardID.Blankcard:
                Cardname = "Blankcard " + x + "," + y;
                break;
            case CardID.Pointcard:
                Cardname = "Pointcard " + x + "," + y;
                break;
            case CardID.Startpoint:
                Cardname = "Startpoint " + x + "," + y;
                break;
            case CardID.Blockcard:
                Cardname = "Blockcard " + x + "," + y;
                break;
            case CardID.Indicator:
                Cardname = "FieldIndicator " + x + "," + y;
                break;
            case CardID.Indicatorred:
                Cardname = "FieldIndicatorRed " + x + "," + y;
                break;
        }
        GameObject Card = (GameObject)Instantiate(Resources.Load(pf_path));
        if (cardid == CardID.Indicator) {
            GameObject FieldIndicatorParent = GameObject.Find("FieldIndicator");
            Card.transform.parent = FieldIndicatorParent.transform;
            Card.transform.position = new Vector3(x, y, -1);
        } else if (cardid == CardID.Indicatorred) {
            GameObject FieldIndicatorParentRed = GameObject.Find("FieldIndicator");
            Card.transform.parent = FieldIndicatorParentRed.transform;
            Card.transform.position = new Vector3(x, y, -1);
        } else {
            GameObject FieldParent = GameObject.Find("Field");
            Card.transform.parent = FieldParent.transform;
            Card.transform.position = new Vector3(x, y, -2);
        }
        Card.transform.localScale = new Vector3(0.320f, 0.320f, 0);
        Card.name = Cardname;

        if (cardid == CardID.Startpoint || cardid == CardID.Anchorcard
            || cardid == CardID.Pointcard || cardid == CardID.Blockcard
            || cardid == CardID.Blankcard) {
            GameObject IndicatorLeft = GameObject.Find("FieldIndicator " + (x - 1) + "," + y);
            if (IndicatorLeft != null) {
                SpriteRenderer rend1 = IndicatorLeft.GetComponent<SpriteRenderer>();
                rend1.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorLeft.GetComponent<Indicator>().blocked = false;
            }else { GenerateFieldCard(CardID.Indicatorred, x - 1, y); }

            GameObject IndicatorRight = GameObject.Find("FieldIndicator " + (x + 1) + "," + y);
            if (IndicatorRight != null) {
                SpriteRenderer rend2 = IndicatorRight.GetComponent<SpriteRenderer>();
                rend2.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorRight.GetComponent<Indicator>().blocked = false;
            }else { GenerateFieldCard(CardID.Indicatorred, x + 1, y); }

            GameObject IndicatorDown = GameObject.Find("FieldIndicator " + x + "," + (y - 1));
            if (IndicatorDown != null) {
                SpriteRenderer rend3 = IndicatorDown.GetComponent<SpriteRenderer>();
                rend3.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorDown.GetComponent<Indicator>().blocked = false;
            }else { GenerateFieldCard(CardID.Indicatorred, x, y - 1); }

            GameObject IndicatorUp = GameObject.Find("FieldIndicator " + x + "," + (y + 1));
            if (IndicatorUp != null) {
                SpriteRenderer rend4 = IndicatorUp.GetComponent<SpriteRenderer>();
                rend4.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorUp.GetComponent<Indicator>().blocked = false;
            }else { GenerateFieldCard(CardID.Indicatorred, x, y + 1); }

            //CameraController.CenterCamera();
            GameObject MainCamTest = GameObject.Find("Main Camera");
            MainCamTest.GetComponent<CameraManager>().CenterCamera(x, y);
        }

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
                Card.AddComponent<Indicator>();
                break;
            case CardID.Indicatorred:
                break;
        }
        return Card;
    }

    public virtual void GenerateHandCard(CardID CardID) {
        string pf_path;
        string Cardname;
    }
    public bool IsFieldOccupied(int x, int y) {
        if (x == 0 && y == 0) {
            return true;
        }
        if (GameObject.Find("Blankcard " + x + "," + y) != null) {
            return true;
        }
        if (GameObject.Find("Blockcard " + x + "," + y) != null) {
            return true;
        }
        if (GameObject.Find("Pointcard " + x + "," + y) != null) {
            return true;
        }
        if (GameObject.Find("Blockedfield " + x + "," + y) != null) {
            return true;
        }
        if (GameObject.Find("Anchorcard " + x + "," + y) != null) {
            return true;
        }
        if (GameObject.Find("FieldIndicator " + x + "," + y) == null) {
            return true;
        }
        if (GameObject.Find("FieldIndicator " + x + "," + y).GetComponent<Indicator>().blocked) {
            return true;
        }
        return false;
    }
}
