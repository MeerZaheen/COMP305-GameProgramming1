using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterColor : MonoBehaviour {
	public Sprite Sprite;
	public GameObject character;
	private SpriteRenderer sRend;
	// Use this for initialization
	private void Start () {
		 sRend = character.GetComponent<SpriteRenderer>();
	}

	 void OnMouseDown()
	{
		sRend.sprite = Sprite;
	}
}
