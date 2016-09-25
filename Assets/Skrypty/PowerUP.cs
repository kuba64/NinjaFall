using UnityEngine;
using System.Collections;

public class PowerUP : MonoBehaviour {

	private int _active_perk, _active_ultra_perk, _passive_perk;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int Active_perk{
		get{
			return _active_perk;
		}

		set {
			_active_perk = value;
		}

	}



	public int Active_ultra_perk{
		get{
			return _active_ultra_perk;
		}

		set {
			_active_ultra_perk = value;
		}

	}


	public int Passive_perk{
		get{
			return _passive_perk;
		}

		set {
			_passive_perk = value;
		}
	}

	// active perk
	public void AP(int i){
		switch(i)
		{
		case 0:
			Debug.Log ("Brak");
			break;
		case 1:
			Debug.Log ("AP 1");
			break;
		case 2:
			Debug.Log ("AP 2");
			break;
		case 3:
			Debug.Log ("AP 3");
			break;

		}
	}


	// active ultra perk
	public void AUP(int i){
		switch(i)
		{
		case 0:
			Debug.Log ("Brak");
			break;
		case 1:
			Debug.Log ("AUP 1");
			break;
		case 2:
			Debug.Log ("AUP 2");
			break;
		case 3:
			Debug.Log ("AUP 3");
			break;

		}
	}

	// pacive perk
	public void PP(int i){
		switch(i)
		{


		case 0:
			Debug.Log ("Brak");
			break;

		//dodatkowe zycie
		case 1:
			Debug.Log ("PP 1");
			break;
		case 2:
			Debug.Log ("PP 2");
			break;
		case 3:
			Debug.Log ("PP 3");
			break;

		}
	}
}
