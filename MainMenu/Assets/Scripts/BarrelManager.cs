using UnityEngine;
using System.Collections;

public class BarrelManager : MonoBehaviour {

    //public PlayerHealth playerHealth;
    public GameObject barrel;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}


    // Update is called once per frame
    void Spawn()
    {
        // should be added when playerhealth is added to the program.
//        if (playerHealth.currentHealth <= 0f)
//        {
//            return;
//        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(barrel, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
