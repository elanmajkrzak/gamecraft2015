using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {
	public float forceSize = 200f;
	public float knockback = 10f;
	public bool keyControls = true;
	public bool joystickControls = false;

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

		if (keyControls) {
			movement = keyboardMovement ();
		}
		else if (joystickControls) {
			movement = joyStickMovement();
		}
		GetComponent<Rigidbody>().AddForce(movement * forceSize);
	}

	Vector3 keyboardMovement() {
		float moveLeft = 0.0f;
		float moveRight = 0.0f;
		float moveForward = 0.0f;
		float moveBack = 0.0f;
		
		if (Input.GetKey ("left")) {
			moveLeft = 1.0f;
		}
		if (Input.GetKey ("right")) {
			moveRight = 1.0f;
		}
		if (Input.GetKey ("up")) {
			moveForward = 1.0f;
		}
		if (Input.GetKey ("down")) {
			moveBack = 1.0f;
		}
		return new Vector3 (moveRight - moveLeft, 0.0f, moveForward - moveBack);
	}

	Vector3 joyStickMovement() {
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");

		return new Vector3 (horizontal, 0.0f, vertical);
	}
}
