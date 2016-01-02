using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameWorldController world;

	// Use this for initialization
	void Start () {

		world.CreateWorld();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
