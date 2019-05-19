using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyBinder : MonoBehaviour
{
	public Transform keyBindParent;
	Event keyEvent;
	TMP_Text buttonText;
	KeyCode newKey;

	bool waitingForKey;


	void Start ()
	{
		//Assign menuPanel to the Panel object in our Canvas
		//Make sure it's not active when the game starts
        // --> Need review
		keyBindParent.gameObject.SetActive(false);
		waitingForKey = false;

		/*iterate through each child of the panel and check
		 * the names of each one. Each if statement will
		 * set each button's text component to display
		 * the name of the key that is associated
		 * with each command. Example: the ForwardKey
		 * button will display "W" in the middle of it
		 */
         
		for(int i = 0; i < keyBindParent.childCount; i++)
		{
            switch(keyBindParent.GetChild(i).name){
                case "Left":
                    keyBindParent.GetChild(i).GetComponentInChildren<TMP_Text>().text = InputManager.manager.left.ToString();
                    break;
                case "Right":
                    keyBindParent.GetChild(i).GetComponentInChildren<TMP_Text>().text = InputManager.manager.right.ToString();
                    break;
                case "Jump":
                    keyBindParent.GetChild(i).GetComponentInChildren<TMP_Text>().text = InputManager.manager.jump.ToString();
                    break;
            }
		}

        keyBindParent.gameObject.SetActive(true);
	}

	void OnGUI()
	{
		/*keyEvent dictates what key our user presses
		 * bt using Event.current to detect the current
		 * event
		 */
		keyEvent = Event.current;

		//Executes if a button gets pressed and
		//the user presses a key
		if(keyEvent.isKey && waitingForKey)
		{
			newKey = keyEvent.keyCode; //Assigns newKey to the key user presses
			waitingForKey = false;
		}
	}

	/*Buttons cannot call on Coroutines via OnClick().
	 * Instead, we have it call StartAssignment, which will
	 * call a coroutine in this script instead, only if we
	 * are not already waiting for a key to be pressed.
	 */
	public void StartAssignment(string keyName)
	{
		if(!waitingForKey)
			StartCoroutine(AssignKey(keyName));
	}

	//Assigns buttonText to the text component of
	//the button that was pressed
	public void SendText(TMP_Text text)
	{
		buttonText = text;
	}

	//Used for controlling the flow of our below Coroutine
	IEnumerator WaitForKey()
	{
		while(!keyEvent.isKey)
			yield return null;
	}

	/*AssignKey takes a keyName as a parameter. The
	 * keyName is checked in a switch statement. Each
	 * case assigns the command that keyName represents
	 * to the new key that the user presses, which is grabbed
	 * in the OnGUI() function, above.
	 */
	public IEnumerator AssignKey(string keyName)
	{
		waitingForKey = true;

		yield return WaitForKey(); //Executes endlessly until user presses a key

		switch(keyName)
		{
            case "left":
                InputManager.manager.left = newKey; //Set forward to new keycode
                buttonText.text = InputManager.manager.left.ToString(); //Set button text to new key
                PlayerPrefs.SetString("leftKey", InputManager.manager.left.ToString()); //save new key to PlayerPrefs
                break;
            case "right":
                InputManager.manager.right = newKey; //set backward to new keycode
                buttonText.text = InputManager.manager.right.ToString(); //set button text to new key
                PlayerPrefs.SetString("rightKey", InputManager.manager.right.ToString()); //save new key to PlayerPrefs
                break;
            case "jump":
                InputManager.manager.jump = newKey; //set left to new keycode
                buttonText.text = InputManager.manager.jump.ToString(); //set button text to new key
                PlayerPrefs.SetString("jumpKey", InputManager.manager.jump.ToString()); //save new key to playerprefs
                break;
		}

		yield return null;
	}    
}
