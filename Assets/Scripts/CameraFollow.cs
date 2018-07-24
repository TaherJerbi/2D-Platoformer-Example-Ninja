using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    Transform playerTransform;

    Vector3 range;

    public float smooth;

    public float freeRange;
	// Use this for initialization
	void Start () {
        range = transform.position - playerTransform.position;
        
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float v = Input.GetAxis("Vertical") * freeRange;
        float targetX = playerTransform.position.x + range.x * playerTransform.gameObject.GetComponent<PlayerMotor>().dir;
        Vector3 targetPosition = new Vector3(targetX, (playerTransform.position + range).y + v * freeRange, (playerTransform.position + range).z);
        transform.position = Vector3.Lerp(transform.position,targetPosition, Time.deltaTime * smooth);
        
	}
}
