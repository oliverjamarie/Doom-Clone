using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void onTriggerEnter(Collider collision){
        print("Enemy: collider");
    }
}
