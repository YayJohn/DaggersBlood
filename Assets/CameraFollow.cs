﻿using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	public float smoothSpeed = 2f;
	public Vector3 offset;

	void FixedUpdate () {
		Vector3 desiredPosition = player.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
	}
}
