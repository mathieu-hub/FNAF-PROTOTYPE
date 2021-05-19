using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsPoints : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> positions = new List<GameObject>();
    void Start()
    {
        Transform[] allchildren = GetComponentsInChildren<Transform>();

        List<GameObject> childObjects = new List<GameObject>();

        foreach (Transform child in allchildren)
        {
            childObjects.Add(child.gameObject);
        }

        positions = childObjects;

        Debug.Log(gameObject.name + childObjects.Count);
        Debug.Log(gameObject.name + childObjects[0]);
    }
}
