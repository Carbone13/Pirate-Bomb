using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("In-Game Debug")]
    public bool _Move;
    public bool _Grounded;
    public bool _Jump;
    public bool _Fall;
    public bool _FacingRight;

    [Header("Player Variables")]
    public float speed = 1f;
    public float jumpForce = 5f;
    [Range(0, 0.2f)] 
    public float movementSmoothing = 0.1f;
    public float groundCheckRadius = 1f;
    public bool invertFacing;

    [Header("References")]
    public Rigidbody2D Rigidbody;
    Rigidbody2D rb {
        get {
            return Rigidbody;
        }
    }
    public Collider2D Collider;
    Collider2D coll {
        get {
            return Collider;
        }
    }
    public Animator Animator;
    Animator anim {
        get {
            return Animator;
        }
    }
    public Transform groundCheck;
    public GameObject RunParticle;

    float x;
    bool jump;
    Vector3 refVelocity = Vector3.zero;

    //Custom Editor
    [HideInInspector] public int toolbarTab;
    [HideInInspector] public string currentTab;

    private void Update() {
        x = InputManager.GetAxis(InputManager.manager.horizontal);
        jump = InputManager.isPressed(InputManager.manager.jump);
    }

    private void FixedUpdate() {
        bool wasGrounded = _Grounded;
        _Grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius / 100);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject && rb.velocity.y > -0.1 && rb.velocity.y < 0.1 && colliders[i].gameObject.layer != 10)
			{
				_Grounded = true;
                if(!wasGrounded){
                    if(_Jump){
                        anim.SetBool("doingJump", false);
                        anim.SetTrigger("land");
                    }
                    _Jump = false;
                }
			} 
		}

        if(rb.velocity.y == 0){
            GetComponent<BoxCollider2D>().enabled = _Grounded;
        }
        Move ();
    }

    private void Move () {

        _Jump = !_Grounded;
        Vector3 targetMove = new Vector2(x * 4 * 1.2f * 40 * speed * Time.fixedDeltaTime, rb.velocity.y);
        if(targetMove.x == 0){
            // Stop without smoothing
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetMove, ref refVelocity, 0);
        } else {
            // Move but smoothly
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetMove, ref refVelocity, movementSmoothing);
        }

        if(jump && !_Jump){
            _Jump = true;
            rb.AddForce(new Vector2(0f, jumpForce * 55 * 52 * Time.fixedDeltaTime));
            print("jump");
        }

        if(x > 0) _FacingRight = true;
        if(x < 0) _FacingRight = false;   

        _Move = x != 0;
        _Fall = rb.velocity.y < 0;
        RunParticle.SetActive(_Move && _Grounded);

        AnimatorUpdate();
    }

    private void AnimatorUpdate () {
        if(!invertFacing)
            transform.localScale = new Vector3(_FacingRight ? transform.localScale.y : -transform.localScale.y, transform.localScale.y);
        else
            transform.localScale = new Vector3(_FacingRight ? -transform.localScale.y : transform.localScale.y, transform.localScale.x);

        anim.SetBool("falling", _Fall);
        anim.SetBool("grounded", _Grounded);

        if(_Jump){
            anim.SetTrigger("jump");
            anim.SetBool("doingJump", true);
        } else if(_Move){
            anim.SetTrigger("run");
        } else if(!_Move){
            anim.SetTrigger("idle");
        }
    }
}
