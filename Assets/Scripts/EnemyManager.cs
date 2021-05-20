using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    public DoorController leftDoor;
    public DoorController rightDoor;

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

        if (bonnieIndexMove == 1) //Si Bonnie est au Start.
        {
            bonnieIndexMove = 2;
        }

        //Variable permettant de définir sur une plage random, le moment du prochain déplacement.
        bonnieLastMove += Time.deltaTime;

        int moveTime = Random.Range(10, 25);
        Debug.Log("Bonnie MoveTime " + moveTime);

        //Patterns de déplacements de Bonnie.
        if (bonnieLastMove >= moveTime)
        {
            bonnieLastMove = 0;

            int randomChoice = Random.Range(1, 6);
            Debug.Log(randomChoice);

            if (bonnieIndexMove == 2) //Si Bonnie est dans la Salle Principale.
            {               
                if (randomChoice <= 3)
                {
                    bonnieIndexMove = 4;
                }
                else if (randomChoice > 3)
                {
                    bonnieIndexMove = 3;
                }
            }
            else if (bonnieIndexMove == 3) //Si Bonnie est dans l'Annexe.
            {
                bonnieIndexMove = 2;
            }
            else if (bonnieIndexMove == 4) //Si Bonnie est dans le Couloir 01.
            {
                if (randomChoice == 1)
                {
                    bonnieIndexMove = 2;
                }
                else if (1 < randomChoice && randomChoice < 4)
                {
                    bonnieIndexMove = 5;
                }
                else if (randomChoice > 3)
                {
                    bonnieIndexMove = 6;
                }
            }
            else if (bonnieIndexMove == 5) //Si Bonnie est dans la Remise.
            {
                bonnieIndexMove = 4;
            }
            else if (bonnieIndexMove == 6) //Si Bonnie est dans le Couloir 02.
            {
                if (randomChoice == 1)
                {
                    bonnieIndexMove = 4;
                }
                else if (1 < randomChoice && randomChoice < 4)
                {
                    bonnieIndexMove = 7;
                }
                else if (randomChoice > 3)
                {
                    bonnieIndexMove = 8;
                }
            }
            else if (bonnieIndexMove == 8) //Si Bonnie est dans le Couloir 03.
            {
                if (randomChoice <= 4)
                {
                    bonnieIndexMove = 7;
                }
                else if (randomChoice == 5)
                {
                    bonnieIndexMove = 6;
                }
            }
            else if (bonnieIndexMove == 7) //Si Bonnie est à DANGER LEFT.
            {
                if (leftDoor.doorIsOpen == false) //erreur ici
                {
                    if (randomChoice == 1)
                    {
                        bonnieIndexMove = 8;
                    }
                    else if (randomChoice == 2)
                    {
                        bonnieIndexMove = 6;
                    }
                    else if (randomChoice == 3)
                    {
                        bonnieIndexMove = 5;
                    }
                    else if (randomChoice == 4)
                    {
                        bonnieIndexMove = 4;
                    }
                    else if (randomChoice == 5)
                    {
                        bonnieIndexMove = 2;
                    }
                }
                else if (leftDoor.doorIsOpen)
                {
                    bonnieIndexMove = 9;
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
