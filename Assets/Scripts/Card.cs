using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour {

    int state;
    int team;

    protected abstract new CardID? GetType();

    protected void CardShow() {

    }

    protected virtual Team? GetTeam() {
        switch (team) {
            default:
                return null;
            case 0:
                return Team.system;
            case 1:
                return Team.blau;
            case 2:
                return Team.rot;
        }
    }

    protected virtual State? GetState() {
        switch (state) {
            default:
                return null;
            case 0:
                return State.deck;
            case 1:
                return State.hand;
            case 2:
                return State.field;

        }
    }
}