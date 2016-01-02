using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;

public class GameWorldController : MonoBehaviour
{
    public Vector2 Size = new Vector2(10,10);
    public int[] FloorLayout;

    public void RandomiseFloorLayout()
    {
        GameObject[] Ground = Resources.LoadAll<GameObject>("Prefabs/ground");
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                FloorLayout[(int)(y * Size.x + x)] = Random.Range(0, Ground.Length);
            }
        }
    }

   public void CreateWorld()
    {

        GameObject[] Ground = Resources.LoadAll<GameObject>("Prefabs/ground");

        if (Ground.Length == 0)
        {
            Debug.LogError("No Ground prefabs were found in Prefabs/ground.");
            return;
        }
        if (Debug.isDebugBuild)
            Debug.LogFormat("{0} Ground tiles found.",Ground.Length);

        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                GameObject tile = null;
                int pos = (int)(y * Size.x + x);
                if (pos > FloorLayout.Length || pos < 0)
                {
                    tile = Ground[0]; // Black space
                }
                else
                {
                    tile = Ground[FloorLayout[pos]]; 
                }
                

                Instantiate(tile, new Vector3(x, y, 0f), Quaternion.identity);
            }
        }
        
            
    }
}
