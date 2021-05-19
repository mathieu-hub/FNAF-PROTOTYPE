using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    public GameObject Freddy;
    public GameObject Bonnie;
    public GameObject Chica;

    public float moveSpeed;
    public Transform actualposition;
    public Transform targetPosition;
    public int positionIndex;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
