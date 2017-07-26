using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankCard : Card {

    public new int x { get; set; }
    public new int y { get; set; }
    public new int team { get; set; }
    public new int state { get; set; }

    protected override CardID? GetType() {
        return CardID.Blankcard;
    }

    private void Start() {
        GenerateCard();
    }

    public override void GenerateCard() {
        GameObject blankCard = GameObject.CreatePrimitive(PrimitiveType.Quad);
        Renderer rend = blankCard.GetComponent<Renderer>();
        rend.material.mainTexture = Resources.Load("empty_card") as Texture;
        blankCard.transform.position = new Vector3(0, 0, -1);
    }
}
