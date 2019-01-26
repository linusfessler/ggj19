using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jump : MonoBehaviour {

	public UnityAction jumpAction;
	
	[SerializeField] private new Rigidbody rigidbody;
	[SerializeField] private GroundDetection groundDetection;
	[SerializeField, Range(0, 100)] private int speed = 15;
	[SerializeField, Range(0, 1)] private float timeToEnsureGroundExit = 0.25f;
	[SerializeField, Range(0, 1)] private float timeToEnsureGroundEnter = 0.05f;

	private float timeInAir;
	private float TimeInAir {
		get { return timeInAir; }
		set { timeInAir = Mathf.Clamp(value, 0, timeToEnsureGroundExit); }
	}

	private float timeOnGround;
	private float TimeOnGround {
		get { return timeOnGround; }
		set { timeOnGround = Mathf.Clamp(value, 0, timeToEnsureGroundEnter); }
	}

	private void Awake() {
		groundDetection.OnGroundEnter.AddListener(OnGroundEnter);
	}

	private void FixedUpdate() {
		TimeInAir += Time.fixedDeltaTime;
		TimeOnGround += Time.fixedDeltaTime;
		if (groundDetection.IsGrounded && TimeInAir == timeToEnsureGroundExit && TimeOnGround == timeToEnsureGroundEnter && Input.GetButton("Jump")) {
			_Jump();
		}
	}

	private void _Jump() {
		TimeInAir = 0;
		if (jumpAction == null) {
			rigidbody.velocity += speed * (0.8f * rigidbody.transform.up + 0.2f * rigidbody.transform.forward);
			//rigidbody.velocity += speed * rigidbody.transform.up;
			// play jump sound here
		} else {
			jumpAction();
		}
	}

	private void OnGroundEnter() {
		TimeOnGround = 0;
		rigidbody.velocity = Vector3.zero;
	}
}
