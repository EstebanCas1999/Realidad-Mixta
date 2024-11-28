using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class NumberContainer : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        Destroy(gameObject, 10);
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }*/
}
