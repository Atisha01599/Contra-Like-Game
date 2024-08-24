using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPowerTrigger : MonoBehaviour
{
    private Transform flyingPower;
    // Start is called before the first frame update
    void Start()
    {
        flyingPower = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            if(flyingPower != null){
                flyingPower.gameObject.SetActive(true);
            }
        }
    }
}