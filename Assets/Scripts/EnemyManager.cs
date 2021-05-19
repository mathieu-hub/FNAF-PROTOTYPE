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
    [Range(2f,10f)] public float freddyMoveSpeed;

    [Header("CHICCA")]
    public GameObject chicca;
    public Transform chiccaActualPosition;
    public Transform chiccaTargetPosition;
    [Range(2f, 10f)] public float chiccaMoveSpeed;

    [Header("BONNIE")]
    public GameObject bonnie;
    public Transform bonnieActualPosition;
    public Transform bonnieTargetPosition;
    [Range(2f, 10f)] public float bonnieMoveSpeed;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
