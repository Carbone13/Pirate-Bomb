using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float splashTime;
    public Transition fader;

    private void Start() {
        StartCoroutine(Splash());
    }

    IEnumerator Splash () {
        yield return new WaitForSeconds(splashTime - 0.1f);
        if(fader != null){
            fader.gameObject.SetActive(true);
            fader.sceneToLoad = 1;
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
