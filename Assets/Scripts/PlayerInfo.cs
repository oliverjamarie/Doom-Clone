using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    public float health = 100f;

    public Transform targetFd, 
                    targetBk,
                    targetL,
                    targetR,
                    targetCurr;

    // Start is called before the first frame update
    void Start()
    {
        targetCurr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        targetCurr = transform;
    }

    public Transform getTargetFd(){
        return targetFd;
    }

    public Transform getTargetBk(){
        return targetBk;
    }

    public Transform getTargetR(){
        return targetR;
    }

    public Transform getTargetL(){
        return targetL;
    }

    public Transform getTargetCurr(){
        return targetCurr;
    }
}
