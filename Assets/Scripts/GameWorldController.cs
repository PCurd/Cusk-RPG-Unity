using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class GameWorldController : MonoBehaviour
{
    public Vector2 Size = new Vector2(10,10);
    public int[] FloorLayout;

    //Should only create a small part
    //**TODO: Incremental feeds of map contents (and updates) should be supported, this all assumes 0,0 references
    public void CreateWorld(string text)
    {
        var decodedInts = DecodeTextToInt(text);

        int SizeX, SizeY;

        //Grab the first two values which should be the map size
        SizeX = decodedInts[0];
        SizeY = decodedInts[1];
        decodedInts.RemoveRange(0, 2);

        if (decodedInts.Count != SizeX*SizeY)
        {
            Debug.LogFormat("ERROR: Map sizes do not match. X:{0}, Y:{1}, Map Size:{2}", SizeX, SizeY, decodedInts.Count);
            return;
        }

        Size.x = SizeX;
        Size.y = SizeY;

        FloorLayout = decodedInts.ToArray();


        //Once map is loaded into FloorLayout, continue
        CreateWorld();
    }

    private List<int> DecodeTextToInt(string text)
    {
        string[] extractedText;
        
        try
        {
            extractedText = text.Split(',');
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return new List<int>();
        }

        List<int> outputLayout = new List<int>(extractedText.Length);

        for (int i = 0; i < extractedText.Length; i++)
        {
            try
            {
                outputLayout.Add(int.Parse(extractedText[i]));
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                outputLayout[i] = 0;
            }
           
        }

        return outputLayout;

    }

    public void RandomiseFloorLayout()
    {
        GameObject[] Ground = Resources.LoadAll<GameObject>("Prefabs/ground");
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                FloorLayout[(int)((Size.y - y - 1) * (Size.x)) + x] = Random.Range(0, Ground.Length);
            }
        }
    }

    //Should only create a small part
    //**TODO: Incremental feeds of map contents (and updates) should be supported, this all assumes 0,0 references
    void CreateWorld()
    {

        GameObject[] GroundArray = Resources.LoadAll<GameObject>("Prefabs/ground");

        var Ground = GroundArray.OrderBy(go => go.name).ToList<GameObject>(); //Just to ensure the order is right
        
        if (Ground.Count == 0)
        {
            Debug.LogError("No Ground prefabs were found in Prefabs/ground.");
            return;
        }
        if (Debug.isDebugBuild)
            Debug.LogFormat("{0} Ground tiles found.",Ground.Count);

        for (int y = (int)Size.y-1; y >= 0; y--)
        {
            for (int x = 0; x < Size.x; x++)
            {
                GameObject tile = null;
                int pos = (int)((Size.y - y - 1) * (Size.x)) + x;//(int)(y * Size.x + x);
                if (pos >= FloorLayout.Length || pos < 0 || FloorLayout.Length==0)
                {
                    tile = Ground[0]; // Black space
                }
                else
                {
                    if (FloorLayout[pos] > Ground.Count || FloorLayout[pos] < 0 || Ground.Count == 0)
                    {
                        tile = Ground[0]; // Black space
                    }
                    else
                    {
                        tile = Ground[FloorLayout[pos]];
                    }
                }

                var newtile = Instantiate(tile, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                newtile.transform.SetParent(this.transform, true);

            }
        }
        
            
    }
}
