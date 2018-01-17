using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour {

	private SpriteMask mask;
	public string dialogue;
	// Use this for initialization
	void Start () {	
		mask = this.GetComponentInChildren<SpriteMask>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if( collision.gameObject.CompareTag("Player"))
		{
			mask.GetComponent<SpriteMask>().frontSortingOrder = 20;
			this.GetComponent<SpriteRenderer>().enabled = false;
			this.GetComponent<BoxCollider2D>().enabled = false;
			
			collision.gameObject.GetComponent<PlayerController>().setDialogue(dialogue);
		}
	}
}
