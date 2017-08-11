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
    }
}