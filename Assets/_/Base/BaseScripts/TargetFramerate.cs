using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFramerate : MonoBehaviour {


    private void Awake() {
        Application.targetFrameRate = 100;
    }

}