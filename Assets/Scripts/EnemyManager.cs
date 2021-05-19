using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [Header("FREDDY")]
    public GameObject freddy;
    public Transform freddyActualPosition;
    public Transform freddyTargetPosition;
    [Space(5)]
    public GameObject fPositions;
    //public Transform[] freddyPositionlist = new Transform[];
    [Range(2f,10f)] public float freddyMoveSpeed;

    [Header("CHICCA")]
    public GameObject chicca;
    public Transform chiccaActualPosition;
    public Transform chiccaTargetPosition;
    [Space(5)]
    public GameObject cPositions;
    public List<Transform> chiccaPositionlist = new List<Transform>();
    [Range(2f, 10f)] public float chiccaMoveSpeed;

    [Header("BONNIE")]
    public GameObject bonnie;
    public Transform bonnieActualPosition;
    public Transform bonnieTargetPosition;
    [Space(5)]
    public GameObject bPositions;
    public List<Transform> bonniePositionlist = new List<Transform>();
    [Range(2f, 10f)] public float bonnieMoveSpeed;


    void Start()
    {
        //-freddyPositionlist = fPositions.GetComponent<PositionsPoints>().points[transform.childCount];
    }

    void Initialisation()
    {
        
    }

    void Update()
    {
        
    }
}
