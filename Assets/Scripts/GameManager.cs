using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //private static GameManager Instance;

    //public GameObject CardPrefab;



    //GameManager() {
    //    Instance = this;
    //}

    //public static GameManager GetInstance() {
    //    if (Instance == null) {
    //        GameObject tile = new GameObject();
    //        Instance = tile.AddComponent<GameManager>();
    //        tile.name = "GameManager";
    //    }
    //    return Instance;
    //}

    public List<Card> Cards = new List<Card>();

    // Use this for initialization
    void Start() {
        //Card c = Instantiate(CardPrefab).gameObject.GetComponent<Card>();
        //Cards.Add(c);
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

    private void OnMouseDown() {
        print("klick");
        Physics.queriesHitTriggers = true;
        ChangeGameCard();
    }


    private void ChangeGameCard() {
        GameObject g1 = GameObject.Find("HandCard1");
        Renderer rend1 = g1.GetComponent<Renderer>();
        rend1.material.mainTexture = Resources.Load("startpunkt") as Texture;

        GameObject g2 = GameObject.Find("HandCard2");
        SpriteRenderer rend2 = g2.GetComponent<SpriteRenderer>();
        rend2.sprite = Resources.Load<Sprite>("startpunkt");
        g2.transform.localScale = new Vector3(1, 1, 1);
    }

    /*public GameObject PauseMenu;*/

    //public void TogglePauseOn() {

    //    PauseMenu.SetActive(true);
    //    print("Pause is active");
    //    print("Active in H." + PauseMenu.activeInHierarchy);
    //    print("Active Self" + PauseMenu.activeSelf);
    //    //bool g = GameObject.Find("UI_Pause").activeInHierarchy;
    //    //if (g == true) {
    //    //    GameObject.Find("UI_Pause").SetActive(false);
    //    //} else {
    //    //    GameObject.Find("UI_Pause").SetActive(true);
    //    //}
    //}

    //public void TogglePauseMenuOff() {
    //    PauseMenu.SetActive(false);
    //}
}
