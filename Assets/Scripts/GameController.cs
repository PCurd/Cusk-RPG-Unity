using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameWorldController world;

	// Use this for initialization
	void Start () {

        string text = null;
		try {
			text = System.IO.File.ReadAllText("map");
		}
		catch (System.IO.FileNotFoundException ex)
		{
            Debug.LogException(ex);
		}
        
       
        world.CreateWorld(text);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
