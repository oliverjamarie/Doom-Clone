using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    Collider collide;
    // Start is called before the first frame update
    void Start()
    {
        collide = GetComponent<Collider>();
        Debug.Log(collide.isTrigger);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("triggered");
    }
}
