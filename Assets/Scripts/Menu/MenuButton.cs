using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public MenuButtonController menuButtonController;
	public Animator animator;
	public AnimatorFunctions animatorFunctions;
	public int thisIndex;
	public bool disableAllOnClick;
	public Transition fader;
	public int sceneToLoad;
	public UnityEvent OnClick;
	bool hovered;

	[HideInInspector] public int toolbarTab;
	[HideInInspector] public string currentTab;

    // Update is called once per frame
    void Update()
    {
		if(!menuButtonController.active) return;

		if(menuButtonController.useKeyboard){
			if(menuButtonController.index == thisIndex){
				animator.SetBool("selected", true);

				if(Input.GetAxis ("Submit") == 1 && enabled){
					animator.SetBool("pressed", true);
					if(disableAllOnClick){
						menuButtonController.active = false;
					}
				} else if (animator.GetBool ("pressed")){
					animator.SetBool ("pressed", false);
					animatorFunctions.disableOnce = true;			
				}
			} else {
				animator.SetBool ("selected", false);
			}
		}

		if(menuButtonController.useMouse){
			if(menuButtonController.index == thisIndex){
				animator.SetBool("selected", true);

				if(Input.GetButtonDown("Fire1") && hovered && enabled){
					animator.SetBool("pressed", true);
					if(disableAllOnClick){
						menuButtonController.active = false;
					}
				} else if (animator.GetBool ("pressed")){
					animator.SetBool ("pressed", false);
					animatorFunctions.disableOnce = true;			
				}
			} else {
				animator.SetBool ("selected", false);
			}
		}
    }

	public void InvokeClick () {
			OnClick.Invoke();
			fader.gameObject.SetActive(true);
			if(sceneToLoad != -1) fader.sceneToLoad = sceneToLoad;
		}

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if(menuButtonController.useMouse){
			menuButtonController.index = this.thisIndex;
			hovered = true;
		} 
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if(menuButtonController.useMouse){
			if(!menuButtonController.useKeyboard){
				menuButtonController.index = -1;
			}
			hovered = false;
		}
    }
}
