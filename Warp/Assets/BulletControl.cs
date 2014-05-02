using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour
{
		[Range(0.5f, 100f)]
		public float
				BulletSpeed = 0.5f;

		void FixedUpdate ()
		{
				transform.Translate (new Vector3 (BulletSpeed, 0, 0) * Time.deltaTime);
		}

		void OnCollisionEnter2D (Collision2D data)
		{
				Destroy (this.gameObject);
				if (data.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
						Transform portal = GameObject.Find ("GameManager").GetComponent<GameManager> ().Portal;
						Instantiate (portal, data.contacts [0].point + data.contacts [0].normal.normalized * portal.GetComponent<BoxCollider2D> ().size.x / 2, Quaternion.identity);
				}
		}
}