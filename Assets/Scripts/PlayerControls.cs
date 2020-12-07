using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Animator animator;
    bool unskippableAnimationPlaying;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        unskippableAnimationPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        

    }


}
