using UnityEngine;
using System.Collections;

public class FirstPersonCamera : MonoBehaviour {

    [SerializeField] private Transform player;
	[SerializeField] private new Transform camera;
    [SerializeField] private Vector2 angleRange = new Vector2(85, 275);

	private void Update() {
		float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;
		player.Rotate(0, mouseX, 0);
		camera.Rotate(-mouseY, 0, 0);
		camera.localEulerAngles = new Vector3(MathUtility.ClampAngle(camera.localEulerAngles.x, angleRange.x, angleRange.y), 0, 0);
	}
}
