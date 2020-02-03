using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuzzleMaster : MonoBehaviour
{
	List <Looker> puzzles = new List <Looker> (); 
	int currentPuzzleLevel = 0;
	// Use this for initialization
	void Awake ()
	{
		foreach (Looker l in GetComponentsInChildren<Looker>()) {
			puzzles.Add (l);
			l.gameObject.SetActive (false);
			l.puzzlemaster = this;
		}
		puzzles [currentPuzzleLevel].gameObject.SetActive (true);
	}
	public void ActivateNext ()
	{
		puzzles [currentPuzzleLevel].gameObject.SetActive (false);
		currentPuzzleLevel ++;
		if (currentPuzzleLevel < puzzles.Count) {
			puzzles [currentPuzzleLevel].gameObject.SetActive (true);
			Gun.ammo += 25;
		} else {
			Debug.Log ("Game Won");
			Application.LoadLevel (Application.loadedLevel);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
