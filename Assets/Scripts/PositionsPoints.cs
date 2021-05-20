using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsPoints : MonoBehaviour
{
    public List<GameObject> childPositions = new List<GameObject>();

    void Start()
    {
        Transform[] allchildren = GetComponentsInChildren<Transform>();

        List<GameObject> childObjects = new List<GameObject>();

        foreach (Transform child in allchildren)
        {
            childObjects.Add(child.gameObject);
        }

        childPositions = childObjects;
    }
}
