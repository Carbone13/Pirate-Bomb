using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager manager;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public KeyCode altLeft;
    public KeyCode altRight;
    public KeyCode altJump;

    private void Awake() {
		
		if(manager == null)
		{
			DontDestroyOnLoad(gameObject);
			manager = this;
		}	
		else if(manager != this)
		{
			Destroy(gameObject);
		}

        // Get Input from Player Prefs
        jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
		left = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "Q"));
		right = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));

        altJump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("_jumpKey", "Z"));
		altLeft = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("_leftKey", "A"));
		altRight = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("_rightKey", "D"));
    }
}
