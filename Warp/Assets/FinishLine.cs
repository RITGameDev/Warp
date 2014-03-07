using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {
    private GameManager gm;

    void Start() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "Player") {
            Destroy(coll.gameObject);

            gm.dispMenu = true;
            // Perform other End-of-game fanfare here.
        }
    }
}