using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour {

	// Use this for initialization
	public bool useKeyboard = true;
	public bool useMouse = true;
	public bool active = true;
	public int index;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	[HideInInspector] public AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {

		if(useKeyboard){

			if(Input.GetAxis ("Vertical") != 0) { 
				if(!keyDown){
					if (Input.GetAxis ("Vertical") < 0){
						if(index < maxIndex){
							index++;
						} else {
							index = 0;
						}
					} else if(Input.GetAxis ("Vertical") > 0){
						if(index > 0){
							index --; 
						} else {
							index = maxIndex;
						}
					}
					keyDown = true;
				}
			} else {
				keyDown = false;
			}
		}
	}

}
