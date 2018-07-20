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
	void Update () {
        float v = Input.GetAxis("Vertical") * freeRange;
        Vector3 targetPosition = new Vector3((playerTransform.position + range).x, (playerTransform.position + range).y + v * freeRange, (playerTransform.position + range).z);
        transform.position = Vector3.Lerp(transform.position,targetPosition, Time.deltaTime * smooth);
        
	}
}
