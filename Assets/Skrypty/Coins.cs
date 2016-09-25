using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

	public string Wartosc;
	public Color color;
	bool inside;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(inside)
			transform.position = Vector3.Lerp (transform.position, FindObjectOfType<Player>().transform.position, 0.1f);
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			if (GM.instance.pp == 2) {
				FloatintTextControler.CreateFloatingText (Wartosc + " x2", color, other.transform);
				GM.instance.money++;
			} else {
				FloatintTextControler.CreateFloatingText (Wartosc, color, other.transform);
				GM.instance.money++;
			}
			Destroy (gameObject);
		}

		//magnetyzm
		if (other.tag == "Magnetyzm"|| GM.instance.pp == 3) {
			inside = true;
		}

	}
}
