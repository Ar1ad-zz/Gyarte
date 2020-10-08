using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Transform spawnCenter;
    public GameObject test;
    public GameObject[] spawnPoints = new GameObject[35];
    
    float waitTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnCenter = GameObject.Find("SpawnPoint").GetComponent<Transform>();

        for (int i = 0; i < 35; i++)
        {
            spawnPoints[i] = new GameObject();
            spawnPoints[i].transform.position = new Vector2(spawnCenter.position.x + i, spawnCenter.position.y);
            spawnPoints[i].transform.SetParent(spawnCenter.parent);
            Debug.Log("Created Spawnpoint: " + i);  
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTimer == 0)
        {
            int chosen = Random.Range(0, 35);
            Instantiate(test, spawnPoints[chosen].transform.position, Quaternion.identity);
            waitTimer = 100f;
            Debug.Log("Boop");
        }

        waitTimer--;
        
    }
}
