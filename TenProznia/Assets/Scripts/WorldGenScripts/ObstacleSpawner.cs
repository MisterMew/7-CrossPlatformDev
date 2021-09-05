using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    public GameObject obstaclePrefab;
    public Transform[] spawnPoints;

     /// START
    /* Start function */
    private void Start() {
        SpawnObstacles();
    }

     /// SPAWN OBSTACLES
    /* Spawn obstacles at the spawn points */
    void SpawnObstacles() {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++) {
            if (randomIndex != i) {
                Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.identity); //Quaternian.identity to ignore rotations
            }
        }
    }
}
