using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards;

public abstract class Card : MonoBehaviour {

    public State state;
    public Team team;
    public int x;
    public int y;
}