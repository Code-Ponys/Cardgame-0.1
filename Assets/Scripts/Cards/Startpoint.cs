using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startpoint : Card {

    public int x = 0;
    public int y = 0;
    protected override CardID? GetType() {
        return CardID.Startpoint;
    }

    protected override Team? GetTeam() {
        return Team.system;
    }

    protected override State? GetState() {
        return State.field;
    }


}