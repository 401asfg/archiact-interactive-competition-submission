using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Looker : MonoBehaviour
{
	public Color seenColor;
	public Color unseenColor;
	public PuzzleMaster puzzlemaster;
	List <Cube> goodCube = new List <Cube> ();
	// Use this for initialization
	void Start ()
	{
		foreach (Cube c in GetComponentsInChildren<Cube>()) {
			if (c.isGood) {
				goodCube.Add (c);
			}
		}
		HitBad ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo)) {
			Cube hit = hitInfo.collider.GetComponent <Cube> ();
			if (hit != null) {

				if (hit.isGood) {
					HitGood (hit);
				} else {
					HitBad ();
				}

			}
		}
	}
	void HitGood (Cube hit)
	{
		if (!hit.isSeen) {
			hit.isSeen = true;
			hit.GetComponent<Renderer>().material.color = seenColor;
			foreach (Cube c in goodCube) {
				if (!c.isSeen) {
					return;
				}
			}
			SeenAll ();
		}

	}
	void HitBad ()
	{
		foreach (Cube c in goodCube) {
			c.isSeen = false;
			c.GetComponent<Renderer>().material.color = unseenColor;
		}
	}
	void SeenAll ()
	{
		Debug.Log ("Completed");
		puzzlemaster.ActivateNext ();
	}
}
	