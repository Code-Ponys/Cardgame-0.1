using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cards;
using UnityEngine.EventSystems;
using System;

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
    public CardID lastSetCard;
    public bool anchorFieldVisible;
    public bool cardIndicatorVisible;
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
        ToggleDeleteCardFieldVisibility();

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
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.Pointcard:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.Startpoint:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.Blockcard:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.FieldIndicator:
                Cardname = "FieldIndicator " + x + "," + y;
                break;
            case CardID.Indicatorred:
                Cardname = "FieldIndicatorRed " + x + "," + y;
                break;
            case CardID.Doublecard:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.Deletecard:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.Burncard:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.Infernocard:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.Changecard:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.Cancercard:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.HotPotatoe:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.Nukecard:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.Vortexcard:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.Anchorcard:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.Shufflecard:
                Cardname = "Card " + x + "," + y;
                break;
            case CardID.CardIndicator:
                Cardname = "CardIndicator " + x + "," + y;
                break;
        }
        GameObject Card = (GameObject)Instantiate(Resources.Load(pf_path));
        if (cardid == CardID.FieldIndicator) {
            GameObject FieldIndicatorParent = GameObject.Find("FieldIndicator");
            Card.transform.parent = FieldIndicatorParent.transform;
            Card.transform.position = new Vector3(x, y, -1);
        } else if (cardid == CardID.Indicatorred) {
            GameObject FieldIndicatorParentRed = GameObject.Find("FieldIndicator");
            Card.transform.parent = FieldIndicatorParentRed.transform;
            Card.transform.position = new Vector3(x, y, -1);
        } else if (cardid == CardID.CardIndicator) {
            GameObject FieldIndicatorParentRed = GameObject.Find("CardIndicator");
            Card.transform.parent = FieldIndicatorParentRed.transform;
            Card.transform.position = new Vector3(x, y, -3);
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

            SetFieldIndicator(x, y);
            //Card.AddComponent<Card>();

            Camera.main.GetComponent<CameraManager>().CenterCamera(x, y);
        }


        switch (cardid) {
            default:
                Card.AddComponent<NotImplemented>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Blankcard:
                Card.AddComponent<BlankCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Pointcard:
                Card.AddComponent<PointCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Startpoint:
                Card.AddComponent<Startpoint>();
                Card.GetComponent<Card>().team = Team.system;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Blockcard:
                Card.AddComponent<BlockCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.FieldIndicator:
                Card.AddComponent<Indicator>();
                break;
            case CardID.Indicatorred:
                break;
            case CardID.Doublecard:
                Card.AddComponent<DoubleCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Deletecard:
                Card.AddComponent<DeleteCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Burncard:
                Card.AddComponent<BurnCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Infernocard:
                Card.AddComponent<InfernoCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Changecard:
                Card.AddComponent<ChangeCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Cancercard:
                Card.AddComponent<CancerCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.HotPotatoe:
                Card.AddComponent<HotPotatoe>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Nukecard:
                Card.AddComponent<NukeCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Vortexcard:
                Card.AddComponent<VortexCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Anchorcard:
                Card.AddComponent<AnchorCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.Shufflecard:
                Card.AddComponent<ShuffleCard>();
                Card.GetComponent<Card>().team = currentPlayer;
                Card.GetComponent<Card>().x = x;
                Card.GetComponent<Card>().y = y;
                Card.GetComponent<Card>().cardid = cardid;
                break;
            case CardID.CardIndicator:
                Card.AddComponent<Indicator>();
                break;
        }

        if (cardid == CardID.Startpoint || cardid == CardID.Anchorcard
            || cardid == CardID.Pointcard || cardid == CardID.Blockcard
            || cardid == CardID.Blankcard) {
            GameObject.Find("Field").GetComponent<Field>().cardsOnField.Add(Card);
        }
        if (cardid != CardID.Startpoint) {
            animationDone = true;
        }
        lastSetCard = cardid;

        return Card;
    }

    public bool IsFieldOccupied(int x, int y) {
        if (x == 0 && y == 0) {
            return true;
        }
        if (currentChoosedCard == CardID.Deletecard) {
            return !GameObject.Find("CardIndicator " + x + "," + y).GetComponent<Indicator>().isFieldDeleteable;
        }
        if (GameObject.Find("Card " + x + "," + y) != null) {
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

        if (lastSetCard == CardID.Deletecard) {
            RemoveUnconnectedCards();
            print("NR - removed cards!");
            lastSetCard = CardID.none;
        }
        RenewIndicators();
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
        if (currentChoosedCard == CardID.Anchorcard && anchorFieldVisible == false) {
            anchorFieldVisible = true;
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

        if (currentChoosedCard != CardID.Anchorcard && anchorFieldVisible == true) {
            anchorFieldVisible = false;
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
        print("Start RenewIndicators");

        for (int x = Camera.main.GetComponent<CameraManager>().min_x - 3; x <= Camera.main.GetComponent<CameraManager>().max_x + 3; x++) {
            for (int y = Camera.main.GetComponent<CameraManager>().min_y - 3; y <= Camera.main.GetComponent<CameraManager>().max_y + 3; y++) {
                if (GameObject.Find("FieldIndicator " + x + "," + y) != null) {
                    GameObject Indicator = GameObject.Find("FieldIndicator " + x + "," + y);
                    if (Indicator.GetComponent<Indicator>().indicatorState != IndicatorState.blocked) {
                        Indicator.GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                        SpriteRenderer rend = Indicator.GetComponent<SpriteRenderer>();
                        rend.sprite = Resources.Load<Sprite>("emptycards/black");
                    }
                }
            }
        }

        for (int x = Camera.main.GetComponent<CameraManager>().min_x; x <= Camera.main.GetComponent<CameraManager>().max_x; x++) {
            for (int y = Camera.main.GetComponent<CameraManager>().min_y; y <= Camera.main.GetComponent<CameraManager>().max_y; y++) {
                if (GameObject.Find("Card " + x + "," + y) != null) {
                    SetFieldIndicator(x, y);
                }
            }
        }
        print("RenewIndicators completed");
    }

    public void SetFieldIndicator(int x, int y) {
        GameObject IndicatorLeft = GameObject.Find("FieldIndicator " + (x - 1) + "," + y);
        if (IndicatorLeft != null && IndicatorLeft.GetComponent<Indicator>().indicatorState != IndicatorState.blocked) {
            SpriteRenderer rend1 = IndicatorLeft.GetComponent<SpriteRenderer>();
            rend1.sprite = Resources.Load<Sprite>("emptycards/green");
            IndicatorLeft.GetComponent<Indicator>().indicatorState = IndicatorState.reachable;
        } else {
            if (GameObject.Find("FieldIndicatorRed " + (x - 1) + "," + y) == null) {
                GenerateFieldCard(CardID.Indicatorred, x - 1, y);
            }
        }

        GameObject IndicatorRight = GameObject.Find("FieldIndicator " + (x + 1) + "," + y);
        if (IndicatorRight != null && IndicatorRight.GetComponent<Indicator>().indicatorState != IndicatorState.blocked) {
            SpriteRenderer rend2 = IndicatorRight.GetComponent<SpriteRenderer>();
            rend2.sprite = Resources.Load<Sprite>("emptycards/green");
            IndicatorRight.GetComponent<Indicator>().indicatorState = IndicatorState.reachable;
        } else {
            if (GameObject.Find("FieldIndicatorRed " + (x + 1) + "," + y) == null) {
                GenerateFieldCard(CardID.Indicatorred, x + 1, y);
            }
        }

        GameObject IndicatorDown = GameObject.Find("FieldIndicator " + x + "," + (y - 1));
        if (IndicatorDown != null && IndicatorDown.GetComponent<Indicator>().indicatorState != IndicatorState.blocked) {
            SpriteRenderer rend3 = IndicatorDown.GetComponent<SpriteRenderer>();
            rend3.sprite = Resources.Load<Sprite>("emptycards/green");
            IndicatorDown.GetComponent<Indicator>().indicatorState = IndicatorState.reachable;
        } else {
            if (GameObject.Find("FieldIndicatorRed " + x + "," + (y - 1)) == null) {
                GenerateFieldCard(CardID.Indicatorred, x, y - 1);
            }
        }

        GameObject IndicatorUp = GameObject.Find("FieldIndicator " + x + "," + (y + 1));
        if (IndicatorUp != null && IndicatorUp.GetComponent<Indicator>().indicatorState != IndicatorState.blocked) {
            SpriteRenderer rend4 = IndicatorUp.GetComponent<SpriteRenderer>();
            rend4.sprite = Resources.Load<Sprite>("emptycards/green");
            IndicatorUp.GetComponent<Indicator>().indicatorState = IndicatorState.reachable;
        } else {
            if (GameObject.Find("FieldIndicatorRed " + x + "," + (y + 1)) == null) {
                GenerateFieldCard(CardID.Indicatorred, x, y + 1);
            }
        }

        for (int a = x - 2; a <= x + 2; a++) {
            for (int b = y - 2; b <= y + 2; b++) {
                GameObject Indicator = GameObject.Find("FieldIndicator " + a + "," + b);
                if (Indicator != null && Indicator.GetComponent<Indicator>().indicatorState != IndicatorState.blocked) {
                    IndicatorState state = Indicator.GetComponent<Indicator>().indicatorState;
                    if (state == IndicatorState.unreachable) {
                        Indicator.GetComponent<Indicator>().indicatorState = IndicatorState.anchorfield;
                    }
                }
            }
        }
    }

    void ToggleDeleteCardFieldVisibility() {
        if (currentChoosedCard == CardID.Deletecard && cardIndicatorVisible == false) {
            cardIndicatorVisible = true;
            for (int i = 0; i < Field.cardsOnField.Count; i++) {
                GameObject Card = Field.cardsOnField[i];
                if (Card.GetComponent<Card>().team != currentPlayer
                    && Card.GetComponent<Card>().team != Team.system) {
                    ShowCardIndicators(Card.GetComponent<Card>().x, Card.GetComponent<Card>().y);
                }
            }
        }
        if (currentChoosedCard != CardID.Deletecard && cardIndicatorVisible) {
            cardIndicatorVisible = false;
            HideCardIndicator();
        }
    }

    void ShowCardIndicators(int x, int y) {
        GameObject CardIndicator = GameObject.Find("CardIndicator " + x + "," + y);
        SpriteRenderer rend = CardIndicator.GetComponent<SpriteRenderer>();
        rend.sprite = Resources.Load<Sprite>("emptycards/CardIndicator");
        CardIndicator.GetComponent<Indicator>().isFieldDeleteable = true;
    }

    void HideCardIndicator() {
        for (int x = Camera.main.GetComponent<CameraManager>().min_x; x <= Camera.main.GetComponent<CameraManager>().max_x; x++) {
            for (int y = Camera.main.GetComponent<CameraManager>().min_y; y <= Camera.main.GetComponent<CameraManager>().max_y; y++) {
                GameObject CardIndicator = GameObject.Find("CardIndicator " + x + "," + y);
                SpriteRenderer rend = CardIndicator.GetComponent<SpriteRenderer>();
                rend.sprite = Resources.Load<Sprite>("emptycards/transparent");
                CardIndicator.GetComponent<Indicator>().isFieldDeleteable = false;
            }
        }
    }

    public void RemoveUnconnectedCards() {
        MarkUnconnectedCards();
        print("RUC - marked");
        DeleteUnconnectedCards();
        print("RUC - deleted");
        RenewIndicators();
        print("RUC - renewed");
    }

    void DeleteUnconnectedCards() {
        GameObject F = GameObject.Find("Field");

        for (int x = Camera.main.GetComponent<CameraManager>().min_x; x <= Camera.main.GetComponent<CameraManager>().max_x; x++) {
            for (int y = Camera.main.GetComponent<CameraManager>().min_y; y <= Camera.main.GetComponent<CameraManager>().max_y; y++) {
                GameObject Card = GameObject.Find("Card " + x + "," + y);
                if (Card != null
                    && Card.GetComponent<Card>().visited == false) {
                    for (int i = 0; i < F.GetComponent<Field>().cardsOnField.Count; i++) {
                        if (F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().x == x
                            && F.GetComponent<Field>().cardsOnField[i].GetComponent<Card>().y == y) {
                            F.GetComponent<Field>().cardsOnField.RemoveAt(i);
                            break;
                        }
                    }
                    if (Card.GetComponent<Card>().cardid == CardID.Blockcard) {
                        Block blockdirection = Card.GetComponent<BlockCard>().blockDirection;
                        switch (blockdirection) {
                            case Block.right:
                                GameObject.Find("FieldIndicator " + (x + 1) + "," + y).GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                                break;
                            case Block.left:
                                GameObject.Find("FieldIndicator " + (x - 1) + "," + y).GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                                break;
                            case Block.up:
                                GameObject.Find("FieldIndicator " + x + "," + (y + 1)).GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                                break;
                            case Block.down:
                                GameObject.Find("FieldIndicator " + x + "," + (y - 1)).GetComponent<Indicator>().indicatorState = IndicatorState.unreachable;
                                break;
                        }
                    }
                    Destroy(Card);
                } else if (Card != null
                     && Card.GetComponent<Card>().visited == true) {
                    Card.GetComponent<Card>().visited = false;
                }
            }
        }
        print("DeleteUnconnectedCards done.");
    }

    void MarkUnconnectedCards() {
        List<GameObject> anchor = new List<GameObject>();
        for (int i = 0; i < Field.cardsOnField.Count; i++) {
            if (Field.cardsOnField[i].GetComponent("Startpoint") != null
                || Field.cardsOnField[i].GetComponent("AnchorCard") != null) {
                anchor.Add(Field.cardsOnField[i]);
            }
        }

        for (int i = 0; i < anchor.Count; i++) {
            Queue<GameObject> ToDo = new Queue<GameObject>();
            ToDo.Enqueue(anchor[i]);
            anchor[i].GetComponent<Card>().visited = true;

            while (ToDo.Count > 0) {
                print("Queue Entries: " + ToDo.Count);
                GameObject CurrentGameObject = ToDo.Dequeue();
                int x = CurrentGameObject.GetComponent<Card>().x;
                int y = CurrentGameObject.GetComponent<Card>().y;

                //rechts
                GameObject CardRight = GameObject.Find("Card " + (x + 1) + "," + y);
                if (CardRight != null) {
                    if (CardRight.GetComponent<Card>().visited != true) {
                        CardRight.GetComponent<Card>().visited = true;
                        ToDo.Enqueue(CardRight);
                    }
                    //links
                    GameObject CardLeft = GameObject.Find("Card " + (x - 1) + "," + y);
                    if (CardLeft != null) {
                        if (CardLeft.GetComponent<Card>().visited != true) {
                            CardLeft.GetComponent<Card>().visited = true;
                            ToDo.Enqueue(CardLeft);
                        }
                    }
                    //oben
                    GameObject CardUp = GameObject.Find("Card " + x + "," + (y + 1));
                    if (CardUp != null) {
                        if (CardUp.GetComponent<Card>().visited != true) {
                            CardUp.GetComponent<Card>().visited = true;
                            ToDo.Enqueue(CardUp);
                        }
                    }
                    //unten
                    GameObject CardDown = GameObject.Find("Card " + x + "," + (y - 1));
                    if (CardDown != null) {
                        if (CardDown.GetComponent<Card>().visited != true) {
                            CardDown.GetComponent<Card>().visited = true;
                            ToDo.Enqueue(CardDown);
                        }
                    }
                }
            }
            print("MarkUnconnectedCards done");
        }
    }
}

