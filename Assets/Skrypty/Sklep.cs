using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sklep : MonoBehaviour {

	public int[] ceny;
	int wybrany;

	public GameObject playText, cena ;
	public Text cenaText;


	public int[] kupione;
	// Use this for initialization
	void Start () {
		kupione = new int[ceny.Length];
		wybrany = PlayerPrefs.GetInt ("wybrany_ninja");

		for (int i = 0; i < ceny.Length; i++) {
			kupione [i] = PlayerPrefs.GetInt ("Ninja" + i.ToString ());
		}

		kupione [0] = PlayerPrefs.GetInt ("Ninja0", 1);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (kupione [wybrany] == 1) {
			playText.SetActive (true);
			cena.SetActive (false);
			
		} else {
			playText.SetActive (false);
			cena.SetActive (true);
			cenaText.text = ceny [wybrany].ToString();
		}
	
	}

	public void Buy(){
		if (kupione [wybrany] == 1) {
			GM.instance.UI_Gameplay.SetActive (true);
			GM.instance.UI_sklep.SetActive (false);
			PlayerPrefs.SetInt ("wybrany_ninja", wybrany);
		} else if (GM.instance.all_money >= ceny [wybrany]) {
			GM.instance.all_money -= ceny [wybrany];
			kupione [wybrany] = 1;
			PlayerPrefs.SetInt ("Ninja" + wybrany.ToString (), 1);
			PlayerPrefs.SetInt ("Money", GM.instance.all_money);
				
		}
	}

	public void Next(){
		if (wybrany < ceny.Length-1) {
			wybrany++;
			Destroy (FindObjectOfType<Player> ().gameObject);
			GM.instance.Spawn_Player(wybrany);
		}
	}

	public void Back(){
		if (wybrany > 0) {
			wybrany--;
			Destroy (FindObjectOfType<Player> ().gameObject);
			GM.instance.Spawn_Player (wybrany);
		}
	}

	public void BackToMenu(){
		GM.instance.UI_sklep.SetActive (false);
		GM.instance.UI_start.SetActive (true);

		if (kupione [wybrany] == 0) {
			Destroy (FindObjectOfType<Player> ().gameObject);
			GM.instance.Spawn_Player (PlayerPrefs.GetInt ("wybrany_ninja"));
		}
			
	}

}
