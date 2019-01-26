using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour {

    [SerializeField] private GameObject[] disableOnExit;
    [SerializeField] private GameObject[] respawnOnExit;

    private GameObject[] respawnOnExitPrefabs;

    private void Awake() {
        foreach (GameObject d in disableOnExit) {
            d.SetActive(false);
        }

        respawnOnExitPrefabs = new GameObject[respawnOnExit.Length];
        for (int i = 0; i < respawnOnExitPrefabs.Length; i++) {
            respawnOnExitPrefabs[i] = Instantiate<GameObject>(respawnOnExit[i]);
            respawnOnExitPrefabs[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            foreach (GameObject d in disableOnExit) {
                d.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            foreach (GameObject d in disableOnExit) {
                d.SetActive(false);
            }
        }
        
        for (int i = 0; i < respawnOnExit.Length; i++) {
            if (respawnOnExit[i]) {
                Destroy(respawnOnExit[i]);
            }
            respawnOnExit[i] = Instantiate<GameObject>(respawnOnExitPrefabs[i]);
            respawnOnExit[i].SetActive(true);
        }
    }
}
