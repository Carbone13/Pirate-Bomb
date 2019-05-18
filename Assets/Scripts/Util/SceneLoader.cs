using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene (int index, bool async = false){
        if(async){
            SceneManager.LoadSceneAsync(index);
        } else {
            SceneManager.LoadScene(index);
        }
    }

    public void LoadGame () {
        LoadScene(3);
    }

    public void QuitGame () {
        Application.Quit();
    }
}
