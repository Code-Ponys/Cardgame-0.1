using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startpoint : Card {

    public new int x = 0;
    public new int y = 0;
    protected override CardID? GetType() {
        return CardID.Startpoint;
    }

    protected override Team? GetTeam() {
        return Team.system;
    }

    protected override State? GetState() {
        return State.field;
    }

    private void Start() {
        GenerateCard();
    }

    public override void GenerateCard() {
        GameObject startpoint = GameObject.CreatePrimitive(PrimitiveType.Quad);
        Renderer rend = startpoint.GetComponent<Renderer>();
        rend.material.mainTexture = Resources.Load("startpunkt") as Texture;
        startpoint.transform.position = new Vector3(0, 0, 1);
    }
}