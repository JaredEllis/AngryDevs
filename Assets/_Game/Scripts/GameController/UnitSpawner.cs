using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public Dev Spawn(Dev devPrefab, Transform location)
    {
        Dev newDev = Instantiate(devPrefab, location.position, location.rotation);
        return newDev;
    }
}
