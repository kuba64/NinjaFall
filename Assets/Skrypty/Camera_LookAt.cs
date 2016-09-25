using UnityEngine;
using System.Collections;

public class Camera_LookAt : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float x = GameObject.FindObjectOfType<Player>().transform.position.x;
		Vector3 end = new Vector3(x, 0, -10);
		transform.position = Vector3.Lerp (transform.position, end, speed);


	}
}
