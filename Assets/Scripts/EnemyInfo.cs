using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{

    public float baseHealth = 100f;
    float currHealth;


    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = baseHealth;    
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0f){
            isAlive = false;
        }
    }


    // handles the unit taking damage
    // returns true if the unit is still alive after taking damage
    // returns false if it dies from taking damage
    public bool takeDamage(float damage){
        if (isAlive){
            currHealth -= damage;
            print (currHealth);

            if (currHealth <= 0f){
                isAlive = false;
                Destroy(gameObject);
                return false;
            }
            return true;
        }
        return false;

    }

}
