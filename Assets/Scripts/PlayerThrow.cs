using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerThrow : MonoBehaviour { 
    Animator anim;

    [SerializeField]
    GameObject kunaiPrefab;

    [SerializeField]
    Transform hand;

    [SerializeField]
    private float kunaiSpeed;

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
            
            if (GetComponent<PlayerJump>() && GetComponent<PlayerGlide>())
            {
                //Only shoot if (jumping and not gliding) or (running)
                if ((!GetComponent<PlayerJump>().grounded && !GetComponent<PlayerGlide>().gliding) || GetComponent<PlayerMotor>().x == 0)
                {
                    Throw();
                }
            }
            else
                Throw(); //You can still throw if you don't have PlayerJump and PlayerGlide Scripts
        }
    }

    void Throw()
    {
        GameObject _kunai = Instantiate(kunaiPrefab, hand.position, Quaternion.identity);
                
        _kunai.GetComponent<Rigidbody2D>().velocity = hand.right * kunaiSpeed * GetComponent<PlayerMotor>().dir;
        _kunai.transform.up = _kunai.GetComponent<Rigidbody2D>().velocity;
        anim.SetTrigger("Throw");
        Destroy(_kunai, 2);
    }
}
