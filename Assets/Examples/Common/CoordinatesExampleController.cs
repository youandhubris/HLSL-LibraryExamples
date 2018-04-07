using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Synecdoche;

public class CoordinatesExampleController : MonoBehaviour
{
    [Header("Polar / Cylindrical")]
    public Polar.BasePlane basePlane;
    [Range(-10f, 10f)]
    public float pRadius;
    [Range(0, Numero.TWO_PI)]
    public float pAzimuth;
    [Range(-5f, 5f)]
    public float pHeight = 0f;

    private Polar polarCoord;
    private Transform polarCylindrical;

    [Header("Spherical")]
    [Range(-10f, 10f)]
    public float sRadius;
    [Range(0, Numero.TWO_PI)]
    public float sAzimuth;
    [Range(-Numero.HALF_PI, Numero.HALF_PI)]
    public float sPolar = 0f;

    public Spherical sphericalCoord;
    private Transform spherical;

    void Start ()
    {
        polarCoord = new Polar();
        polarCylindrical = gameObject.GetComponentsInChildren<Transform>()[0];

        sphericalCoord = new Spherical();
        spherical = gameObject.GetComponentsInChildren<Transform>()[1];
    }

    void Update ()
    {
        polarCoord.Set(pRadius, pAzimuth, pHeight, basePlane);
        polarCylindrical.position = polarCoord;

        sphericalCoord.Set(sRadius, sAzimuth, sPolar);
        spherical.position = sphericalCoord;
    }
}