using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesMakingTla : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 50.0f;
    private int amnTilesOnScreen = 7;
    private float safeZone = 30.0f;

    private List<GameObject> activeTiles;
    // Use this for initialization
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    private void SpawnTile()
    {
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ = spawnZ + tileLength;
        activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
