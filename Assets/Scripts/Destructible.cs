using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {
    
    [SerializeField] private ParticleSystem destructionEffectPrefab;
    //[SerializeField] private AudioClip destructionSound;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor")) {
            ParticleSystem destructionEffect = Instantiate<ParticleSystem>(destructionEffectPrefab);
            destructionEffect.transform.position = collision.GetContact(0).point;
            destructionEffect.Play();
            Destroy(destructionEffect, destructionEffect.main.duration);

            // GameObject audio = new GameObject();

            Score.Instance.Value++;

            Destroy(gameObject);
        }
    }
}
