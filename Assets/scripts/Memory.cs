using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour {

	public GameObject targetDungeonMask;
	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if( collision.gameObject.CompareTag("Player"))
		{
			targetDungeonMask.GetComponent<SpriteMask>().frontSortingOrder = 20;
			this.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
