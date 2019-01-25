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
}