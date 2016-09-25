using UnityEngine;
using System.Collections;

public class Hill : MonoBehaviour {
	public float time = 5f , shake_time, delta, down_speed;
	bool time_start, koniec;



	Vector3 originalPos;
	// Use this for initialization
	void Start () {
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 end = new Vector3 (originalPos.x + delta, originalPos.y, originalPos.z);


		//animcja down
		if (koniec) {
			Vector3 down = new Vector3 (transform.position.x, -15f, transform.position.z);
			originalPos= Vector3.Lerp (transform.position, down, down_speed);
		}


		if (time_start) 
			time -= Time.deltaTime;


		// czas w zaleznosci od punktów
		switch (GM.instance.punkty) {
		case 0:
			time = 5;
			break;
		case 10:
			time = 4;
			break;
		case 20:
			time = 3;
			break;
		case 30:
			time = 2;
			break;
		case 40:
			time = 1;
			break;

		}
		


		//shake
		if(time <= shake_time){
			if (end != transform.position)
				transform.position = end;

			else
				delta = -delta;
		}


		//down
		if(time <= 0){
			koniec = true;

			//Destroy(gameObject);

		}
	
	}


		

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("Player");
			time_start = true;

		}
	}




}
