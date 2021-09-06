using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    public GameObject[] obstaclePrefabs;
    public Transform[] spawnPoints;

     /// START
    /* Start function */
    private void Start() {
        SpawnObstacles();
    }

     /// SPAWN OBSTACLES
    /* Spawn obstacles at the spawn points */
    void SpawnObstacles() {
        for (int i = 0; i < spawnPoints.Length; i++) {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomIndex], spawnPoints[i].position, Quaternion.identity); //Quaternian.identity to ignore rotations
        }
    }
}
