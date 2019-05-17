using System.Collections.Generic;
using UnityEngine;

public class Getter : MonoBehaviour
{
    public string[] tags;
    public List<GameObject> go = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other) {
        for(int i = 0; i < tags.Length; i++){
            if(other.gameObject.tag == tags[i]){
                go.Add(other.gameObject);
            }
        }        
    }

    private void OnTriggerExit2D(Collider2D other) {
        for(int i = 0; i < go.Count; i++){
            if(other.gameObject == go[i]){
                go.Remove(other.gameObject);
            }
        }
    }
}
