using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    [Tooltip("0 = Burning ; 1 = Off ; 3 = Explode")]
    public int burnState = 0;
    public float bombForce = 5f;
    public float bombRadius = 2.5f;
    public float timeBeforeExplosion;

    Animator anim;
    public Characters owner;
    public Animator LoadingBar;
    public Getter getter;

    private void Start() {
        anim = GetComponent<Animator>();
        StartCoroutine(WaitForExplode());
    }

    private void Update() {
        if(burnState == 0) anim.SetTrigger("on");
        if(burnState == 1) anim.SetTrigger("off");
        if(burnState == 3) anim.SetTrigger("explode");
    }

    IEnumerator WaitForExplode () {
        LoadingBar.SetFloat("Duration", 0.342f / timeBeforeExplosion);

        yield return new WaitForSeconds(timeBeforeExplosion);

        if(burnState == 0){        
            Destroy(transform.GetChild(0).gameObject);

            for(int i = 0; i < getter.go.Count; i++){

                if(getter.go[i].tag == "Props" || getter.go[i].tag == "Bomb"){
                    getter.go[i].GetComponent<Props>().ExplodeProps(bombForce * 100, new Vector2(transform.position.x, transform.position.y - 1.75f), bombRadius * 10);
                }

                if(getter.go[i].tag == "Player"){
                    if(owner.gameObject != getter.go[i]){
                        ExplosionForce2D.AddExplosionForce(getter.go[i].GetComponent<Rigidbody2D>(), bombForce * 100, new Vector2(transform.position.x, transform.position.y - 2.5f), bombRadius * 10);
                    }  
                }         
            }

            burnState = 3; 
        } else if(burnState == 1){
            Destroy(this.gameObject);
        }
    }

    public void Explode () {

        Destroy(this.gameObject);
    }
}
