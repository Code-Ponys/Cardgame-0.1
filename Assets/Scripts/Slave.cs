using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Slave {
    static public string GetImagePathPf(CardID card, Team team) {
        if (card != CardID.FieldIndicator
            || card != CardID.Indicatorred
            || card != CardID.Startpoint
            || card != CardID.CardIndicator) {
            return "cards/" + team + "/pf_" + card;
        }
        switch (card) {
            default:
                return "cards/" + team + "/pf_Errorcard";
            case CardID.FieldIndicator:
                return "emptycards/pf_black";
            case CardID.Indicatorred:
                return "emptycards/pf_red";
            case CardID.Startpoint:
                return "cards/pf_Startpoint";
            case CardID.CardIndicator:
                return "emptycards/pf_transparent";
        }
    }

    static public string GetImagePath(CardID card, Team team) {
        switch (card) {
            default:
                return "cards/" + team + "/Errorcard";
            case CardID.Blankcard:
                return "cards/" + team + "/Blankcard";
            case CardID.Pointcard:
                return "cards/" + team + "/Pointcard";
            case CardID.Startpoint:
                return "cards/" + team + "/Startpoint";
            case CardID.Blockcard:
                return "cards/" + team + "/Blockcard";
            case CardID.Doublecard:
                return "cards/" + team + "/Doublecard";
            case CardID.Deletecard:
                return "cards/" + team + "/Deletecard";
            case CardID.Burncard:
                return "cards/" + team + "/Burncard";
            case CardID.Infernocard:
                return "cards/" + team + "/Infernocard";
            case CardID.Changecard:
                return "cards/" + team + "/Changecard";
            case CardID.Cancercard:
                return "cards/" + team + "/Cancercard";
            case CardID.HotPotatoe:
                return "cards/" + team + "/HotPotatoe";
            case CardID.Nukecard:
                return "cards/" + team + "/Nukecard";
            case CardID.Vortexcard:
                return "cards/" + team + "/Vortexcard";
            case CardID.Anchorcard:
                return "cards/" + team + "/Anchorcard";
            case CardID.Shufflecard:
                return "cards/" + team + "/Shufflecard";
        }
        return "cards/" + team + "/" + card;

    }
}