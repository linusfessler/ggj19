using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : SingletonBehaviour<Score> {
    
    [SerializeField] private Text text;

    private int value;
    public int Value {
        get { return value; }
        set {
            text.text = value.ToString("N0");
            this.value = value;
        }
    }

    protected override void Awake() {
        base.Awake();
        Value = 0;
    }
}
