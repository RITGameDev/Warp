using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {
    
	public Transform target;
	public Vector3 Velocity;
	public Vector3 Acceleration;
	public int MaxV = 5;
	public int MaxA = 5;
	bool Stopping;

    void FixedUpdate() {
		Stopping = true;
		Approach(transform.position,target.position + new Vector3(0, 0, -10));
    }

	void Approach(Vector3 current, Vector3 destination)
	{
		float dist;
		if((dist=Vector3.Distance(current,destination)) > 4)
		{
			Stopping = false;
			Vector3 temp = destination - current;
			Acceleration = Acceleration + Vector3.ClampMagnitude(temp,1);
			Acceleration = Vector3.ClampMagnitude(Acceleration,MaxA);

			Velocity += Velocity + Acceleration;
			Velocity = Vector3.ClampMagnitude(Velocity,MaxV);
		}
		else
		{
			Velocity = destination-current;
			Acceleration = Vector3.zero;
		}
				
		transform.position += Velocity;
		if(Stopping)
		{
			Velocity = Vector3.zero;
		}
	}
}