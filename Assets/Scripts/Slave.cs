using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Slave {
    static public string GetImagePathPf(CardID card, Team team) {
        switch (card) {
            default:
                return "cards/" + team + "/pf_Errorcard";
            case CardID.Blankcard:
                return "cards/" + team + "/pf_Blankcard";
            case CardID.Pointcard:
                return "cards/" + team + "/pf_Pointcard";
            case CardID.Blockcard:
                return "cards/" + team + "/pf_Blockcard";
            case CardID.FieldIndicator:
                return "emptycards/pf_black";
            case CardID.Indicatorred:
                return "emptycards/pf_red";
            case CardID.Startpoint:
                return "cards/pf_Startpoint";
            case CardID.Doublecard:
                return "cards/" + team + "/pf_Doublecard";
            case CardID.Deletecard:
                return "cards/" + team + "/pf_Deletecard";
            case CardID.Burncard:
                return "cards/" + team + "/pf_Burncard";
            case CardID.Infernocard:
                return "cards/" + team + "/pf_Infernocard";
            case CardID.Changecard:
                return "cards/" + team + "/pf_Changecard";
            case CardID.Cancercard:
                return "cards/" + team + "/pf_Cancercard";
            case CardID.HotPotatoe:
                return "cards/" + team + "/pf_HotPotatoe";
            case CardID.Nukecard:
                return "cards/" + team + "/pf_Nukecard";
            case CardID.Vortexcard:
                return "cards/" + team + "/pf_Vortexcard";
            case CardID.Anchorcard:
                return "cards/" + team + "/pf_Anchorcard";
            case CardID.Shufflecard:
                return "cards/" + team + "/pf_Shufflecard";
            case CardID.CardIndicator:
                return "emptycards/pf_transparent";
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
            case CardID.Doublecard:
                return "cards/Doublecard";
            case CardID.Deletecard:
                return "cards/Deletecard";
            case CardID.Burncard:
                return "cards/Burncard";
            case CardID.Infernocard:
                return "cards/Infernocard";
            case CardID.Changecard:
                return "cards/Changecard";
            case CardID.Cancercard:
                return "cards/Cancercard";
            case CardID.HotPotatoe:
                return "cards/HotPotatoe";
            case CardID.Nukecard:
                return "cards/Nukecard";
            case CardID.Vortexcard:
                return "cards/Vortexcard";
            case CardID.Anchorcard:
                return "cards/Anchorcard";
            case CardID.Shufflecard:
                return "cards/Shufflecard";
        }
    }
}