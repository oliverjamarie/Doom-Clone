using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter(Collider collision){
        print("Enemy: trigger");
    }

    void OnTriggerStay(Collider other){
        print("bruh, social distancing");
    }

}
