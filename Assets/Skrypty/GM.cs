using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GM : MonoBehaviour {
	public int punkty, money, ap, aup, pp, all_money, gorki;
	public Transform start_pos, spawn_hill, spawn_start, spawn_coins;
	public GameObject[] ninja, coins;
	public GameObject hill;
	public float max_y, min_y, odleglosc, end_time, barLevel;
	public string[] perfectNapisy;

	public Text UI_point, UI_money, UI_perfect_text,  UI_timer_end;



	public GameObject UI_start, UI_end, UI_extra_moc, UI_Gameplay, UI_info, UI_end_cont, UI_sklep, UI_coinsShop;
	public Text UI_hight, UI_point_end, UI_TheBest, UI_ContEarn, UI_ContJumps, UI_ContSuma, UI_perk_money, UI_sklep_money;

	public Animator UI_Option, UI_perk;



	public static GM instance = null;   


	bool off, off1, off2;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
		Spawn_Player (PlayerPrefs.GetInt ("wybrany_ninja"));
	
		// pierwsza góra
		Spawn_Hill (0);
		//kolejne góry
		Spawn_Hill (1);

		Spawn_Coins (0);
		Spawn_Coins (1);


		all_money = PlayerPrefs.GetInt ("Money", 100000);
		if (PlayerPrefs.GetInt ("SklepStart") == 1) {
			UI_sklep.SetActive (true);
			PlayerPrefs.SetInt ("SklepStart", 0);
		}
		else
		    UI_start.SetActive (true);

		Debug.Log ("End");
	}
	
	// Update is called once per frame
	void Update () {
		//punkty
		UI_point.text = punkty.ToString ();
		//monety

		UI_money.text = "+" + money.ToString ();
	
		UI_ContSuma.text = all_money.ToString ();
		UI_ContEarn.text =  money.ToString ();
		UI_perk_money.text =  all_money.ToString ();
		UI_sklep_money.text =  all_money.ToString ();

		//the best sccore
		if (punkty > PlayerPrefs.GetInt ("hightscore"))
			UI_TheBest.text = punkty.ToString ();
		else
	    	UI_TheBest.text = PlayerPrefs.GetInt ("hightscore").ToString();

		UI_ContJumps.text = punkty.ToString ();



		//bar
		UI_extra_moc.GetComponent<Animator> ().SetFloat ("Bar_level", barLevel);


		if (FindObjectOfType<Camera> ().GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Live")) {
			FindObjectOfType<Camera> ().GetComponent<Animator> ().enabled = false;

		}

	}

	public void Spawn_Player(int a){
		Instantiate (ninja [a], start_pos.position, Quaternion.identity);



	}


	public void Spawn_Hill(int i){
		float y = Random.Range (min_y, max_y);
		Vector3 pos = new Vector3 (spawn_hill.position.x + i * odleglosc/2, y, 0);

		Instantiate (hill, pos, Quaternion.identity);
	}


	public void Dead(){
		FindObjectOfType<Camera> ().GetComponent<Animator> ().Play ("Dead");
		FindObjectOfType<Camera> ().GetComponent<Animator> ().enabled = true;



			UI_Gameplay.SetActive (false);
			UI_end_cont.SetActive (true);


		//money
		all_money += money;
		PlayerPrefs.SetInt("Money", all_money);

		if(punkty > PlayerPrefs.GetInt ("hightscore"))
		    PlayerPrefs.SetInt ("hightscore", punkty);
		UI_hight.text = PlayerPrefs.GetInt ("hightscore").ToString();
		UI_point_end.text = punkty.ToString ();
	}


	public void Jump_Button(){
		GameObject.FindObjectOfType<Player> ().Jump ();
		GameObject.FindObjectOfType<Player> ().rb.isKinematic = false;

		UI_info.SetActive (false);
	}

	public void Fly_Button(){
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().Fly ();
	}



	public void Restart(){

		Application.LoadLevel (Application.loadedLevel);
	}

	public void Perfect_Text(){
		if(punkty <29)
		    UI_perfect_text.text = perfectNapisy[punkty-1];
		else
			UI_perfect_text.text = perfectNapisy[28];
		
			
		UI_perfect_text.GetComponent<Animator> ().Play ("Text_fade");

	}


	public void Extra_Moc(){
		if (barLevel >= 8 && barLevel < 11) {
			
			switch (ap) {
			case 1:
				FindObjectOfType<Player>().Teleport();
				break;
			case 2:
				FindObjectOfType<Player>().DoubleJump();
				break;
			case 3:
				FindObjectOfType<Player>().PowerFly();
				break;
			}

			barLevel = 0;
		}

		if (barLevel == 20) {
			Debug.Log ("UP");
			barLevel = 0;
		}
		
		
	}

	public void Spawn_Coins(int i){
		Vector3 pos = new Vector3 (spawn_coins.position.x + i * odleglosc/2, spawn_coins.position.y, spawn_coins.position.z);
		
		Instantiate (coins[Random.Range(0, coins.Length)], pos, Quaternion.identity);
	}


	public void Play(){

		UI_Gameplay.SetActive (true);
		UI_start.SetActive (false);

	}

	public void Continue(){
		FindObjectOfType<Camera> ().GetComponent<Animator> ().SetTrigger ("Live");


		barLevel = 0;
		UI_extra_moc.GetComponent<Animator> ().Play ("Start");

		UI_Gameplay.SetActive (true);

		UI_info.SetActive (true);

		GameObject.FindObjectOfType<Player> ().anim.Play ("Ninja lot");

		end_time = 5;
		GameObject.FindObjectOfType<Player> ().transform.position = new Vector3 (
			GameObject.FindObjectOfType<Player> ().transform.position.x, 
			4.19f,
			GameObject.FindObjectOfType<Player> ().transform.position.z
		);
		UI_end_cont.SetActive (false);

	}

	public void Buy(int i){
		if(all_money >= i){
			PlayerPrefs.SetInt ("Money", all_money - i);

			Continue();
		}
			
	}

	public void Exit_UI_cont()	{
		UI_end.SetActive (true);
		UI_end_cont.SetActive (false);
	}

	public void AP(int i){
		switch (i) {
		case 1:
			if (all_money >= 500) {
				all_money -= 500;
				PlayerPrefs.SetInt ("Money", all_money);
				ap = 1;
			}
			break;

		case 2:
			if (all_money >= 1000) {
				all_money -= 1000;
				PlayerPrefs.SetInt ("Money", all_money);
				ap = 2;
			}
			break;

		case 3:
			if (all_money >= 1500) {
				all_money -= 1500;
				PlayerPrefs.SetInt ("Money", all_money);

				ap = 3;
			}
			break;
		}
	}

	public void PP(int i){
		switch (i) {
		case 1:
			if (all_money >= 500) {
				all_money -= 500;
				PlayerPrefs.SetInt ("Money", all_money);
				pp = 1;
			}
			break;

		case 2:
			if (all_money >= 1000) {
				all_money -= 1000;
				PlayerPrefs.SetInt ("Money", all_money);
				pp = 2;
			}
			break;

		case 3:
			if (all_money >= 1500) {
				all_money -= 1500;
				PlayerPrefs.SetInt ("Money", all_money);

				pp = 3;
			}
			break;
		}
	}



	//UI

	public void Option()
	{
		if (off) {
			UI_Option.SetBool ("Off", true);
			UI_Option.SetBool ("On", false);
			off = false;
		} else {
			UI_Option.SetBool ("Off", false);
			UI_Option.SetBool ("On", true);
			off = true;
		}
		
	}

	public void Perk()
	{
		if (off1) {
			UI_perk.SetBool ("Off", true);
			UI_perk.SetBool ("On", false);
			off1 = false;
		} else {
			UI_perk.SetBool ("Off", false);
			UI_perk.SetBool ("On", true);
			off1 = true;
		}
	}

	public void Sklep(){
		UI_sklep.SetActive (true);
		UI_start.SetActive (false);
	}

	public void Sklep_onEnd(){
		PlayerPrefs.SetInt ("SklepStart", 1);
		Application.LoadLevel (Application.loadedLevel);
	}

	public void CoinsShop(){
		if (off2) {
			UI_coinsShop.SetActive (false);
			off2 = false;
		} else {
			UI_coinsShop.SetActive (true);
			off2 = true;
		}
	}



}
