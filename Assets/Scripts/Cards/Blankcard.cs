using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankCard : Card {

    public int x { get; set; }
    public int y { get; set; }
    public int team { get; set; }
    public int state { get; set; }

    protected override CardID? GetType() {
        return CardID.Blankcard;
    }
}
