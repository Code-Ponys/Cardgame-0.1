using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards;

public abstract class Card : MonoBehaviour {

    public CardID card;
    public Team team;
    public int x;
    public int y;
    public bool visited;
}