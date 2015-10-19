using UnityEngine;
using System.Collections;

public class BarrelManager : MonoBehaviour {

    //public PlayerHealth playerHealth;
    public GameObject barrel;
    public float spawnTime;
    public Transform[] spawnPoints;

    private float Timer;
    
	void Start () {
 
    }

    void Update()
    {
        if (Timer < Time.time)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(barrel, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            Timer = Time.time + Random.Range(2, 5);
        }
        var barrels = GameObject.FindGameObjectsWithTag("Barrel");
        foreach (var barrel in barrels)
            Physics2D.IgnoreCollision(barrel.GetComponent<CircleCollider2D>(), barrel.GetComponent<CircleCollider2D>());
    }

}