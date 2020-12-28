using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public Camera camera;
    public LayerMask layerMask;
    public GameObject gun; 
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Transform camTransform = camera.transform;

            GunInfo gunInfo = gun.GetComponent<GunInfo>();

            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition +( Random.insideUnitSphere * gunInfo.accuracy));

            if(Physics.Raycast(ray, out hit)){
                EnemyInfo enemy = hit.transform.GetComponent<EnemyInfo>();

                if (enemy != null ){
                    enemy.takeDamage(gunInfo.damage);
                }
            }
        }

    }


}
