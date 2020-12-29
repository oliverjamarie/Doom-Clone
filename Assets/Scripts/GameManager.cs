using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Transform> SpawnPoints;
    public List<GameObject> EnemyTypes;
    public int numEnemiesToSpawn;

    public GameObject player;

    List<GameObject> characters;

    // Start is called before the first frame update
    void Start()
    {
        characters = new List<GameObject>();

        for (int i = 0; i < numEnemiesToSpawn; i ++){
            int randSpawn = (int) (Random.value * 100) % SpawnPoints.Capacity;
            int randEnemy = (int) (Random.value * 100) % EnemyTypes.Capacity;



            GameObject enemy = EnemyTypes[randEnemy];
            
            enemy.GetComponent<EnemyMovement>().playerObject = player;
            

            Instantiate(enemy,SpawnPoints[randSpawn]);
            

            characters.Add(enemy);
        }
        

    }

    // Update is called once per frame
    void Update()
    {/* 
        List<GameObject> toRemove = new List<GameObject>();

        foreach (GameObject obj in characters)
        {
            EnemyInfo enemy = obj.GetComponent<EnemyInfo>();
            
            
            if (enemy.isAlive == false){

                print("Enemy is Dead");

                Destroy(obj);
                toRemove.Add(obj);
            }
        }

        foreach (GameObject obj in toRemove)
        {
            characters.Remove(obj);
        } */
    }
}
