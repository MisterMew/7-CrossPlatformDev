using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    public GameObject[] obstaclePrefabs;
    public Transform[] spawnPoints;

       /// START
      /// <summary>
     /// Start
    /// </summary>
    private void Start() {
        SpawnObstacles();
    }

       /// SPAWN OBSTACLES
      /// <summary>
     /// Spawn a random obstacle at each spawn point
    /// </summary>
    void SpawnObstacles() {
        for (int i = 0; i < spawnPoints.Length; i++) {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomIndex], spawnPoints[i].position, Quaternion.identity); //Quaternian.identity to ignore rotations
        }
    }
}
