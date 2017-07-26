using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCard : Card {

    public new int x { get; set; }
    public new int y { get; set; }
    public new int team { get; set; }
    public new int state { get; set; }

    protected override CardID? GetType() {
        return CardID.Pointcard;
    }
    private void Start() {
        GenerateCard();
    }

    public override void GenerateCard() {
        GameObject pointCard = GameObject.CreatePrimitive(PrimitiveType.Quad);
        Renderer rend = pointCard.GetComponent<Renderer>();
        rend.material.mainTexture = Resources.Load("pointcard") as Texture;
        pointCard.transform.position = new Vector3(0, 0, -1);
    }
}

