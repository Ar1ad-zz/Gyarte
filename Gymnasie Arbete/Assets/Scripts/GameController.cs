
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] Tetrimos = new GameObject[3];

    public Transform spawnCenter;
    public GameObject test;
    public GameObject[] spawnPoints = new GameObject[35];
    
    float waitTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Tetrimos = Resources.LoadAll<GameObject>("Prefabs");

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
            int chosenTetri = Random.Range(0, 2);
            Instantiate(Tetrimos[chosenTetri], spawnPoints[chosen].transform.position, Quaternion.identity);
            waitTimer = 500f;
            Debug.Log("Boop");
        }

        waitTimer--;
        
    }
}
