using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    private void Awake() {
    }
    void Start() {
    }
    void Update() {
        if (IsDown) {
            MouseButtonDown();
        }
    }
    public void MouseButtonDown() {
        mp = MP;
    }
}