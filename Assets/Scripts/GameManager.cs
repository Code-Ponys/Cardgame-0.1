using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cards;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
    public List<Card> Cards = new List<Card>();
    public Field Field;
    public MousePos MP;
    public CameraManager CameraController;

    public Player[] players;
    public Player PlayerBlue { get { return players[0]; } }
    public Player PlayerRed { get { return players[1]; } }

    public Image SideBarBlue;
    public Image SideBarRed;
    public Canvas ChangePlayer;
    string currentChoosedCardName;

    public Team currentPlayer;
    public CardID currentChoosedCard;
    public bool animationDone;

    // Use this for initialization
    void Start() {
        players = new Player[2];
        players[0] = GameObject.Find("PlayerBlue").GetComponent<Player>();
        players[1] = GameObject.Find("PlayerRed").GetComponent<Player>();
        players[0].Init(Team.blue);
        players[1].Init(Team.red);
        GameObject.Find("Field").GetComponent<GameManager>().currentPlayer = Team.blue;
        print("start player: " + currentPlayer);

        GameObject PlayerName = GameObject.Find("TextSpieler");
        PlayerName.GetComponent<Text>().text = "Spieler 1";
        PlayerBlue.RefillHand(currentPlayer);
        Canvas ChangePlayer = GameObject.Find("PlayerChange").GetComponent<Canvas>();
        Image SideBarBlue = GameObject.Find("SideMenu Blue").GetComponent<Image>();
        Image SideBarRed = GameObject.Find("SideMenu Red").GetComponent<Image>();
        SideBarRed.enabled = false;
        ChangePlayer.enabled = false;
        animationDone = false;
    }

    // Update is called once per frame
    void Update() {


        if (animationDone == true) {
            RemovePlacedCardFromHand();
            print("player Change");
            TogglePlayerScreen();
            animationDone = false;
        }
    }

    public void ChangeToScene(string SceneToChangeTo) {
        SceneManager.LoadScene(SceneToChangeTo);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public virtual GameObject GenerateFieldCard(CardID cardid, int x, int y) {
        if (cardid == CardID.ChoosedCard) {
            cardid = currentChoosedCard;
        }
        if (currentChoosedCard == CardID.placed || cardid == CardID.none) {
            return null;
        }
        string pf_path = Slave.GetImagePathPf(cardid, currentPlayer);
        string Cardname;
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
            } else { GenerateFieldCard(CardID.Indicatorred, x - 1, y); }

            GameObject IndicatorRight = GameObject.Find("FieldIndicator " + (x + 1) + "," + y);
            if (IndicatorRight != null) {
                SpriteRenderer rend2 = IndicatorRight.GetComponent<SpriteRenderer>();
                rend2.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorRight.GetComponent<Indicator>().blocked = false;
            } else { GenerateFieldCard(CardID.Indicatorred, x + 1, y); }

            GameObject IndicatorDown = GameObject.Find("FieldIndicator " + x + "," + (y - 1));
            if (IndicatorDown != null) {
                SpriteRenderer rend3 = IndicatorDown.GetComponent<SpriteRenderer>();
                rend3.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorDown.GetComponent<Indicator>().blocked = false;
            } else { GenerateFieldCard(CardID.Indicatorred, x, y - 1); }

            GameObject IndicatorUp = GameObject.Find("FieldIndicator " + x + "," + (y + 1));
            if (IndicatorUp != null) {
                SpriteRenderer rend4 = IndicatorUp.GetComponent<SpriteRenderer>();
                rend4.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorUp.GetComponent<Indicator>().blocked = false;
            } else { GenerateFieldCard(CardID.Indicatorred, x, y + 1); }

            //CameraController.CenterCamera();
            GameObject MainCamTest = GameObject.Find("Main Camera");
            MainCamTest.GetComponent<CameraManager>().CenterCamera(x, y);
        }

        switch (cardid) {
            default:
                Card.AddComponent<NotImplemented>();
                Card.GetComponent<NotImplemented>().team = currentPlayer;
                break;
            case CardID.Blankcard:
                Card.AddComponent<BlankCard>();
                Card.GetComponent<BlankCard>().team = currentPlayer;
                break;
            case CardID.Pointcard:
                Card.AddComponent<PointCard>();
                Card.GetComponent<PointCard>().team = currentPlayer;
                Card.GetComponent<PointCard>().x = x;
                Card.GetComponent<PointCard>().y = y;
                break;
            case CardID.Startpoint:
                Card.AddComponent<Startpoint>();
                Card.GetComponent<Startpoint>().team = currentPlayer;
                break;
            case CardID.Blockcard:
                Card.AddComponent<BlockCard>();
                Card.GetComponent<BlockCard>().team = currentPlayer;
                break;
            case CardID.Indicator:
                Card.AddComponent<Indicator>();
                break;
            case CardID.Indicatorred:
                break;
        }

        GameObject.Find("Field").GetComponent<GameManager>().animationDone = true;
        if (cardid != CardID.Indicator) {
            GameObject.Find("Field").GetComponent<Field>().cardsOnField.Add(Card);
        }
        return Card;
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

    public void NewRound() {
        print("New Round!");
        print("Letzter Spieler: " + currentPlayer);
        if (currentPlayer == Team.blue) {
            currentPlayer = Team.red;
        } else {
            currentPlayer = Team.blue;
        }
        print("Nächster Spieler: " + currentPlayer);
        currentChoosedCard = CardID.none;
        animationDone = false;

        //TODO Change Handcards
        //TODO Fade in Black Scene
        if (currentPlayer == Team.blue) {
            GameObject.Find("Field").GetComponent<GameManager>().SideBarBlue.enabled = true;
            GameObject.Find("Field").GetComponent<GameManager>().SideBarRed.enabled = false;
            GameObject.Find("Field").GetComponent<GameManager>().players[0].RefillHand(currentPlayer);
            GameObject PlayerName = GameObject.Find("TextSpieler");
            PlayerName.GetComponent<Text>().text = "Spieler 1";
        } else {
            GameObject.Find("Field").GetComponent<GameManager>().SideBarBlue.enabled = false;
            GameObject.Find("Field").GetComponent<GameManager>().SideBarRed.enabled = true;
            GameObject.Find("Field").GetComponent<GameManager>().players[1].RefillHand(currentPlayer);

            GameObject PlayerName = GameObject.Find("TextSpieler");
            PlayerName.GetComponent<Text>().text = "Spieler 2";
        }
        TogglePlayerScreen();
    }

    public void OnCardClick() {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject.Find("Field").GetComponent<GameManager>().currentChoosedCardName = name;
        GameObject currentChoosedCardGO = GameObject.Find(name);
        currentChoosedCard = currentChoosedCardGO.GetComponent<Handcards>().cardid;
        print(currentChoosedCard + " ausgewählt");
    }

    public void TogglePlayerScreen() {
        GameObject.Find("Field").GetComponent<GameManager>().ChangePlayer.enabled = !GameObject.Find("Field").GetComponent<GameManager>().ChangePlayer.enabled;
        print("Player Screen Toggle");
    }

    void RemovePlacedCardFromHand() {
        print("Aktueller Kartenname: " + currentChoosedCardName);
        Debug.Log(GameObject.Find(currentChoosedCardName).GetComponent<Handcards>().cardid = CardID.none);
    }
}

