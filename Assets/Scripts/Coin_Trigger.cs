using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball")
        {
            print("Score");
            Manager.instance.Coin_Get();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
