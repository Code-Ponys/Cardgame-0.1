using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards {
    public class PointCard : Card {


        private void Start() {
            print("Player "+ team + " Win? " + WinCondition());

        }
        protected bool WinCondition() {
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


