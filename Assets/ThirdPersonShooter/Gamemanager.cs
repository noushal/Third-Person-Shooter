using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour {

    public void Play() {
        SceneManager.LoadScene("Playground");
    }

    public void Stop() {
        Application.Quit();
    }

}
