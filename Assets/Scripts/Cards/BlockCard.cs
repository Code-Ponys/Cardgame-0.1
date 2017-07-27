using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {

    public class BlockCard : Card {

        public string blockDirection;
        public new int x { get; set; }
        public new int y { get; set; }
        public new int team { get; set; }
        public new int state { get; set; }

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

        private void Start() {
            GenerateCard();
        }

        public override void GenerateCard() {
            GameObject blockCard = GameObject.CreatePrimitive(PrimitiveType.Quad);
            Renderer rend = blockCard.GetComponent<Renderer>();
            rend.material.mainTexture = Resources.Load("empty_card") as Texture;
            blockCard.transform.position = new Vector3(0, 0, -1);
        }
    }
}
