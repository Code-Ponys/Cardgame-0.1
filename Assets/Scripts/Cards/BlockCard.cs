using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCard : Card {

    public string blockDirection;
    public int x { get; set; }
    public int y { get; set; }
    public int team { get; set; }
    public int state { get; set; }

    protected Block? GetBlockDirection() {
        switch (blockDirection) {
            default:
                return null;
            case "up":
                return Block.up;
            case "down":
                return Block.down;
            case "left":
                return Block.left;
            case "right":
                return Block.right;
        }
    }

    protected override CardID? GetType() {
        return CardID.Blockcard;
    }
}
