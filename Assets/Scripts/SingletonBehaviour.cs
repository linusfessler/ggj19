using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour {

	private static T instance;
	public static T Instance {
		get {
			if (!Application.isPlaying && !instance) {
				instance = GameObject.FindObjectOfType<T>();
			}
			return instance;
		}
		private set { instance = value; }
	}

	protected virtual void Awake() {
		T t = GetComponent<T>();
		if (Instance == null) {
			Instance = t;
		} else if (Instance != t) {
			Debug.LogWarning("Another instance of singleton " + Instance.GetType() + " was found, destroying it ...");
			Destroy(gameObject);
		}
	}
}
