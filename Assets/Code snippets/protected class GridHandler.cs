protected class CardData {

    protected void generateGridArray() {
        sprite = new GameObject[_size, _size];
        cardData = new Enum[_size, _size, 5];
        name = new string[_size, _size];

    }

    protected string GetName(int x, int y) {
        return name[x, y];
    }

    protected void SetName(int x, int y) {
        name[x, y] = "Kachel(" + x + ", " + y + ")";
    }

    //States: 0 = empty; 1 = card
    protected state GetState(int x, int y) {
        return cardData[x, y, 0];
    }

    protected void SetState(int x, int y, enum state) {
        cardData[x, y, 0] = state;
    }

    //Teams: 0 = empty; 1 = blue; 2 = red; System = 3; 
    protected team GetTeam(int x, int y) {
        return cardData[x, y, 1];
    }

    protected void SetTeam(int x, int y, enum team) {
        cardData[x, y, 1] = team;
    }


    protected cardID GetCardID(int x, int y) {
        return cardData[x, y, 2];
    }

    protected void SetCardID(int x, int y, enum cardID) {
        grid[x, y, 2] = cardID;
    }


    protected specials GetSpecial(int x, int y) {
    return grid[x, y, 3];
    }

    protected void SetSpecial(int x, int y, enum special) {
        grid[x, y, 3] = special;
    }
}
