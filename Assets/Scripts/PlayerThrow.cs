using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerThrow : MonoBehaviour { 
    Animator anim;

    [SerializeField]
    GameObject shuriken;

    [SerializeField]
    Transform hand;

    [SerializeField]
    private float shurikenSpeed;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!GetComponent<PlayerJump>()._grounded || !anim.GetBool("Run"))
            {
                GameObject sh = Instantiate(shuriken, hand.position, Quaternion.identity);
                
                sh.GetComponent<Rigidbody2D>().velocity = hand.right * shurikenSpeed * GetComponent<PlayerMotor>().dir;
                sh.transform.up = sh.GetComponent<Rigidbody2D>().velocity;
                anim.SetTrigger("Throw");
                Destroy(sh, 5f);
            }
        }
    }
}
