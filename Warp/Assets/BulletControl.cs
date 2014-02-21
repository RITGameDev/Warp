using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {
    [Range(0.5f, 100f)]
    public float BulletSpeed = 0.5f;

    void FixedUpdate() {
        transform.Translate(new Vector3(BulletSpeed, 0, 0) * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D data) {
        Destroy(this.gameObject);
    }
}