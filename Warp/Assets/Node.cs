using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Node : MonoBehaviour {
	
	public Terrain terrain;

	public int type = 0;
	// Use this for initialization
	void Start () 
	{
		Vector3 loc = gameObject.transform.position;
		//loc.y = terrain.SampleHeight(loc) + 1;
		gameObject.transform.position = loc;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 loc = gameObject.transform.position;
		//loc.y = terrain.SampleHeight(loc) + 1;
		gameObject.transform.position = loc;
	}
}
