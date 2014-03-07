using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {

    public Transform target;
    public Vector3 Velocity;
    public Vector3 Acceleration;
    public int MaxV = 5;
    public int MaxA = 5;
    bool Stopping;

    public GameObject playerPrefab;
    private GameManager gm;

    void Start() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update() {
        camera.enabled = !gm.dispMenu;
        if(!gm.dispMenu) {
            if(target == null) {
                target = ((GameObject)Instantiate(playerPrefab, gm.SpawnPoint.position, Quaternion.identity)).transform;
            }
        }
    }

    void FixedUpdate() {
        Stopping = true;
        if(target != null) {
            Approach(transform.position, target.position + new Vector3(0, 0, -10));
        }
    }

    void OnGUI() {
        int width = Screen.width, height = Screen.height;

        if(gm.dispMenu) {
            gm.dispMenu = !GUI.Button(new Rect(width / 2 - 40, height / 2 - 20, 80, 40), "Start");
        }
    }

    void Approach(Vector3 current, Vector3 destination) {
        float dist;
        if((dist = Vector3.Distance(current, destination)) > 4) {
            Stopping = false;
            Vector3 temp = destination - current;
            Acceleration = Acceleration + Vector3.ClampMagnitude(temp, 1);
            Acceleration = Vector3.ClampMagnitude(Acceleration, MaxA);

            Velocity += Velocity + Acceleration;
            Velocity = Vector3.ClampMagnitude(Velocity, MaxV);
        } else {
            Velocity = destination - current;
            Acceleration = Vector3.zero;
        }

        transform.position += Velocity;
        if(Stopping) {
            Velocity = Vector3.zero;
        }
    }
}