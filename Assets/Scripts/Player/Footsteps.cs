using System.Collections;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource source;
    public float timeBetweenStep;
    public AudioClip[] steps;
    AudioClip nextStep;
    int stepID;

    private void Start() {
        nextStep = steps[0];
        stepID = 0;
        InvokeRepeating("NextStep", 0, timeBetweenStep);
    }

    public void NextStep () {
        stepID++;
        if(stepID >= steps.Length) stepID = 0;
        nextStep = steps[stepID];

        if(transform.parent.gameObject.GetComponent<PlayerMovement>()._Move) source.PlayOneShot(nextStep);
        else source.Stop();

        if(!transform.parent.gameObject.GetComponent<PlayerMovement>()._Grounded) source.Stop();
    }
}