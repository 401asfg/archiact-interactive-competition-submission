using UnityEngine;
using System.Collections;

public class Hack : Shootable
{

	public override void Hit (Vector3 direction)
	{
		Debug.Log ("Hacked!");
	}
}