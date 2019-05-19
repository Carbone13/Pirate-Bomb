using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsCleaner : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

}
