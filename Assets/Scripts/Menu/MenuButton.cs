using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
	public Transition fader;
	public int sceneToLoad;
	public UnityEvent OnClick;

    // Update is called once per frame
    void Update()
    {

			if(menuButtonController.index == thisIndex)
			{
				animator.SetBool ("selected", true);

				if(Input.GetAxis ("Submit") == 1) {
					animator.SetBool ("pressed", true);
				} else if (animator.GetBool ("pressed")){
					animator.SetBool ("pressed", false);
					animatorFunctions.disableOnce = true;
				}
			} else {
				animator.SetBool ("selected", false);
			}
    }

		public void InvokeClick () {
			OnClick.Invoke();
			fader.gameObject.SetActive(true);
			if(sceneToLoad != -1) fader.sceneToLoad = sceneToLoad;
		}

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if(!menuButtonController.navigateWithKeyboard) menuButtonController.index = this.thisIndex;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if(!menuButtonController.navigateWithKeyboard) menuButtonController.index = -1;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(!menuButtonController.navigateWithKeyboard) animator.SetBool ("pressed", true);
    }


}
