using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : MonoBehaviour
{
    public void ExplodeProps (float expForce, Vector3 expPosition, float expRadius) {
		ExplosionForce2D.AddExplosionForce(GetComponent<Rigidbody2D>(), expForce * 2, expPosition, expRadius * 10);
    }
}
