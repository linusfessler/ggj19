using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {

	[SerializeField] private new Rigidbody rigidbody;
	[SerializeField, Range(0, 25)] private int speed = 5;

	private void FixedUpdate () {
		float x = Input.GetAxis("MoveX");
		float z = Input.GetAxis("MoveZ");
		Vector2 direction2 = new Vector2(x, z).normalized;
		//direction2 = new Vector2(direction2.x, (direction2.y < 0 ? 0.5f : 1) * direction2.y);
		Vector3 direction3 = direction2.x * rigidbody.transform.right + direction2.y * rigidbody.transform.forward;
		rigidbody.MovePosition(rigidbody.position + speed * Time.fixedDeltaTime * direction3);
	}
}
