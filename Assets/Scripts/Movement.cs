using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {

	[SerializeField] private new Rigidbody rigidbody;
	[SerializeField] private GroundDetection groundDetection;
	[SerializeField, Range(0, 25)] private int speed = 5;
	[SerializeField, Range(0, 90)] private int maxSlope = 45;

	private void Awake() {

	}

	private void FixedUpdate () {
		float x = Input.GetAxis("MoveX");
		float z = Input.GetAxis("MoveZ");
		//x *= 0.5f;
		//z *= (z < 0) ? 0.25f : 1;
		Vector3 direction = (x * rigidbody.transform.right + z * rigidbody.transform.forward).normalized;
		if (SweepTest(direction)) {
			rigidbody.velocity = speed * direction;
		}
	}

	// prevents moving on a slope
	private bool SweepTest(Vector3 direction) {
		if (!groundDetection.IsGrounded) {
			float distance = speed * Time.fixedDeltaTime;
			RaycastHit raycastHit;
			rigidbody.SweepTest(direction, out raycastHit, distance);
			if (raycastHit.collider && Vector3.Angle(raycastHit.normal, rigidbody.transform.up) > maxSlope) {
				return false;
			}
		}
		return true;
	}
}
