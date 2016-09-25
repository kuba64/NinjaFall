using UnityEngine;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class ScrollingScript : MonoBehaviour
{

	public float slow_x, slow_y, speed, left;
	public bool dead;

	Player pl;
	void Start(){
		pl = GameObject.FindObjectOfType<Player> ();
			
	}

	void Update()
	{

		float x = pl.transform.position.x;


		Vector3 end = new Vector3(-x/slow_x + left, transform.position.y, 10);
		transform.position = Vector3.Lerp (transform.position, end, speed);

		if (transform.localPosition.x < -11)
			left += 15.7f * 2;
		

	
	}


		
}