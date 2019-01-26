using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : SingletonBehaviour<GameOver> {
    
    [SerializeField] private Image image;
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioSource sound;
    [SerializeField] Color color1 = new Color(0, 0, 0, 0);
    [SerializeField] Color color2 = new Color(0, 0, 0, 1);
    [SerializeField, Range(0, 10)] private float fadeInTime = 1;

    private bool canRetry;

    private bool value;
    public bool Value {
        get { return value; }
        set {
            if (this.value == value) {
                return;
            }
            gameObject.SetActive(value);
            if (value) {
                scoreText.text = "Score: " + Score.Instance.Value.ToString("N0");
                sound.Play();
                StartCoroutine(LerpImageColor());
            } else {
                image.color = color1;
                canRetry = false;
            }
            this.value = value;
        }
    }

    protected override void Awake() {
        base.Awake();
        gameObject.SetActive(false);
    }

    private void Update() {
        if (canRetry && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private IEnumerator LerpImageColor() {
        float t = 0;
        while (t < 1) {
            image.color = Color.Lerp(color1, color2, t);
            t += 1 / fadeInTime * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        canRetry = true;
    }
}
