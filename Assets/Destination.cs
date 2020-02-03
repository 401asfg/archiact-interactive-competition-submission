using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour
{

	public static Transform[] initialDestinaion;

	public void Awake ()
	{
		initialDestinaion = GetComponentsInChildren <Transform> ();
	}

}