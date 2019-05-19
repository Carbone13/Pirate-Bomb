using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager manager;

	public Axis horizontal;
	public Axis vertical;

	public S13Key jump;
	public S13Key primaryAttack;
	public S13Key secondaryAttack;
	public S13Key submit;


	[HideInInspector] public int toolbarTab;
	[HideInInspector] public string currentTab;

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
		PlayerPrefs.SetString("horizontalAltNegative", "LeftArrow");
        // Get Input from Player Prefs
		horizontal = SetupAxis((KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("horizontalPositive", "D")),
								(KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("horizontalNegative", "Q")),
								(KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("horizontalAltPositive", "RightArrow")),
								(KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("horizontalAltNegative", "LeftArrow"))
		);

		vertical = SetupAxis((KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("verticalPositive", "Z")),
								(KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("verticalNegative", "S")),
								(KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("verticalAltPositive", "DownArrow"))
		);

		jump = SetupKey((KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpFirst", "Space")),
							(KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpSecond", "UpArrow"))
		);

		primaryAttack = SetupKey((KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("primaryAttack", "Mouse0"))
		);

		secondaryAttack = SetupKey((KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("secondaryAttack", "Mouse1"))
		);

		submit = SetupKey((KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("submit", "Return"))
		);
    }

	private Axis SetupAxis (KeyCode positive, KeyCode negative, KeyCode altPositive = KeyCode.None, KeyCode altNegative = KeyCode.None){
		Axis _n = new Axis();
		_n.positive = positive;
		_n.negative = negative;
		_n.altPositive = altPositive;
		_n.altNegative = altNegative;

		return _n;
	}

	private S13Key SetupKey (KeyCode first, KeyCode second = KeyCode.None){
		S13Key _n = new S13Key();
		_n.first = first;
		_n.second = second;

		return _n;
	}


	public static int GetAxis (Axis axis) {
		if(Input.GetKey(axis.positive) || Input.GetKey(axis.altPositive)){
			return 1;
		} else if(Input.GetKey(axis.negative) || Input.GetKey(axis.altNegative)){
			return -1;
		}

		return 0;
	}

	public static bool isPressed (S13Key key){
		if(Input.GetKey(key.first) || Input.GetKey(key.second)){
			return true;
		}
		return false;
	}

	public static bool isPressedDown (S13Key key){
		if(Input.GetKeyDown(key.first) || Input.GetKeyDown(key.second)){
			return true;
		}
		return false;
	}
}

[System.Serializable]
public class Axis {
	public KeyCode positive;
	public KeyCode negative;
	[Space]
	public KeyCode altPositive;
	public KeyCode altNegative;

}

[System.Serializable]
public class S13Key {
	public KeyCode first;
	public KeyCode second;
}
