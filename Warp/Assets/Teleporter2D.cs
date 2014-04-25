using UnityEngine;
using System.Collections.Generic;
using System;

public class Teleporter2D : MonoBehaviour
{

		public event Action OnTeleport;

		public int timer;
		public bool timing;
		public Node targ;
		//int timer= 0;
		// Use this for initialization
		void Start ()
		{
				timing = false;
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				//if(true)//other.gameObject.tag == "Player")
				//{
				timer = 5;
				timing = true;
				//}
		}

		void  OnTriggerStay2D (Collider2D other)
		{
				if (timing) {
						if (timer == 0) {
								timer = 5;
								other.gameObject.transform.position = targ.transform.position;

								if (OnTeleport != null) {
										OnTeleport ();
								}
						} else
								timer--;
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				//if(timer<0)
				/*float rot = gameObject.GetComponent<MouseLook>().rotChar;
			if(rot<0)
			{
				rot*=-1;
			}
			if(rot < 5.0)
				timer = 0;	
			Vector3 targetDir = targ.R.Center.gameObject.transform.position - transform.position;
			targetDir.y = 0;
			targetDir.z = 0;
			Vector3 forward = transform.forward;
			forward.y = 0;
			forward.z = 0;
			gameObject.GetComponent<MouseLook>().rotChar = Vector3.Angle(targetDir, forward);		
		}
		else
		{
			//gameObject.GetComponent<MouseLook>().rotChar = 0;*/
				//}
		}
}
