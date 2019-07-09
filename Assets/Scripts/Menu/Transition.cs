using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public int sceneToLoad;
    public bool loadAlone;

    
    void Start()
    {
        DontDestroyOnLoad(transform.parent.transform.parent.gameObject);
        this.gameObject.SetActive(false);
    }

    public void OnEndExpand () {
        GetComponent<Animator>().SetTrigger("Close");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }

    public void Finished () {
        Destroy(this.transform.parent.gameObject);
    }
}
