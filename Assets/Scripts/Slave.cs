using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //return "cards/" + team + "/" + card;

    }

    public static string GetCardName(CardID card) {
        switch (card) {
            default:
                return "";
            case CardID.Blankcard:
                return "Blankcard";
            case CardID.Pointcard:
                return "Pointcard";
            case CardID.Blockcard:
                return "Blockcard";
            case CardID.Doublecard:
                return "Doublecard";
            case CardID.Deletecard:
                return "Deletecard";
            case CardID.Burncard:
                return "Burncard";
            case CardID.Infernocard:
                return "Infernocard";
            case CardID.Changecard:
                return "Changecard";
            case CardID.Cancercard:
                return "Cancercard";
            case CardID.HotPotatoe:
                return "HotPotatoe";
            case CardID.Nukecard:
                return "Nukecard";
            case CardID.Vortexcard:
                return "Vortexcard";
            case CardID.Anchorcard:
                return "Anchorcard";
            case CardID.Shufflecard:
                return "Shufflecard";
        }
    }

    public static string GetCardDescription(CardID card) {
        switch (card) {
            default:
                return "";
            case CardID.Blankcard:
                return "Use this card to block your opponents moves.";
            case CardID.Pointcard:
                return "Place 3 of these cards diagonally, horizontally or vertically in a row to win.";
            case CardID.Blockcard:
                return "Blocks a field and reserves an empty, adjacent one for you to use later.";
            case CardID.Doublecard:
                return "Place a Point- and a Blankcard from your deck.";
            case CardID.Deletecard:
                return "Destroys any card from the playfield.";
            case CardID.Burncard:
                return "Destroys one adjacent card and itself.";
            case CardID.Infernocard:
                return "Deletes 3 cards in any straight direction, starting from its position.";
            case CardID.Changecard:
                return "Turns any pointcard into a blankcard.";
            case CardID.Cancercard:
                return "Turns all cards in its line and column into blank cards.";
            case CardID.HotPotatoe:
                return "The opponent must discard all special cards on his hand.";
            case CardID.Nukecard:
                return "All cards are removed from the playfield.";
            case CardID.Vortexcard:
                return "Exchange your deck and handcards with your opponents.";
            case CardID.Anchorcard:
                return "Creates a new starting point, max. 2 fields away from other cards.";
            case CardID.Shufflecard:
                return "Switches places of your card with enemy card, if they’re adjacent.";
        }
    }
}