using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	public float smoothSpeed = 2f;
	public Vector3 offset;
	Vector3 offsetGoingLeft = new Vector3(-4.5f, 0f, -10f);
	Vector3 offsetGoingRight = new Vector3(4.5f, 0f, -10f);
	float goingRight;
	Vector3 desiredPosition;
	Vector3 smoothedPosition;
	public GameObject playerObject;

	void Update () {
		if (playerObject.GetComponent<PlayerRules>().stunned == false) {
			goingRight = Input.GetAxisRaw("Horizontal");
			if (Input.GetAxisRaw("Horizontal") > 0.5) {
				desiredPosition = player.position + offsetGoingRight;
			} else if (Input.GetAxisRaw("Horizontal") < -0.5) {
				desiredPosition = player.position + offsetGoingLeft;
			} else {
				desiredPosition = player.position + offset;
			}
			smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
			transform.position = smoothedPosition;
		}
	}
}
