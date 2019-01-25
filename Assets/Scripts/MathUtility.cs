using System;
using System.Collections;
using UnityEngine;

public static class MathUtility {

	public static float ClampAngle(float angle, float min, float max) {
		if (angle > min && angle < 180) {
			return min;
		} else if (angle >= 180 && angle < max) {
			return max;
		}
		return angle;
	}

	public static IEnumerator SmoothInterpolate(Action<float> action, float time) {
		float t = 0;
		while (t < 1) {
			t = Mathf.Clamp(t + Time.deltaTime / time, 0, 1);
			action(Mathf.SmoothStep(0, 1, t));
			yield return new WaitForEndOfFrame();
		}
	}
}