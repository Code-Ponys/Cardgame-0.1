using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cards {

    public class PointCard : Card {

        string Kartenname = "Pointcard";
        string Kartenbeschreibung = "Lege 3 Punktkarten horizontal, vertical oder diagonal aneinader um zu gewinnen!";

        private void Start() {
            print("Player " + team + " Win? " + WinCondition());

        }
        protected bool WinCondition() {
            //horizontal
            if (GameObject.Find("Pointcard " + (x - 1) + "," + y) != null
                && GameObject.Find("Pointcard " + (x - 1) + "," + y).GetComponent<Card>().team == team) {
                if (GameObject.Find("Pointcard " + (x - 2) + "," + y) != null
                    && GameObject.Find("Pointcard " + (x - 2) + "," + y).GetComponent<Card>().team == team) {
                    print("WIN °_°");
                    return true;
                } else {
                    if (GameObject.Find("Pointcard " + (x + 1) + "," + y) != null
                        && GameObject.Find("Pointcard " + (x + 1) + "," + y).GetComponent<Card>().team == team) {
                        print("WIN °_°");
                        return true;
                    }
                }
            } else if (GameObject.Find("Pointcard " + (x + 1) + "," + y) != null
                    && GameObject.Find("Pointcard " + (x + 1) + "," + y).GetComponent<Card>().team == team) {
                if (GameObject.Find("Pointcard " + (x + 2) + "," + y) != null
                    && GameObject.Find("Pointcard " + (x + 2) + "," + y).GetComponent<Card>().team == team) {
                    print("WIN °_°");
                    return true;
                }
            }

            //vertikal
            if (GameObject.Find("Pointcard " + x + "," + (y + 1)) != null
                && GameObject.Find("Pointcard " + x + "," + (y + 1)).GetComponent<Card>().team == team) {
                if (GameObject.Find("Pointcard " + x + "," + (y + 2)) != null
                    && GameObject.Find("Pointcard " + x + "," + (y + 2)).GetComponent<Card>().team == team) {
                    print("WIN °_°");
                    return true;
                } else {
                    if (GameObject.Find("Pointcard " + x + "," + (y - 1)) != null
                        && GameObject.Find("Pointcard " + x + "," + (y - 1)).GetComponent<Card>().team == team) {
                        print("WIN °_°");
                        return true;
                    }
                }
            } else if (GameObject.Find("Pointcard " + x + "," + (y - 1)) != null
                    && GameObject.Find("Pointcard " + x + "," + (y - 1)).GetComponent<Card>().team == team) {
                if (GameObject.Find("Pointcard " + x + "," + (y - 2)) != null
                    && GameObject.Find("Pointcard " + x + "," + (y - 2)).GetComponent<Card>().team == team) {
                    print("WIN °_°");
                    return true;
                }
            }

            //diagonal links oben -> rechts unten
            if (GameObject.Find("Pointcard " + (x - 1) + "," + (y + 1)) != null
                && GameObject.Find("Pointcard " + (x - 1) + "," + (y + 1)).GetComponent<Card>().team == team) {
                if (GameObject.Find("Pointcard " + (x - 2) + "," + (y + 2)) != null
                    && GameObject.Find("Pointcard " + (x - 2) + "," + (y + 2)).GetComponent<Card>().team == team) {
                    print("WIN °_°");
                    return true;
                } else {
                    if (GameObject.Find("Pointcard " + (x + 1) + "," + (y - 1)) != null
                        && GameObject.Find("Pointcard " + (x + 1) + "," + (y - 1)).GetComponent<Card>().team == team) {
                        print("WIN °_°");
                        return true;
                    }
                }
            } else if (GameObject.Find("Pointcard " + (x + 1) + "," + (y - 1)) != null
                    && GameObject.Find("Pointcard " + (x + 1) + "," + (y - 1)).GetComponent<Card>().team == team) {
                if (GameObject.Find("Pointcard " + (x + 2) + "," + (y - 2)) != null
                    && GameObject.Find("Pointcard " + (x + 2) + "," + (y - 2)).GetComponent<Card>().team == team) {
                    print("WIN °_°");
                    return true;
                }
            }

            //diagonal links unten -> rechts oben
            if (GameObject.Find("Pointcard " + (x - 1) + "," + (y - 1)) != null
                && GameObject.Find("Pointcard " + (x - 1) + "," + (y - 1)).GetComponent<Card>().team == team) {
                if (GameObject.Find("Pointcard " + (x - 2) + "," + (y - 2)) != null
                    && GameObject.Find("Pointcard " + (x - 2) + "," + (y - 2)).GetComponent<Card>().team == team) {
                    print("WIN °_°");
                    return true;
                } else {
                    if (GameObject.Find("Pointcard " + (x + 1) + "," + (y + 1)) != null
                        && GameObject.Find("Pointcard " + (x + 1) + "," + (y + 1)).GetComponent<Card>().team == team) {
                        print("WIN °_°");
                        return true;
                    }
                }
            } else if (GameObject.Find("Pointcard " + (x + 1) + "," + (y + 1)) != null
                    && GameObject.Find("Pointcard " + (x + 1) + "," + (y + 1)).GetComponent<Card>().team == team) {
                if (GameObject.Find("Pointcard " + (x + 2) + "," + (y + 2)) != null
                    && GameObject.Find("Pointcard " + (x + 2) + "," + (y + 2)).GetComponent<Card>().team == team) {
                    print("WIN °_°");
                    return true;
                }
            }
            return false;
        }

        void GetCardName() {
            //Texte für Handkartenanzeige
            if (GameObject.Find("HandCard1" + team).GetComponent<Handcards>().cardid == CardID.Pointcard) {
                print("i bims 1 pointcard");
                GameObject.Find("Kartenname1" + team).GetComponent<Text>().text = Kartenname;

            } else if (GameObject.Find("HandCard2" + team).GetComponent<Handcards>().cardid == CardID.Pointcard) {
                print("i bims 1 pointcard");
                GameObject.Find("Kartenname2" + team).GetComponent<Text>().text = Kartenname;

            } else if (GameObject.Find("HandCard3" + team).GetComponent<Handcards>().cardid == CardID.Pointcard) {
                print("i bims 1 pointcard");
                GameObject.Find("Kartenname3" + team).GetComponent<Text>().text = Kartenname;
            }

        }

        void GetCardDescription() {
            //Texte für Handkartenanzeige
            if (GameObject.Find("HandCard1" + team).GetComponent<Handcards>().cardid == CardID.Pointcard) {
                GameObject.Find("Kartentext1" + team).GetComponent<Text>().text = Kartenbeschreibung;

            } else if (GameObject.Find("HandCard2" + team).GetComponent<Handcards>().cardid == CardID.Pointcard) {
                GameObject.Find("Kartentext2" + team).GetComponent<Text>().text = Kartenbeschreibung;

            } else if (GameObject.Find("HandCard3" + team).GetComponent<Handcards>().cardid == CardID.Pointcard) {
                GameObject.Find("Kartentext3" + team).GetComponent<Text>().text = Kartenbeschreibung;
            }

        }
    }
}


