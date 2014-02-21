using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {
    public Transform target;

    void FixedUpdate() {
        transform.position = target.position + new Vector3(0, 0, -10);
    }
}