protected void GenerateField (int size) {
    debugfieldsize();
    GenerteGridArray(size);
    for (int x = 0; x < size; x++) {
        for (int y = 0; x < size; y++) {
            if (x == (size / 2) && y == (size / 2)) {
                CardData.SetName(x, y);
                CardData.SetState(1);
                CardData.SetTeam(3);
                CardData.SetCardID(-1);
                GameObject Card = Instantiate(Resources.Load("Startpoint")) as GameObject;
                tile.transform.position = new Vector2(x + 0.5f, y + 0.5f);
                tile.transform.parent = this.transform;
                tile.name = string.Format(CardData.GetName(x, y));
            }
            else{
                CardData.SetName(x, y);
                CardData.SetState(0);
                CardData.SetTeam(0);
                CardData.SetCardID(-1);
                GameObject Card = Instantiate(Resources.Load("Assetname")) as GameObject;
                tile.transform.position = new Vector2(x + 0.5f, y + 0.5f);
                tile.transform.parent = this.transform;
                tile.name = string.Format(CardData.GetName(x, y));
            }
        }
    }
}