using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {
    
    [SerializeField] private ParticleSystem destructionEffectPrefab;
    [SerializeField] private AudioClip destructionSound;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor")) {
            ParticleSystem destructionEffect = Instantiate<ParticleSystem>(destructionEffectPrefab);
            destructionEffect.transform.position = transform.position;
            destructionEffect.Play();
            Destroy(destructionEffect, destructionEffect.main.duration);

            GameObject audio = new GameObject();
            audio.transform.position = transform.position;
            AudioSource audioSource = audio.AddComponent<AudioSource>();
            audioSource.clip = destructionSound;
            audioSource.loop = false;
            audioSource.spatialBlend = 1;
            audioSource.Play();
            Destroy(audio, destructionSound.length);

            Score.Instance.Value++;

            Destroy(gameObject);
        }
    }
}
