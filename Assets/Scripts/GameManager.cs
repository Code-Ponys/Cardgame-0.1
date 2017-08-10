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
    public FieldProperties FP;

    public Player[] players;
    public Player PlayerBlue { get { return players[0]; } }
    public Player PlayerRed { get { return players[1]; } }
    public int[,] distance;

    public Image SideBarBlue;
    public Image SideBarRed;
    public Canvas ChangePlayer;
    string currentChoosedCardName;

    public Team currentPlayer;
    public CardID currentChoosedCard;
    bool anchorfieldvisible;
    public bool animationDone;

    // Use this for initialization
    void Start() {
        players = new Player[2];
        players[0] = GameObject.Find("PlayerBlue").GetComponent<Player>();
        players[1] = GameObject.Find("PlayerRed").GetComponent<Player>();
        players[0].Init(Team.blue);
        players[1].Init(Team.red);
        currentPlayer = Team.blue;

        GameObject PlayerName = GameObject.Find("TextSpieler");
        PlayerName.GetComponent<Text>().text = "Spieler 1";
        PlayerBlue.RefillHand(currentPlayer);
        Canvas ChangePlayer = GameObject.Find("PlayerChange").GetComponent<Canvas>();
        //Image SideBarBlue = GameObject.Find("SideMenu Blue").GetComponent<Image>();
        //Image SideBarRed = GameObject.Find("SideMenu Red").GetComponent<Image>();
        SideBarRed.enabled = false;
        ChangePlayer.enabled = false;
        animationDone = false;
    }

    // Update is called once per frame
    void Update() {
        ToggleAnchorFieldVisibility();

        if (animationDone == true) {
            RemovePlacedCardFromHand();
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
            case CardID.Doublecard:
                Cardname = "Doublecard " + x + "," + y;
                break;
            case CardID.Deletecard:
                Cardname = "Deletecard " + x + "," + y;
                break;
            case CardID.Burncard:
                Cardname = "Burncard " + x + "," + y;
                break;
            case CardID.Infernocard:
                Cardname = "Infernocard " + x + "," + y;
                break;
            case CardID.Changecard:
                Cardname = "Changecard " + x + "," + y;
                break;
            case CardID.Cancercard:
                Cardname = "Cancercard " + x + "," + y;
                break;
            case CardID.HotPotatoe:
                Cardname = "HotPotatoe " + x + "," + y;
                break;
            case CardID.Nukecard:
                Cardname = "Nukecard " + x + "," + y;
                break;
            case CardID.Vortexcard:
                Cardname = "Vortexcard " + x + "," + y;
                break;
            case CardID.Anchorcard:
                Cardname = "Anchorcard " + x + "," + y;
                break;
            case CardID.Shufflecard:
                Cardname = "Shufflecard " + x + "," + y;
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
                IndicatorLeft.GetComponent<Indicator>().indicatorState = IndicatorState.reachable;
            } else { GenerateFieldCard(CardID.Indicatorred, x - 1, y); }

            GameObject IndicatorRight = GameObject.Find("FieldIndicator " + (x + 1) + "," + y);
            if (IndicatorRight != null) {
                SpriteRenderer rend2 = IndicatorRight.GetComponent<SpriteRenderer>();
                rend2.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorRight.GetComponent<Indicator>().indicatorState = IndicatorState.reachable;
            } else { GenerateFieldCard(CardID.Indicatorred, x + 1, y); }

            GameObject IndicatorDown = GameObject.Find("FieldIndicator " + x + "," + (y - 1));
            if (IndicatorDown != null) {
                SpriteRenderer rend3 = IndicatorDown.GetComponent<SpriteRenderer>();
                rend3.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorDown.GetComponent<Indicator>().indicatorState = IndicatorState.reachable;
            } else { GenerateFieldCard(CardID.Indicatorred, x, y - 1); }

            GameObject IndicatorUp = GameObject.Find("FieldIndicator " + x + "," + (y + 1));
            if (IndicatorUp != null) {
                SpriteRenderer rend4 = IndicatorUp.GetComponent<SpriteRenderer>();
                rend4.sprite = Resources.Load<Sprite>("emptycards/green");
                IndicatorUp.GetComponent<Indicator>().indicatorState = IndicatorState.reachable;
            } else { GenerateFieldCard(CardID.Indicatorred, x, y + 1); }

            for (int a = x - 2; a <= x + 2; a++) {
                for (int b = y - 2; b <= y + 2; b++) {
                    GameObject Indicator = GameObject.Find("FieldIndicator " + a + "," + b);
                    if (Indicator != null) {
                        IndicatorState state = Indicator.GetComponent<Indicator>().indicatorState;
                        if (state == IndicatorState.unreachable) {
                            Indicator.GetComponent<Indicator>().indicatorState = IndicatorState.anchorfield;
                        }
                    }
                }
            }

            //CameraController.CenterCamera();
            GameObject MainCamTest = GameObject.Find("Main Camera");
            MainCamTest.GetComponent<CameraManager>().CenterCamera(x, y);
        }

        switch (cardid) {
            default:
                Card.AddComponent<NotImplemented>();
                Card.GetComponent<NotImplemented>().team = currentPlayer;
                Card.GetComponent<NotImplemented>().x = x;
                Card.GetComponent<NotImplemented>().y = y;
                break;
            case CardID.Blankcard:
                Card.AddComponent<BlankCard>();
                Card.GetComponent<BlankCard>().team = currentPlayer;
                Card.GetComponent<BlankCard>().x = x;
                Card.GetComponent<BlankCard>().y = y;
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
                Card.GetComponent<Startpoint>().x = x;
                Card.GetComponent<Startpoint>().y = y;
                break;
            case CardID.Blockcard:
                Card.AddComponent<BlockCard>();
                Card.GetComponent<BlockCard>().team = currentPlayer;
                Card.GetComponent<BlockCard>().x = x;
                Card.GetComponent<BlockCard>().y = y;
                break;
            case CardID.Indicator:
                Card.AddComponent<Indicator>();
                break;
            case CardID.Indicatorred:
                break;
            case CardID.Doublecard:
                Card.AddComponent<DoubleCard>();
                Card.GetComponent<DoubleCard>().team = currentPlayer;
                Card.GetComponent<DoubleCard>().x = x;
                Card.GetComponent<DoubleCard>().y = y;
                break;
            case CardID.Deletecard:
                Card.AddComponent<DeleteCard>();
                Card.GetComponent<DeleteCard>().team = currentPlayer;
                Card.GetComponent<DeleteCard>().x = x;
                Card.GetComponent<DeleteCard>().y = y;
                break;
            case CardID.Burncard:
                Card.AddComponent<BurnCard>();
                Card.GetComponent<BurnCard>().team = currentPlayer;
                Card.GetComponent<BurnCard>().x = x;
                Card.GetComponent<BurnCard>().y = y;
                break;
            case CardID.Infernocard:
                Card.AddComponent<InfernoCard>();
                Card.GetComponent<InfernoCard>().team = currentPlayer;
                Card.GetComponent<InfernoCard>().x = x;
                Card.GetComponent<InfernoCard>().y = y;
                break;
            case CardID.Changecard:
                Card.AddComponent<ChangeCard>();
                Card.GetComponent<ChangeCard>().team = currentPlayer;
                Card.GetComponent<ChangeCard>().x = x;
                Card.GetComponent<ChangeCard>().y = y;
                break;
            case CardID.Cancercard:
                Card.AddComponent<CancerCard>();
                Card.GetComponent<CancerCard>().team = currentPlayer;
                Card.GetComponent<CancerCard>().x = x;
                Card.GetComponent<CancerCard>().y = y;
                break;
            case CardID.HotPotatoe:
                Card.AddComponent<HotPotatoe>();
                Card.GetComponent<HotPotatoe>().team = currentPlayer;
                Card.GetComponent<HotPotatoe>().x = x;
                Card.GetComponent<HotPotatoe>().y = y;
                break;
            case CardID.Nukecard:
                Card.AddComponent<NukeCard>();
                Card.GetComponent<NukeCard>().team = currentPlayer;
                Card.GetComponent<NukeCard>().x = x;
                Card.GetComponent<NukeCard>().y = y;
                break;
            case CardID.Vortexcard:
                Card.AddComponent<VortexCard>();
                Card.GetComponent<VortexCard>().team = currentPlayer;
                Card.GetComponent<VortexCard>().x = x;
                Card.GetComponent<VortexCard>().y = y;
                break;
            case CardID.Anchorcard:
                Card.AddComponent<AnchorCard>();
                Card.GetComponent<AnchorCard>().team = currentPlayer;
                Card.GetComponent<AnchorCard>().x = x;
                Card.GetComponent<AnchorCard>().y = y;
                break;
            case CardID.Shufflecard:
                Card.AddComponent<ShuffleCard>();
                Card.GetComponent<ShuffleCard>().team = currentPlayer;
                Card.GetComponent<ShuffleCard>().x = x;
                Card.GetComponent<ShuffleCard>().y = y;
                break;
        }

        if (cardid != CardID.Indicator) {
            GameObject.Find("Field").GetComponent<Field>().cardsOnField.Add(Card);
            if (cardid != CardID.Startpoint) {
                animationDone = true;

            }
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
        if (GameObject.Find("FieldIndicator " + x + "," + y).GetComponent<Indicator>().indicatorState == IndicatorState.anchorfield
            && currentChoosedCard == CardID.Anchorcard) {
            return false;
        }
        if (GameObject.Find("FieldIndicator " + x + "," + y).GetComponent<Indicator>().indicatorState == IndicatorState.blocked
            || GameObject.Find("FieldIndicator " + x + "," + y).GetComponent<Indicator>().indicatorState == IndicatorState.unreachable
            || GameObject.Find("FieldIndicator " + x + "," + y).GetComponent<Indicator>().indicatorState == IndicatorState.anchorfield) {
            return true;
        }
        return false;
    }

    public void NewRound() {
        if (currentPlayer == Team.blue) {
            currentPlayer = Team.red;
        } else {
            currentPlayer = Team.blue;
        }
        currentChoosedCard = CardID.none;
        animationDone = false;

        //TODO Change Handcards
        //TODO Fade in Black Scene
        if (currentPlayer == Team.blue) {
            SideBarBlue.enabled = true;
            SideBarRed.enabled = false;
            players[0].RefillHand(currentPlayer);
            GameObject PlayerName = GameObject.Find("TextSpieler");
            PlayerName.GetComponent<Text>().text = "Spieler 1";
        } else {
            SideBarBlue.enabled = false;
            SideBarRed.enabled = true;
            players[1].RefillHand(currentPlayer);

            GameObject PlayerName = GameObject.Find("TextSpieler");
            PlayerName.GetComponent<Text>().text = "Spieler 2";
        }
        TogglePlayerScreen();
    }

    public void OnCardClick() {
        string name = EventSystem.current.currentSelectedGameObject.name;
        currentChoosedCardName = name;
        GameObject currentChoosedCardGO = GameObject.Find(name);
        currentChoosedCard = currentChoosedCardGO.GetComponent<Handcards>().cardid;
    }

    public void TogglePlayerScreen() {
        ChangePlayer.enabled = !ChangePlayer.enabled;
    }

    void RemovePlacedCardFromHand() {

        GameObject.Find(currentChoosedCardName).GetComponent<Handcards>().cardid = CardID.none;
    }

    void ToggleAnchorFieldVisibility() {
        if (currentChoosedCard == CardID.Anchorcard && anchorfieldvisible == false) {
            anchorfieldvisible = true;
            for (int x = Camera.main.GetComponent<CameraManager>().min_x - 2; x <= Camera.main.GetComponent<CameraManager>().max_x + 2; x++) {
                for (int y = Camera.main.GetComponent<CameraManager>().min_y - 2; y <= Camera.main.GetComponent<CameraManager>().max_y + 2; y++) {
                    if (GameObject.Find("FieldIndicator " + x + "," + y) != null) {
                        GameObject Indicator = GameObject.Find("FieldIndicator " + x + "," + y);
                        if (Indicator.GetComponent<Indicator>().indicatorState == IndicatorState.anchorfield) {
                            SpriteRenderer rend = Indicator.GetComponent<SpriteRenderer>();
                            rend.sprite = Resources.Load<Sprite>("emptycards/yellow");
                        }
                    }
                }
            }
        }

        if (currentChoosedCard != CardID.Anchorcard && anchorfieldvisible == true) {
            anchorfieldvisible = false;
            print("Deactivate Anchorcards");
            for (int x = Camera.main.GetComponent<CameraManager>().min_x - 2; x <= Camera.main.GetComponent<CameraManager>().max_x + 2; x++) {
                for (int y = Camera.main.GetComponent<CameraManager>().min_y - 2; y <= Camera.main.GetComponent<CameraManager>().max_y + 2; y++) {
                    if (GameObject.Find("FieldIndicator " + x + "," + y) != null) {
                        GameObject Indicator = GameObject.Find("FieldIndicator " + x + "," + y);
                        if (Indicator.GetComponent<Indicator>().indicatorState == IndicatorState.anchorfield) {
                            SpriteRenderer rend = Indicator.GetComponent<SpriteRenderer>();
                            rend.sprite = Resources.Load<Sprite>("emptycards/black");
                        }
                    }
                }
            }
        }
    }

    public void RenewIndicators() {
        for (int x = Camera.main.GetComponent<CameraManager>().min_x - 3; x <= Camera.main.GetComponent<CameraManager>().max_x + 3; x++) {
            for (int y = Camera.main.GetComponent<CameraManager>().min_y - 3; y <= Camera.main.GetComponent<CameraManager>().max_y + 3; y++) {
                if (GameObject.Find("FieldIndicator " + x + "," + y) != null) {
                    GameObject Indicator = GameObject.Find("FieldIndicator " + x + "," + y);
                    if (Indicator.GetComponent<Indicator>().indicatorState == IndicatorState.unreachable) {
                        SpriteRenderer rend = Indicator.GetComponent<SpriteRenderer>();
                        rend.sprite = Resources.Load<Sprite>("emptycards/black");
                    }
                }
            }
        }
        for (int x = Camera.main.GetComponent<CameraManager>().min_x; x <= Camera.main.GetComponent<CameraManager>().max_x; x++) {
            for (int y = Camera.main.GetComponent<CameraManager>().min_y; y <= Camera.main.GetComponent<CameraManager>().max_y; y++) {
                if (GameObject.Find("Startpoint " + x + "," + y) != null
                    || GameObject.Find("Anchorcard " + x + "," + y) != null
                    || GameObject.Find("Pointcard " + x + "," + y) != null
                    || GameObject.Find("Blockcard " + x + "," + y) != null
                    || GameObject.Find("Blankcard " + x + "," + y) != null) {
                    SetFieldIndicator(x, y);
                }
            }
        }
    }
        }
        return removeCards;
    }
}

