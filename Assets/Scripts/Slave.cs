using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Slave {
    static public string GetImagePathPf(CardID card) {
        switch (card) {
            default:
                return "cards/pf_Errorcard";
            case CardID.Blankcard:
                return "cards/pf_Blankcard";
            case CardID.Pointcard:
                return "cards/pf_Pointcard";
            case CardID.Startpoint:
                return "cards/pf_Startpoint";
            case CardID.Blockcard:
                return "cards/pf_Blockcard";
            case CardID.Indicator:
                return "emptycards/pf_black";
            case CardID.Indicatorred:
                return "emptycards/pf_red";
        }
    }
    static public string GetImagePath(CardID card) {
        switch (card) {
            default:
                return "cards/Errorcard";
            case CardID.Blankcard:
                return "cards/Blankcard";
            case CardID.Pointcard:
                return "cards/Pointcard";
            case CardID.Startpoint:
                return "cards/Startpoint";
            case CardID.Blockcard:
                return "cards/Blockcard";
        }
    }
}