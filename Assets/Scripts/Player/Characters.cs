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
    public Getter bombCheck;
    float bomberman_T;

    // Bald Pirate

    // Cucumber

    // Big Guy

    // Captain

    // Whale

    [HideInInspector] public int toolbar1;
    [HideInInspector] public int toolbar2;
    [HideInInspector] public string currentTab;

    private void Update() {
        if(InputManager.isPressed(InputManager.manager.primaryAttack)){
            if(isBomberman && Time.time >= bomberman_T && bombCheck.go.Count == 0){
                bomberman_PlaceBomb();
                bomberman_T = Time.time + 1 / bombRate;
            }
            if(isBaldPirate){

            }
        }
    }

    public void bomberman_PlaceBomb () {
        GameObject _bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        _bomb.GetComponent<BombBehaviour>().owner = this;

        GameObject.FindWithTag("Tutorial").GetComponent<MissionSystem>().leftFire = true;
    }

    public void baldPirate_Attack () {
        
    }
}
