using UnityEngine;

[System.Serializable]
public class FieldProperties : System.Object {
    public int _size;
}

public enum CardID { Startpoint, Pointcard, Blankcard,
    Doublecard, Blockcard, Deletecard,
    Burncard, Infernocard, Changecard,
    Cancercard, HotPotatoe, Nukecard,
    Vortexcard, Anchorcard, Sufflecard }
public enum Team {
    system, blau, rot
}
public enum Block {
    up, right, left, down
}

public enum State {
    deck, hand, field
}
public class Materials {
    //Material transparent = new Material();
}