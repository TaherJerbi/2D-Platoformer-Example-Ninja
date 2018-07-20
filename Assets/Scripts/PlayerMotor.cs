using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour {
    Animator anim;
    Rigidbody2D rb2d;

    [SerializeField]
    float speed;

    Vector2 leftScale; 
    Vector2 scale;

    public float x;
    //This is used to determine the player's direction when shooting kunai
    public int dir;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        // Set Scale and left scale Vectors
        scale = transform.localScale;

        //Calculate the inverse scale
        leftScale = scale;
        leftScale.x = -scale.x;
        //Determine the initial direction
        dir = Mathf.RoundToInt(Mathf.Sign(scale.x));
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
        x = Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime;
        rb2d.velocity = new Vector2(x,rb2d.velocity.y);

        anim.SetBool("Run", x != 0);
        Flip(x);
    }

    //Flip the player to meet the movement direction
    void Flip(float x)
    {
        if (x < 0)
        {
            dir = -1;
            transform.localScale = leftScale;
        }
        if (x > 0)
        {
            dir = 1;
            transform.localScale = scale;
        }
    }
}
