using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Slave {
    static public string GetImagePathPf(CardID card, Team team) {
        if (card != CardID.FieldIndicator
            && card != CardID.FieldIndicatorRed
            && card != CardID.Startpoint
            && card != CardID.CardIndicator) {
            return "cards/" + team + "/pf_" + card;
        }
        switch (card) {
            default:
                return "cards/" + team + "/pf_Errorcard";
            case CardID.FieldIndicator:
                return "emptycards/pf_black";
            case CardID.FieldIndicatorRed:
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
            case CardID.CardIndicator:
                return "emptycards/transparent";
            case CardID.CardIndicatorRed:
                return "emptycards/CardIndicatorRed";
            case CardID.FieldIndicatorGreen:
                return "emptycards/green";
            case CardID.FieldIndicatorBlack:
                return "emptycards/black";
            case CardID.FieldIndicatorYellow:
                return "emptycards/yellow";
        }
        return "cards/" + team + "/" + card;


    }
    static public string GetCardName(CardID cardid, int x, int y) {
        switch (cardid) {
            default:
                return "Error " + x + "," + y;
            case CardID.Card:
                return "Card " + x + "," + y;
            case CardID.Blankcard:
                return "Card " + x + "," + y;
            case CardID.Pointcard:
                return "Card " + x + "," + y;
            case CardID.Startpoint:
                return "Card " + x + "," + y;
            case CardID.Blockcard:
                return "Card " + x + "," + y;
            case CardID.FieldIndicator:
                return "FieldIndicator " + x + "," + y;
            case CardID.FieldIndicatorRed:
                return "FieldIndicatorRed " + x + "," + y;
            case CardID.Doublecard:
                return "Doublecard " + x + "," + y;
            case CardID.Deletecard:
                return "Deletecard " + x + "," + y;
            case CardID.Burncard:
                return "Burncard " + x + "," + y;
            case CardID.Infernocard:
                return "Infernocard " + x + "," + y;
            case CardID.Changecard:
                return "Changecard " + x + "," + y;
            case CardID.Cancercard:
                return "Cancercard " + x + "," + y;
            case CardID.HotPotatoe:
                return "HotPotatoe " + x + "," + y;
            case CardID.Nukecard:
                return "Nukecard " + x + "," + y;
            case CardID.Vortexcard:
                return "Vortexcard " + x + "," + y;
            case CardID.Anchorcard:
                return "Anchorcard " + x + "," + y;
            case CardID.Shufflecard:
                return "Shufflecard " + x + "," + y;
            case CardID.CardIndicator:
                return "CardIndicator " + x + "," + y;
        }
    }
}