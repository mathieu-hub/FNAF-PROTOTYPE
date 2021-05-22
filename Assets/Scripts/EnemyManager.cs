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
    private int fMinInclusive = 10;
    private int fMaxExclusive = 25;

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
    private int cMinInclusive = 10;
    private int cMaxExclusive = 25;

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
    private int bMinInclusive = 10;
    private int bMaxExclusive = 25;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        freddyPositionlist = fPositions.GetComponent<PositionsPoints>().childPositions;
        chiccaPositionlist = cPositions.GetComponent<PositionsPoints>().childPositions;
        bonniePositionlist = bPositions.GetComponent<PositionsPoints>().childPositions;

        Initialisation();
    }

    public void Initialisation()
    {
        freddyCanMove = false;
        bonnieCanMove = false;
        chiccaCanMove = false;

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

        int moveTime = Random.Range(bMinInclusive, bMaxExclusive);
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

                    bMinInclusive = 8;
                    bMaxExclusive = 12;
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

                    bMinInclusive = 8;
                    bMaxExclusive = 12;
                }
                else if (randomChoice == 5)
                {
                    bonnieIndexMove = 6;
                }
            }
            else if (bonnieIndexMove == 7) //Si Bonnie est à DANGER LEFT.
            {               
                if (leftDoor.doorIsOpen == false) 
                {
                    if (randomChoice == 1)
                    {
                        bonnieIndexMove = 8;

                        bMinInclusive = 10;
                        bMaxExclusive = 25;
                    }
                    else if (randomChoice == 2)
                    {
                        bonnieIndexMove = 6;

                        bMinInclusive = 10;
                        bMaxExclusive = 25;
                    }
                    else if (randomChoice == 3)
                    {
                        bonnieIndexMove = 5;

                        bMinInclusive = 10;
                        bMaxExclusive = 25;
                    }
                    else if (randomChoice == 4)
                    {
                        bonnieIndexMove = 4;

                        bMinInclusive = 10;
                        bMaxExclusive = 25;
                    }
                    else if (randomChoice == 5)
                    {
                        bonnieIndexMove = 2;

                        bMinInclusive = 10;
                        bMaxExclusive = 25;
                    }
                }
                else if (leftDoor.doorIsOpen)
                {
                    bonnieIndexMove = 9;
                    GameManager.Instance.GameOver();
                }
            }
        }
    }

    void ChiccaMovePattern()
    {
        chicca.transform.position = chiccaPositionlist[chiccaIndexMove].transform.position;

        if (chiccaIndexMove == 1) //Si Chicca est au Start.
        {
            chiccaIndexMove = 2;
        }

        //Variable permettant de définir sur une plage random, le moment du prochain déplacement.
        chiccaLastMove += Time.deltaTime;

        int moveTime = Random.Range(cMinInclusive, cMaxExclusive);
        Debug.Log("Chicca MoveTime " + moveTime);

        //Patterns de déplacements de Chicca.
        if (chiccaLastMove >= moveTime)
        {
            chiccaLastMove = 0;

            int randomChoice = Random.Range(1, 6);
            Debug.Log(randomChoice);

            if (chiccaIndexMove == 2) //Si Chicca est dans la Salle Principale.
            {
                if (randomChoice <= 3)
                {
                    chiccaIndexMove = 4;
                }
                else if (randomChoice > 3)
                {
                    chiccaIndexMove = 3;
                }
            }
            else if (chiccaIndexMove == 3) //Si Chicca est dans l'Annexe.
            {
                chiccaIndexMove = 2;
            }
            else if (chiccaIndexMove == 4) //Si Chicca est dans le Couloir 01.
            {
                if (randomChoice == 1)
                {
                    chiccaIndexMove = 2;
                }
                else if (1 < randomChoice && randomChoice < 4)
                {
                    chiccaIndexMove = 5;
                }
                else if (randomChoice > 3)
                {
                    chiccaIndexMove = 6;
                }
            }
            else if (chiccaIndexMove == 5) //Si Chicca est dans la Remise.
            {
                chiccaIndexMove = 4;
            }
            else if (chiccaIndexMove == 6) //Si Chicca est dans le Couloir 02.
            {
                if (randomChoice == 1)
                {
                    chiccaIndexMove = 4;
                }
                else if (1 < randomChoice && randomChoice < 4)
                {
                    chiccaIndexMove = 7;

                    cMinInclusive = 8;
                    cMaxExclusive = 12;
                }
                else if (randomChoice > 3)
                {
                    chiccaIndexMove = 8;
                }
            }
            else if (chiccaIndexMove == 8) //Si Chicca est dans le Couloir 03.
            {
                if (randomChoice <= 4)
                {
                    chiccaIndexMove = 7;

                    cMinInclusive = 8;
                    cMaxExclusive = 12;
                }
                else if (randomChoice == 5)
                {
                    chiccaIndexMove = 6;
                }
            }
            else if (chiccaIndexMove == 7) //Si Chicca est à DANGER LEFT.
            {
                if (rightDoor.doorIsOpen == false)
                {
                    if (randomChoice == 1)
                    {
                        chiccaIndexMove = 8;

                        cMinInclusive = 10;
                        cMaxExclusive = 25;
                    }
                    else if (randomChoice == 2)
                    {
                        chiccaIndexMove = 6;

                        cMinInclusive = 10;
                        cMaxExclusive = 25;
                    }
                    else if (randomChoice == 3)
                    {
                        chiccaIndexMove = 5;

                        cMinInclusive = 10;
                        cMaxExclusive = 25;
                    }
                    else if (randomChoice == 4)
                    {
                        chiccaIndexMove = 4;

                        cMinInclusive = 10;
                        cMaxExclusive = 25;
                    }
                    else if (randomChoice == 5)
                    {
                        chiccaIndexMove = 2;

                        cMinInclusive = 10;
                        cMaxExclusive = 25;
                    }
                }
                else if (rightDoor.doorIsOpen)
                {
                    chiccaIndexMove = 9;
                    GameManager.Instance.GameOver();
                }
            }
        }
    }

    void FreddyMovePattern()
    {
        freddy.transform.position = freddyPositionlist[freddyIndexMove].transform.position;

        if (freddyIndexMove == 1) //Si Freddy est au Start.
        {
            freddyIndexMove = 2;
        }

        //Variable permettant de définir sur une plage random, le moment du prochain déplacement.
        freddyLastMove += Time.deltaTime;

        int moveTime = Random.Range(fMinInclusive, fMaxExclusive);
        Debug.Log("Freddy MoveTime " + moveTime);

        //Patterns de déplacements de Freddy.
        if (freddyLastMove >= moveTime)
        {
            freddyLastMove = 0;

            int randomChoice = Random.Range(1, 6);
            Debug.Log(randomChoice);

            if (freddyIndexMove == 2) //Si Freddy est dans la Salle Principale.
            {
                freddyIndexMove = 3;
            }
            else if (freddyIndexMove == 3) //Si Freddy est dans le Couloir 01.
            {
                freddyIndexMove = 4;
            }
            else if (freddyIndexMove == 4) //Si Freddy est dans le Couloir 03.
            {
                if (randomChoice <= 3)
                {
                    freddyIndexMove = 5;

                    fMinInclusive = 8;
                    fMaxExclusive = 12;
                }
                else if (randomChoice > 3)
                {
                    freddyIndexMove = 2;
                }
            }
            else if (freddyIndexMove == 5)
            {
                if (leftDoor.doorIsOpen == false)
                {
                    freddyIndexMove = 2;

                    fMinInclusive = 10;
                    fMaxExclusive = 25;
                }
                else if (leftDoor.doorIsOpen)
                {
                    freddyIndexMove = 6;
                    GameManager.Instance.GameOver();
                }
            }
        }
    }
}
