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
    public bool freddyCanMove = false;
    public float freddyLastMove;
    public int freddyIndexMove;
    [Range(2f,10f)] public float freddyMoveSpeed;
    public List<GameObject> freddyPositionlist = new List<GameObject>();

    [Header("CHICCA")]
    public GameObject chicca;
    public Transform chiccaActualPosition;
    public Transform chiccaTargetPosition;
    [Space(5)]
    public GameObject cPositions;
    public bool chiccaCanMove = false;
    public float chiccaLastMove;
    public int chiccaIndexMove;
    [Range(2f, 10f)] public float chiccaMoveSpeed;
    public List<GameObject> chiccaPositionlist = new List<GameObject>();

    [Header("BONNIE")]
    public GameObject bonnie;
    public Transform bonnieActualPosition;
    public Transform bonnieTargetPosition;
    [Space(5)]
    public GameObject bPositions;
    public bool bonnieCanMove = false;
    public float bonnieLastMove;
    public int bonnieIndexMove;
    [Range(2f, 10f)] public float bonnieMoveSpeed;
    public List<GameObject> bonniePositionlist = new List<GameObject>();


    void Start()
    {
        freddyPositionlist = fPositions.GetComponent<PositionsPoints>().childPositions;
        chiccaPositionlist = cPositions.GetComponent<PositionsPoints>().childPositions;
        bonniePositionlist = bPositions.GetComponent<PositionsPoints>().childPositions;

        Initialisation();
    }

    void Initialisation()
    {
        freddyIndexMove = 1;
        chiccaIndexMove = 1;
        bonnieIndexMove = 1;

        freddy.transform.position = freddyPositionlist[freddyIndexMove].transform.position;
        chicca.transform.position = chiccaPositionlist[chiccaIndexMove].transform.position;
        bonnie.transform.position = bonniePositionlist[bonnieIndexMove].transform.position;
    }

    void Update()
    {
        if (bonnieCanMove)
        {
            BonnieMovePattern();
        }

        if (chiccaCanMove)
        {
            ChiccaMovePattern();
        }

        if (freddyCanMove)
        {
            FreddyMovePattern();
        }
    }

    void BonnieMovePattern()
    {
        bonnie.transform.position = bonniePositionlist[bonnieIndexMove].transform.position;

        bonnieLastMove += Time.deltaTime;

        int moveTime = Random.Range(10, 25);
        Debug.Log("Bonnie MoveTime " + moveTime);

        if (bonnieLastMove == moveTime)
        {
            bonnieLastMove = 0;

            if (bonnieIndexMove == 2)
            {
                int randomChoice = Random.Range(1, 5);

                if (randomChoice <= 3)
                {
                    // HERE !!!!
                }
            }
        }
    }

    void ChiccaMovePattern()
    {
        chicca.transform.position = chiccaPositionlist[chiccaIndexMove].transform.position;
        
        chiccaLastMove += Time.deltaTime;

        int moveTime = Random.Range(10, 25);
        Debug.Log("Chicca MoveTime " + moveTime);

        if (chiccaLastMove == moveTime)
        {
            chiccaLastMove = 0;
        }
    }

    void FreddyMovePattern()
    {
        freddy.transform.position = freddyPositionlist[freddyIndexMove].transform.position;

        freddyLastMove += Time.deltaTime;

        int moveTime = Random.Range(10, 25);
        Debug.Log("Freddy MoveTime " + moveTime);

        if (freddyLastMove == moveTime)
        {
            freddyLastMove = 0;
        }
    }
}
