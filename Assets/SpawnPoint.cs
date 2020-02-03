using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{
	
	void Start ()
	{
		EnemyManager.instance.AddSpawnPoint (this);
	}
}
