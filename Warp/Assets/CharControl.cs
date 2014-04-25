﻿using UnityEngine;
using System.Collections;

public class CharControl : MonoBehaviour
{

		[Range(0.1f, 30f)]
		public float
				CharSpeed = 1f;

		[Range(1f, 20f)]
		public float
				JumpForce = 1f;

		public Transform GroundCheck;
		public float GroundRadius = 0.2f;
		private bool grounded = false;
		public LayerMask WhatIsGround;

		public GameObject Bullet;
		public Transform BulletSpawn;

		[Range(0.1f, 10f)]
		public float
				ShootCooldownLength = 4f;
		private float ShootCooldown = 0f;

		// Use this for initialization
		void Start ()
		{

		}

		void FixedUpdate ()
		{
				grounded = Physics2D.OverlapCircle (GroundCheck.position, GroundRadius, WhatIsGround);

				if (grounded) {
						rigidbody2D.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * CharSpeed, 0));
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (grounded && Input.GetButtonDown ("Jump")) {
						rigidbody2D.AddForce (new Vector2 (0, 100 * JumpForce));
				}

				if (ShootCooldown == 0f && Input.GetButtonDown ("Fire")) {
						Instantiate (Bullet, BulletSpawn.position, Quaternion.identity);
						ShootCooldown = ShootCooldownLength;
				}

				if (ShootCooldown > 0f) {
						ShootCooldown = Mathf.Max (0f, ShootCooldown - Time.deltaTime);
				}
		
				if (Input.GetButtonDown ("Special")) {
						TeleportForward (1);
				}
		}
	
		void TeleportForward (float distance)
		{
				Transform teleportNode = (Transform)GameObject.Instantiate (GameObject.Find ("GameManager").GetComponent<GameManager> ().TeleportNodePairPrefab, transform.position, Quaternion.identity);
				teleportNode.GetComponentInChildren<Node> ().transform.position = new Vector3 (distance, 0, 0);
				teleportNode.GetComponentInChildren<Teleporter2D> ().OnTeleport += () => Destroy (teleportNode.gameObject, 0.5f);
		}
}
