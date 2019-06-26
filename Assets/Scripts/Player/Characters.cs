using Carbone13;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public bool isBomberman;
    public bool isBaldPirate;
    public bool isCucumber;
    public bool isGuy;
    public bool isCaptain;
    public bool isWhale;

    // Bomber Man
    public float bombRate = 1f;
    public GameObject bombPrefab;
    float t;

    [HideInInspector] public int toolbar1;
    [HideInInspector] public int toolbar2;
    [HideInInspector] public string currentTab;

    private void Update() {
        if(isBomberman){
            if(InputManager.isPressed(InputManager.manager.primaryAttack) && Time.time >= t){
                bomberman_PlaceBomb();
                t = Time.time + 1 / bombRate;
            }
        }
    }

    public void bomberman_PlaceBomb () {
        GameObject _bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        _bomb.GetComponent<BombBehaviour>().owner = this;

        GameObject.FindWithTag("Tutorial").GetComponent<MissionSystem>().leftFire = true;
    }
}
