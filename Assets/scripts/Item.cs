using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	public string name;

	public string Name
	{
		get { return name; }
		set { name = value; }
	}

	public int Id
	{
		get { return id; }
		set { id = value; }
	}

	public Texture2D Texture
	{
		get { return texture; }
		set { texture = value; }
	}

	public string Type
	{
		get { return type; }
		set { type = value; }
	}

	private int id;
	private Texture2D texture;
	private string type;

	public Item(int id, string name, string type, string texture){
		this.name = name;
		this.id = id;
		this.type = type;
		this.texture = Resources.Load(texture) as Texture2D;
	}
	public Item(int id, string name, string type){
		this.name = name;
		this.id = id;
		this.type = type;
	}
}
