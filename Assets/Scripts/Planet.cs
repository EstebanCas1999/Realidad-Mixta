using HoloToolkit.MRDL.PeriodicTable;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Planet : MonoBehaviour
{
    // Start is called before the first frame update
    public static Planet ActivePlanet;
    public static String PlanetName;

    public Transform center;
    public Transform target;

    public float radius;
    public float radiusSpeed;
    public float rotationSpeed;
    public GameObject detailData;

    private Vector3 axis;
    private Vector3 desiredPosition;

    public TextMeshProUGUI planetDescription;

    public void SetActivePlanet(String text)
    {
        Planet planet = gameObject.GetComponent<Planet>();
        ActivePlanet = planet;
        PlanetName = target.name;
        planetDescription.text = text;
    }

    public void ResetActivePlanet()
    {
        ActivePlanet = null;
        PlanetName = null;
        detailData.SetActive(false);
    }
    void Start()
    {
        
        
        transform.position = (transform.position - center.position).normalized * radius + center.position;
        axis = Vector3.up;

        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (PlanetName != target.name)
        {
            transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime); 
            desiredPosition = (target.transform.position - center.position).normalized * radius + center.position;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
            detailData.SetActive(false);
        } else
        {
            transform.rotation = Quaternion.Euler(0, -33.954f, 0);
            detailData.SetActive(true);
        }

    }


}
