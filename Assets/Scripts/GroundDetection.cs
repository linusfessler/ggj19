using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundDetection : MonoBehaviour {
	
	[SerializeField] private bool isGrounded = false;
	[SerializeField] private UnityEvent onGroundEnter = new UnityEvent();
	[SerializeField] private UnityEvent onGroundExit = new UnityEvent();

	public UnityEvent OnGroundEnter { get { return onGroundEnter; } }
	public UnityEvent OnGroundExit { get { return onGroundExit; } }

	public bool IsGrounded {
		get { return isGrounded; }
		private set {
			if (isGrounded && !value) {
				OnGroundExit.Invoke();
			} else if (!isGrounded && value) {
				OnGroundEnter.Invoke();
			}
			isGrounded = value;
		}
	}

	private void OnTriggerEnter(Collider collider) {
		if (!collider.isTrigger) {
			IsGrounded = true;
		}
	}

	private void OnTriggerStay(Collider collider) {
		if (!collider.isTrigger) {
			IsGrounded = true;
		}
	}

	private void OnTriggerExit(Collider collider) {
		if (!collider.isTrigger) {
			IsGrounded = false;
		}
	}
}
