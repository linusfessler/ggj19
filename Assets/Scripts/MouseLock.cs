using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour {

    private bool locked = true;

	private void Update() {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
	}
}
