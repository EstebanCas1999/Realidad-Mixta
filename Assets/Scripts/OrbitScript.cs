using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    public Transform sun;

    public enum Planet { Mercurio, Venus, Tierra, Marte, Júpiter, Saturno, Urano, Neptuno }
    public Planet planet;

    private float[] distances = new float[] { 0.35f, 0.7f, 1.05f, 1.4f, 1.75f, 2.1f, 2.45f, 2.8f };

    private float[] speeds = new float[] { 172000f, 126000f, 107000f, 86600f, 47100f, 34900f, 24500f, 19500f };

    private float scale = 0.00038f; 

    private float orbitalDistance;
    private float orbitalSpeed;

    private void Start()    
    {
        orbitalDistance = distances[(int)planet];
        orbitalSpeed = speeds[(int)planet] * scale;

        transform.position = new Vector3(orbitalDistance, 0, 0);
    }

    private void Update()
    {
        
        transform.RotateAround(sun.position, Vector3.up, orbitalSpeed * Time.deltaTime);

        Vector3 direction = (transform.position - sun.position).normalized;
        transform.position = sun.position + direction * orbitalDistance;

        transform.Rotate(Vector3.up, 20f * Time.deltaTime);
    }


}
