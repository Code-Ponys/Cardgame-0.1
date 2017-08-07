using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class PointCard : Card {


        private void Start() {
            print(WinCondition());

        }
        protected bool WinCondition() {
            print("horizontal");
            //horizontal
            if (GameObject.Find("Pointcard " + (x - 1) + "," + y) != null
                && GameObject.Find("Pointcard " + (x - 1) + "," + y).GetComponent<PointCard>().team == team) {
                if (GameObject.Find("Pointcard " + (x - 2) + "," + y) != null
                    && GameObject.Find("Pointcard " + (x - 2) + "," + y).GetComponent<PointCard>().team == team) {
                    print("WIN °_°");
                    return true;
                } else {
                    if (GameObject.Find("Pointcard " + (x + 1) + "," + y) != null
                        && GameObject.Find("Pointcard " + (x + 1) + "," + y).GetComponent<PointCard>().team == team) {
                        print("WIN °_°");
                        return true;
                    }
                }
            } else if (GameObject.Find("Pointcard " + (x + 1) + "," + y) != null
                    && GameObject.Find("Pointcard " + (x + 1) + "," + y).GetComponent<PointCard>().team == team) {
                if (GameObject.Find("Pointcard " + (x + 2) + "," + y) != null
                    && GameObject.Find("Pointcard " + (x + 2) + "," + y).GetComponent<PointCard>().team == team) {
                    print("WIN °_°");
                    return true;
                }
            }

            print("vertikal");
            //vertikal
            if (GameObject.Find("Pointcard " + x + "," + (y + 1)) != null
                && GameObject.Find("Pointcard " + x + "," + (y + 1)).GetComponent<PointCard>().team == team) {
                if (GameObject.Find("Pointcard " + x + "," + (y + 2)) != null
                    && GameObject.Find("Pointcard " + x + "," + (y + 2)).GetComponent<PointCard>().team == team) {
                    print("WIN °_°");
                    return true;
                } else {
                    if (GameObject.Find("Pointcard " + x + "," + (y - 1)) != null
                        && GameObject.Find("Pointcard " + x + "," + (y - 1)).GetComponent<PointCard>().team == team) {
                        print("WIN °_°");
                        return true;
                    }
                }
            } else if (GameObject.Find("Pointcard " + x + "," + (y - 1)) != null
                    && GameObject.Find("Pointcard " + x + "," + (y - 1)).GetComponent<PointCard>().team == team) {
                if (GameObject.Find("Pointcard " + x + "," + (y - 2)) != null
                    && GameObject.Find("Pointcard " + x + "," + (y - 2)).GetComponent<PointCard>().team == team) {
                    print("WIN °_°");
                    return true;
                }
            }

            print("diagonal links oben -> rechts unten");
            //diagonal links oben -> rechts unten
            if (GameObject.Find("Pointcard " + (x - 1) + "," + (y + 1)) != null
                && GameObject.Find("Pointcard " + (x - 1) + "," + (y + 1)).GetComponent<PointCard>().team == team) {
                if (GameObject.Find("Pointcard " + (x - 2) + "," + (y + 2)) != null
                    && GameObject.Find("Pointcard " + (x - 2) + "," + (y + 2)).GetComponent<PointCard>().team == team) {
                    print("WIN °_°");
                    return true;
                } else {
                    if (GameObject.Find("Pointcard " + (x + 1) + "," + (y - 1)) != null
                        && GameObject.Find("Pointcard " + (x + 1) + "," + (y - 1)).GetComponent<PointCard>().team == team) {
                        print("WIN °_°");
                        return true;
                    }
                }
            } else if (GameObject.Find("Pointcard " + (x + 1) + "," + (y - 1)) != null
                    && GameObject.Find("Pointcard " + (x + 1) + "," + (y - 1)).GetComponent<PointCard>().team == team) {
                if (GameObject.Find("Pointcard " + (x + 2) + "," + (y - 2)) != null
                    && GameObject.Find("Pointcard " + (x + 2) + "," + (y - 2)).GetComponent<PointCard>().team == team) {
                    print("WIN °_°");
                    return true;
                }
            }

            print("diagonal links unten -> rechts oben");
            //diagonal links unten -> rechts oben
            if (GameObject.Find("Pointcard " + (x - 1) + "," + (y - 1)) != null
                && GameObject.Find("Pointcard " + (x - 1) + "," + (y - 1)).GetComponent<PointCard>().team == team) {
                if (GameObject.Find("Pointcard " + (x - 2) + "," + (y - 2)) != null
                    && GameObject.Find("Pointcard " + (x - 2) + "," + (y - 2)).GetComponent<PointCard>().team == team) {
                    print("WIN °_°");
                    return true;
                } else {
                    if (GameObject.Find("Pointcard " + (x + 1) + "," + (y + 1)) != null
                        && GameObject.Find("Pointcard " + (x + 1) + "," + (y + 1)).GetComponent<PointCard>().team == team) {
                        print("WIN °_°");
                        return true;
                    }
                }
            } else if (GameObject.Find("Pointcard " + (x + 1) + "," + (y + 1)) != null
                    && GameObject.Find("Pointcard " + (x + 1) + "," + (y + 1)).GetComponent<PointCard>().team == team) {
                if (GameObject.Find("Pointcard " + (x + 2) + "," + (y + 2)) != null
                    && GameObject.Find("Pointcard " + (x + 2) + "," + (y + 2)).GetComponent<PointCard>().team == team) {
                    print("WIN °_°");
                    return true;
                }
            }
            return false;
        }
    }
}


