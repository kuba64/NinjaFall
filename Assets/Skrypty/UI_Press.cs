using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UI_Press: MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
		UserIsInPress = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		UserIsInPress = false;
	}

	public bool UserIsInPress ;

	void Update () {
		
	}
}
