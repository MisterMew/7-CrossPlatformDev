using UnityEngine;
using System.Collections.Generic;

public class ChunkManager : MonoBehaviour {
    /// Variables
    public GameObject[] chunkPrefabs;
    private Transform playerTransform;

    private float spawnZ = 64F;
    private float chunkLength = 64F;
    private int chunksOnScreen = 8;
    private float safeZone = 50F;
    private int previousPrefabIndex = 0;

    private List<GameObject> activeChunks;

    void Start() {
        activeChunks = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < chunksOnScreen; i++) {    // i = 0. As long as "i" is less than "ChunksOnScreen", chunks will be spawned.
            if (i < 2)
                SpawnChunk(0);
            else
                SpawnChunk();

        }
    }

    void Update() {
        if (playerTransform.position.z - safeZone > (spawnZ - chunksOnScreen * chunkLength)) {    // If player position (- safeZone) is more than the formula, generates ground chunks> 
            SpawnChunk();
            DeleteChunk();
        }
    }

     /// SPAWN CHUNKS
    /* Spawns in prefabs consistently */
    void SpawnChunk(int prefabIndex = -1) {  // If prefabIndex isn't defined, = -1
        GameObject gObj;
        if (prefabIndex == -1)
            gObj = Instantiate(chunkPrefabs[RandomPrefabIndex()]) as GameObject;
        else
            gObj = Instantiate(chunkPrefabs[prefabIndex]) as GameObject;
        gObj.transform.SetParent(transform);
        gObj.transform.position = Vector3.forward * spawnZ;
        spawnZ += chunkLength;
        activeChunks.Add(gObj);

    }

    // Deletes oldest existing chunks
    private void DeleteChunk() {
        Destroy(activeChunks[0]);
        activeChunks.RemoveAt(0);
    }

    // Decides which prefabs are generated
    private int RandomPrefabIndex() {
        if (chunkPrefabs.Length <= 1)
            return 0;

        int randomIndex = previousPrefabIndex;                      // If prefab chosen is the = to the previous prefab,
        while (randomIndex == previousPrefabIndex) {                 // It loops again until a different prefab is selcted
            randomIndex = Random.Range(0, chunkPrefabs.Length);      // So, generation loops until randomIndex != previousPrefabIndex
        }

        previousPrefabIndex = randomIndex;      // When that happens, the randomly selected index is set to the previous prefabs index, and randomIndex is empty. 
        return randomIndex;
    }
}
