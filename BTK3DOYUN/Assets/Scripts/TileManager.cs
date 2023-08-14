using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 4;
    public Transform playerTransform;
    List<GameObject> activeTile = new List<GameObject>();  
    void Start()
    {
       for(int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z -35> zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex],transform.forward*zSpawn,transform.rotation);
        activeTile.Add(go);
        zSpawn += tileLength;
    }
    public void DeleteTile()
    {
        Destroy(activeTile[0]);
        activeTile.RemoveAt(0);
    }
}
