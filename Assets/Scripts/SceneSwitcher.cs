using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour {
	static public int curPlayers = 0;
	static public int maxPlayers = 0;
	static public int player1Controls = 0;
	static public int player2Controls = 0;

	public void twoPlayerLoad() {
		Application.LoadLevel("Two_Player_Level_1");
		curPlayers = 2;
		maxPlayers = 2;
	}
	
	public void threePlayerLoad() {
		Application.LoadLevel("Three_Player_Level_1");
		curPlayers = 3;
		maxPlayers = 3;
	}
	
	public void fourPlayerLoad() {
		Application.LoadLevel("Four_Player_Level_1");
		curPlayers = 4;
		maxPlayers = 4;
	}

	public void restartLoad() {
		switch (maxPlayers) {
			case 2:
				twoPlayerLoad();
				break;
			case 3:
				threePlayerLoad();
				break;
			case 4:
				fourPlayerLoad();
				break;
			default:
				menuLoad();
				break;
		}
	}
	
	public void menuLoad() {
		Application.LoadLevel("Title_Screen");
		curPlayers = 0;
		maxPlayers = 0;
	}
}
