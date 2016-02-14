using UnityEngine;
using System.Collections;

public class killPlaneFunctions : MonoBehaviour {
	public Transform gameOverUI;
	
	void OnCollisionEnter(Collision collision) {
		GameObject opposingObject = collision.gameObject;
		
		if (opposingObject.CompareTag("Player")) {
			SceneSwitcher.curPlayers--;

			if (SceneSwitcher.curPlayers == 1) {
				Instantiate(gameOverUI, new Vector3(0, 0, 0), Quaternion.identity);
			}
			
			Destroy(opposingObject, 0.0f);
		}
	}
}
