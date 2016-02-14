using UnityEngine;
using System.Collections;

public class Player3Controller : MonoBehaviour {
	public float forceSize = 200f;
	public float knockback = 10f;
	
	void OnCollisionEnter(Collision collision) {
		GameObject opposingObject = collision.gameObject;
		
		if ((opposingObject.GetComponent<Rigidbody>() != null) && (opposingObject.CompareTag("Player"))) {
			float horizontal = 0.0f;
			float vertical = 0.0f;
			
			if (opposingObject.GetComponent<Rigidbody>().angularVelocity.z > this.GetComponent<Rigidbody>().angularVelocity.z) {
				horizontal = knockback;
			}
			else if (opposingObject.GetComponent<Rigidbody>().angularVelocity.z == this.GetComponent<Rigidbody>().angularVelocity.z){
				horizontal = knockback/2;
			}
			else {
				horizontal = 0.0f;
			}
			if (opposingObject.GetComponent<Rigidbody>().angularVelocity.x > this.GetComponent<Rigidbody>().angularVelocity.x) {
				vertical = knockback;
			}
			else if (opposingObject.GetComponent<Rigidbody>().angularVelocity.x == this.GetComponent<Rigidbody>().angularVelocity.x) {
				vertical = knockback/2;
			}
			else {
				vertical = 0.0f;
			}
			
			Vector3 velocity = new Vector3 (horizontal,
			                                0.0f, 
			                                vertical);
			GetComponent<Rigidbody>().AddForce (velocity * knockback);
		}
	}
	
	void FixedUpdate() {
		Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);

		float vertical = Input.GetAxis ("Joystick 1 Vertical");
		float horizontal = Input.GetAxis ("Joystick 1 Horizontal");

		movement = new Vector3 (horizontal, 0.0f, vertical);

		GetComponent<Rigidbody>().AddForce(movement * forceSize);
	}
}
