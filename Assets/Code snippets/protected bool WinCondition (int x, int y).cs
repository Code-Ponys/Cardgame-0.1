protected bool WinCondition (int x, int y){
    //horizontal
    if (cardTeamID(x -1, y) == actualTeam() && cardID(x - 1, y) == CardID.Pointcard) {
    	if (cardTeamID(x - 2, y) == actualTeam() && cardID(x - 2, y) == CardID.Pointcard) {
    		return true;
    	}
    	else {
    		if (cardTeamID(x + 1, y) == actualTeam() && cardID(x + 1, y) == CardID.Pointcard) {
    			return true;
    		}
			return false;
    	}
    else {
    	if (cardTeamID(x + 1, y) == actualTeam() && cardID(x + 1, y) == CardID.Pointcard) {
    		if (cardTeamID(x + 2, y) == actualTeam() && cardID(x + 2, y) == CardID.Pointcard) {
    			return true;
		    }
			return false;
	    }
		return false;
    }
	//vertikal
    if (cardTeamID(x, y + 1) == actualTeam() && cardID(x, y + 1) == CardID.Pointcard) {
    	if (cardTeamID(x, y + 2) == actualTeam() && cardID(x, y + 2) == CardID.Pointcard) {
    		return true;
    	}
    	else {
    		if (cardTeamID(x, y - 1) == actualTeam() && cardID(x, y - 1) == CardID.Pointcard) {
    			return true;
    		}
			return false;
    	}
    else {
    	if (cardTeamID(x, y - 1) == actualTeam() && cardID(x, y - 1) == CardID.Pointcard) {
    		if (cardTeamID(x, y - 2) == actualTeam() && cardID(x ,y - 2) == CardID.Pointcard) {
    			return true;
		    }
			return false;
	    }
		return false;
    }
    //diagonal links oben -> rechts unten
    if (cardTeamID(x - 1, y + 1) == actualTeam() && cardID(x - 1, y + 1) == CardID.Pointcard) {
    	if (cardTeamID(x - 2, y + 2) == actualTeam() && cardID(x - 2, y + 2) == CardID.Pointcard) {
    		return true;
    		}
    	else {
    		if (cardTeamID(x + 1, y - 1) == actualTeam() && cardID(x + 1, y - 1) == CardID.Pointcard) {
    			return true;
    		}
			return false;
    	}
    else {
    	if (cardTeamID(x + 1, y - 1) == actualTeam() && cardID(x + 1, y - 1) == CardID.Pointcard) {
    		if (cardTeamID(x + 2, y - 2) == actualTeam() && cardID(x + 2,y - 2) == CardID.Pointcard) {
    			return true;
		    }
			return false;
	    }
		return false;
    }
    //diagonal links unten -> rechts oben
    if (cardTeamID(x - 1, y - 1) == actualTeam() && cardID(x - 1, y - 1) == CardID.Pointcard) {
    	if (cardTeamID(x - 2, y - 2) == actualTeam() && cardID(x - 2, y - 2) == CardID.Pointcard) {
    		return true;
    		}
    	else {
    		if (cardTeamID(x + 1, y + 1) == actualTeam() && cardID(x + 1, y + 1) == CardID.Pointcard) {
    			return true;
    		}
			return false;
    	}
    else {
    	if (cardTeamID(x + 1, y + 1) == actualTeam() && cardID(x + 1, y + 1) == CardID.Pointcard) {
    		if (cardTeamID(x + 2, y + 2) == actualTeam() && cardID(x + 2,y + 2) == CardID.Pointcard) {
    			return true;
		    }
			return false;
	    }
		return false;
    }
}