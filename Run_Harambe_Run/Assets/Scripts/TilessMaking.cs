using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilessMaking : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 19.82f;
    private int amnTilesOnScreen = 7;
    private float safeZone = 15.0f;
    private int prejsna = 0;
    private int prefab = 1;

    private List<GameObject> activeTiles;
    // Use this for initialization
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile(1);
            DeleteTile();
        }
    }
    private void SpawnTile(int index)
    {
        GameObject go;
        int tileNum = tilePrefabs.Length;
        if(index == 0)
            go = Instantiate(tilePrefabs[0]) as GameObject;
        else
        {     
            while(prefab == prejsna)
            {
                prefab = Random.Range(1, tileNum);
            }
            prejsna = prefab;
            go = Instantiate(tilePrefabs[prefab]) as GameObject;
        }
        go.transform.SetParent(transform);
        //go.transform.position = Vector3.forward * spawnZ;
        go.transform.Translate(0, 0, spawnZ);
        spawnZ = spawnZ + tileLength;
        activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
