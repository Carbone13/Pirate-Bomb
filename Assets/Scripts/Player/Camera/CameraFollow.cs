using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed;

    private void FixedUpdate() {
        if(target.gameObject != null) {
            Vector3 rb = target.gameObject.GetComponent<Rigidbody2D>().velocity;
            Vector3 newPos = Vector3.Lerp(transform.position, target.position + offset, speed);
            transform.position = newPos;
        }

    }
}
