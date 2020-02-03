using UnityEngine;
using System.Collections;

public class Enemy : Shootable
{

	public bool gotoPlayer = false;
	public float killRange = 1f;
	private NavMeshAgent agent;
	// Use this for initialization
	void Start ()
	{
		agent = GetComponent <NavMeshAgent> ();
		EnemyManager.instance.AddEnemy (this);
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (gotoPlayer == false) {
			Vector3 destination0 = Destination.initialDestinaion [Random.Range (0, Destination.initialDestinaion.Length)].transform.position;
			this.SetDestination (destination0);
			Vector3 distance0 = destination0 - transform.position;

			if (distance0.sqrMagnitude <= 1) {
				gotoPlayer = true;
			}
		}

		if (gotoPlayer == true) {
			Vector3 destination1 = EnemyManager.instance.player.transform.position;
			this.SetDestination (destination1);
			Vector3 distance1 = destination1 - transform.position;
			
			if (distance1.sqrMagnitude < killRange * killRange) {
				Time.timeScale = 0;
				Debug.Log ("Game Over!");
				Application.LoadLevel (Application.loadedLevel);
			}
		}

	}
	
	public void SetDestination (Vector3 destination)
	{
		agent.SetDestination (destination);
	}

	public float hitForce = 500f;
	public override void Hit (Vector3 direction)
	{
		Debug.Log (EnemyManager.instance.kills);
		EnemyManager.instance.RemoveEnemy (this);
		Destroy (gameObject);
		EnemyManager.instance.kills += 1;
	}
	
}
