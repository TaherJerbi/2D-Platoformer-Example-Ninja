using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerJump))]
public class PlayerGlide : MonoBehaviour {
    bool _grounded;

    Rigidbody2D rb2d;
    Animator anim;
    PlayerJump playerJump;

    [SerializeField]
    float glideFactor;

    public bool gliding;

    float initialGravity;
    float Glidegravity;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerJump = GetComponent<PlayerJump>();

        //Calculate Glide gravity
        initialGravity = rb2d.gravityScale;
        Glidegravity = initialGravity / glideFactor;
	}
	
	// Update is called once per frame
	void Update () {

        //Only Glide if GROUNDED and FALLING
        if (!playerJump.grounded && rb2d.velocity.y <=0 && Input.GetKey(KeyCode.LeftShift))
        {
            gliding = true;
            rb2d.gravityScale = Glidegravity;
        }
        else
        {
            gliding = false;
           rb2d.gravityScale = initialGravity;
        }
        anim.SetBool("Glide", gliding);
    }
}
