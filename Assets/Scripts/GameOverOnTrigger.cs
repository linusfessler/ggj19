using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnTrigger : MonoBehaviour {
    
    [SerializeField] private new Transform camera;

    private void OnTriggerStay(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            //RaycastHit raycastHit;
            //Physics.Raycast(camera.position, camera.forward, out raycastHit, Vector3.Distance(camera.position, collider.transform.position), LayerMask.NameToLayer("Player"), QueryTriggerInteraction.Ignore);
            //if (!raycastHit.collider) {
                GameOver.Instance.Value = true;
            //}
        }
    }
}
