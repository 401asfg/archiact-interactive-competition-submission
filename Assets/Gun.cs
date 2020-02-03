using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gun : MonoBehaviour
{

	void Start ()
	{
		ammo = 25f;
		if (ammoLabel != null) {
			ammoLabel.text = "Ammo: " + ammo.ToString ();
		}
	}

	MagnetClicker clicker = new MagnetClicker ();
	public float shootTime = 0.5f;
	public float shootTimeLeft = 0;
	public bool shoot = true;
	public static float ammo = 100f;
	public Text ammoLabel;
	public GameObject hitEffect;

	void Update ()
	{
		
		if (shoot == false) {
			shootTimeLeft -= Time.deltaTime;
		}

		if (shootTimeLeft <= 0) {
			shoot = true;
			shootTimeLeft = shootTime;
		}

		Screen.lockCursor = true;
		clicker.magUpdate (Input.acceleration, Input.compass.rawVector);
		if (clicker.clicked () || Input.GetMouseButtonDown (0)) {
			if (shoot == true && ammo > 0) {
				ammo -= 1;
				if (ammoLabel != null) {
					ammoLabel.text = "Ammo: " + ammo.ToString ();
				}
				Ray ray = new Ray (transform.position, transform.forward);
				Debug.DrawRay (transform.position, transform.forward * 100, Color.red);
				RaycastHit hitInfo;
				if (Physics.Raycast (ray, out hitInfo)) {
					Debug.Log (hitInfo.collider.gameObject.name);
					Shootable hit = hitInfo.collider.GetComponent <Shootable> ();
					if (hit != null) {
						hit.Hit (transform.forward);
					}
					Instantiate (hitEffect, hitInfo.point, Quaternion.LookRotation (hitInfo.normal));
				}

				shoot = false;
			}
		}
	}
}
