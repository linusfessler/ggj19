using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    
    [SerializeField] private float angularSpeed;
    [SerializeField] private Renderer bounds;

    private Quaternion targetRotation;
    private Vector3 center;
    private Vector3 extents;

    private void Awake() {
        targetRotation = transform.rotation;
        center = bounds.bounds.center;
        extents = bounds.bounds.extents;
    }

    private void Update() {
        if (transform.rotation == targetRotation) {
            Vector3 position = center + new Vector3(Random.Range(-extents.x, extents.x), Random.Range(-extents.y, extents.y), Random.Range(-extents.z, extents.z));
            Quaternion tempRotation = transform.rotation;
            transform.LookAt(position, Vector3.up);
            targetRotation = transform.rotation;
            transform.rotation = tempRotation;
        }
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Time.deltaTime);
    }
}
