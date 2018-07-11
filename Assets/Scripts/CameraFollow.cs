using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    Transform playerTransform;

    Vector3 range;

    public float smooth;
	// Use this for initialization
	void Start () {
        range = transform.position - playerTransform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position,new Vector3((playerTransform.position + range).x,transform.position.y, (playerTransform.position + range).z), Time.deltaTime * smooth);
        
	}
}
