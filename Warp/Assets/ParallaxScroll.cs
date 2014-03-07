using UnityEngine;
using System.Collections;

public class ParallaxScroll : MonoBehaviour {

    public float speed = 0;
    public Camera target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = target.transform.position * speed;
        renderer.material.mainTextureOffset = new Vector2(pos.x, pos.y);
	}
}
