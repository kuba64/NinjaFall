using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour {
	public Animator anim;
	public Rigidbody2D rb;

	public bool onground, fall;
	public float wyskokoscSkoku = 4.19f;
	public float predkosc = 10f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		FloatintTextControler.Initialize ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (onground)
			anim.SetBool ("Ziemia", true);
		else
			anim.SetBool ("Ziemia", false);

		if (rb.velocity.y < -0.1) {
			fall = true;
			rb.gravityScale = 0.8f;
		} else {
			rb.gravityScale = 2;
			fall = false;
		}


		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Ninja wyskok")){
			transform.position = new Vector3 (transform.position.x, wyskokoscSkoku, transform.position.z);
			anim.SetBool ("Skok", false);
			onground = false;
		}

		Fly ();
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "OnGround")
			onground = true;
		else if (other.name == "DeadZone") {
			Dead ();

		}

		if (other.tag == "Point") {
			GM.instance.Perfect_Text ();
			GM.instance.barLevel++;



		}

		if (other.tag == "Respawn") {
			Destroy (other.gameObject);

			GM.instance.punkty++;
			GM.instance.gorki++;
			GM.instance.Spawn_Hill (GM.instance.gorki+1);
			GM.instance.Spawn_Coins (GM.instance.gorki+1);


		}

	
	}

	public void Jump(){
		if (onground) {
			anim.SetBool ("Skok", true);
		}
	}

	public void Fly(){
		if (fall && EventSystem.current.currentSelectedGameObject.GetComponent<UI_Press> ().UserIsInPress) {
			anim.SetBool ("Lot", true);
			transform.position += Vector3.right * predkosc * Time.deltaTime;
		}
		else
			anim.SetBool ("Lot", false);
		
		
	}

	public void Teleport(){
		GM.instance.punkty += 10;
		anim.Play ("Ninja teleport");
	}

	public void DoubleJump(){
	}

	public void PowerFly(){
		anim.Play ("Ninja teleport PF");
	}

	void Dead(){
		GM.instance.Dead();	
		rb.isKinematic = true;
	}
}
