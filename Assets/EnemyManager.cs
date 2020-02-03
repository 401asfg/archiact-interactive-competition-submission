using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
	
	public GameObject player;
	public float kills = 0f;
	public Enemy enemyToSpawn;
	public float spawnTime = 2f;
	private float spawnTimeLeft = 0;
	private List<SpawnPoint> spawnPoints = new List<SpawnPoint> ();
	
	private List <Enemy> enemies = new List<Enemy> ();
	
	public static EnemyManager instance;
	
	void Awake ()
	{
		instance = this;
	}
	
	void Update ()
	{
		foreach (Enemy e in enemies) {
			e.SetDestination (player.transform.position);
		}
		
		spawnTimeLeft -= Time.deltaTime;
		if (spawnTimeLeft <= 0) {
			Spawn ();
			spawnTimeLeft = spawnTime;
		}
	}
	
	private void Spawn ()
	{
		if (spawnPoints.Count > 0) {
			SpawnPoint spawnPoint = spawnPoints [Random.Range (0, spawnPoints.Count)];
			Instantiate (enemyToSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation);
		}
	}
	
	public void AddEnemy (Enemy enemy)
	{
		enemies.Add (enemy);
	}
	
	public void RemoveEnemy (Enemy enemy)
	{
		enemies.Remove (enemy);
	}
	
	public void AddSpawnPoint (SpawnPoint spawnPoint)
	{
		spawnPoints.Add (spawnPoint);
	}
	
	public void RemoveSpawnPoint (SpawnPoint spawnPoint)
	{
		spawnPoints.Remove (spawnPoint);
	}
}