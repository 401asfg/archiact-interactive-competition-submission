using UnityEngine;
using System.Collections;

public class PushBack : Shootable
{

	public float hitForce = 500f;
	public override void Hit (Vector3 direction)
	{
		GetComponent<Rigidbody>().AddForce (direction * hitForce);
		Debug.Log ("Hit");
	}

}
