using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager Instance;

    public GameObject CardPrefab;

    GameManager() {
        Instance = this;
    }

    public static GameManager GetInstance() {
        if (Instance == null) {
            GameObject tile = new GameObject();
            Instance = tile.AddComponent<GameManager>();
            tile.name = "GameManager";
        }
        return Instance;
    }

    public List<Card> Cards = new List<Card>();

	// Use this for initialization
	void Start () {
        Card c=Instantiate(CardPrefab).gameObject.GetComponent<Card>();
        Cards.Add(c);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
