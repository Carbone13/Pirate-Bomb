using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float splashTime;

    private void Start() {
        StartCoroutine(Splash());
    }

    IEnumerator Splash () {
        yield return new WaitForSeconds(splashTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
