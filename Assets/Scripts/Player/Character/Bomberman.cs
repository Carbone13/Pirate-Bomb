using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomberman : MonoBehaviour
{
    public float placeRate = 1f;
    public GameObject bombPrefab;
    float t;

    private void Update() {
        if(Input.GetButtonDown("Fire1") && Time.time >= t){
            PlaceBomb();
            t = Time.time + 1 / placeRate;
        }
    }

    private void PlaceBomb () {
        GameObject _bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        _bomb.GetComponent<BombBehaviour>().owner = this;
    }
}
