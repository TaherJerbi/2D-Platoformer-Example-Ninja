using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    float speed;

    Vector2 leftScale; 
    Vector2 scale;

    public int dir;
	// Use this for initialization
	void Start () {
        // Set Scale and left scale Vectors
        scale = transform.localScale;
        leftScale = scale;
        leftScale.x = -scale.x;

        dir = 1;
	}
	
	// Update is called once per frame
	void Update () {
        
        float x = Input.GetAxisRaw("Horizontal");

        if (x == 0)
        {
            GetComponent<Animator>().SetBool("Run", false);
        }
        else
        {

            GetComponent<Animator>().SetBool("Run", true);
            transform.Translate(Vector2.right * x * speed);
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
}
