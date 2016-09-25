using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {
	public Animator animator;
	private Text pointText;


	// Use this for initialization
	void OnEnable() {
		AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo (0);
		Destroy (gameObject, clipInfo [0].clip.length);
		pointText = animator.GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	public void SetText(string text, Color color){
		pointText.color = color;
		pointText.text = text ;

	}
}
