using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public int sceneToLoad;
    public bool loadAlone;

    
    void Start()
    {
        DontDestroyOnLoad(transform.parent.gameObject);
        GetComponent<CanvasGroup>().alpha = 1;
        this.gameObject.SetActive(false);
    }

    public void OnEndExpand () {
        for(int i = 0; i < transform.parent.childCount; i++){
            if(transform.parent.GetChild(i) != this.transform){
                Destroy(transform.parent.GetChild(i).gameObject);
            }
        }
        GetComponent<Animator>().SetTrigger("Close");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }

    public void Finished () {
        Destroy(this.transform.parent.gameObject);
    }
}
