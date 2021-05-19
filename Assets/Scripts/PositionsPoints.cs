using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsPoints : MonoBehaviour
{
    public List<Transform>[] points;

    private void Awake()
    {
        points = new List<Transform>[transform.childCount];
    }
}
