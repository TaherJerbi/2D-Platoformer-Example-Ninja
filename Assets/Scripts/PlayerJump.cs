using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour {

    Animator anim;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private bool grounded;

    public bool _grounded { get { return grounded; }
        private set { grounded = value; }
    }
    [SerializeField]
    Collider2D groundCheck;
    [SerializeField]
    LayerMask ground;

    Rigidbody2D rb2d;
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (groundCheck.IsTouchingLayers(ground))
            _grounded = true;
        else _grounded = false;

        anim.SetBool("Grounded", _grounded);

        if(_grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector3.up * jumpForce);
            
        }
    }
}
