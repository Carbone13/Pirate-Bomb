using TMPro;
using UnityEngine;

namespace Carbone13
{
    public class MissionSystem : MonoBehaviour
    {

        public bool a, d, space;
        public bool leftFire;

        public TMP_Text move, attack;
        
        private void Update() {
            if(!d) d = InputManager.GetAxis(InputManager.manager.horizontal) > 0;
            if(!a) a = InputManager.GetAxis(InputManager.manager.horizontal) < 0;
            if(!space) space = InputManager.isPressed(InputManager.manager.jump);

            if(a && d && space){
                move.fontStyle = TMPro.FontStyles.Strikethrough;
                move.color = new Color(1, 1, 1, 0.4f);
                move.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0.4f);
            }

            if(leftFire){
                attack.fontStyle = TMPro.FontStyles.Strikethrough;
                attack.color = new Color(1, 1, 1, 0.4f);
                attack.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0.4f);
            }
        }
    }
}