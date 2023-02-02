using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LvlCreator : MonoBehaviour
{
    public GameObject[] grasGround = new GameObject[2];
    public GameObject[] stoneGround = new GameObject[2];
    public GameObject[] clayGround = new GameObject[2];

    public GameObject myWallSocket;
    public GameObject myRoofSocket;
    public GameObject stone;
    public GameObject stone1;
    public GameObject tree;
    public GameObject tree1;
    public int treeChance = 8;


    private int sizeX = 10;
    private int sizeY = 10;
    private int rand;
    private float stoneDirection;
    private float treeDirection;
    private int sizeMap = 20;


    void Start()
    {
        CreateMap();
    }


    void CreateMap()
    {
        int x = 0;
        int y = 0;
        for (int i = 0; i < sizeMap; i += 10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, i);
            for (int j = 0; j < sizeMap; j += 10)
            {
                transform.position = new Vector3(j, transform.position.y, transform.position.z);

                rand = Random.Range(0, 10);
                if (rand <= 2)
                {
                    CreateStoneTerrain();
                }
                else if (rand >= 3 && rand < 9)
                {
                    CreateForestTerrain();
                }
                else if (rand == 9)
                {
                    CreateClayField();
                }
                x = x + 10;
            }
        }
        CreateWallSockets();
        CreateRoofSockets();
    }

    public void CreateStoneTerrain()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                rand = Random.Range(0, 2); //changed range from 3 to 2
                Instantiate(stoneGround[rand], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                rand = Random.Range(0, 5);
                if (rand < 1)
                {
                    stoneDirection = Random.Range(0f, 180f);
                    rand = Random.Range(0, 3);
                    if (rand < 2)
                    {
                        Instantiate(stone, new Vector3(transform.position.x + i, transform.position.y + 0.5f, transform.position.z + j), (Quaternion.Euler(0f, stoneDirection, 0f)));
                    }
                    else
                    {
                        Instantiate(stone1, new Vector3(transform.position.x + i, transform.position.y + 0.5f, transform.position.z + j), (Quaternion.Euler(0f, stoneDirection, 0f)));
                    }
                }
            }
        }
    }


    public void CreateForestTerrain()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                rand = Random.Range(0, 2);
                Instantiate(grasGround[rand], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                rand = Random.Range(0, treeChance);
                if (rand < 1)
                {
                    rand = Random.Range(0, 3);
                    if (rand < 2)
                    {
                        Instantiate(tree, new Vector3(transform.position.x + i, transform.position.y + 1.5f, transform.position.z + j), Quaternion.identity);
                    }
                    else
                    {
                        treeDirection = Random.Range(0f, 180f);
                        Instantiate(tree1, new Vector3(transform.position.x + i, transform.position.y + 1.5f, transform.position.z + j), (Quaternion.Euler(0f, treeDirection, 0f)));
                    }
                }
            }
        }
    }
    public void CreateClayField()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                rand = Random.Range(0, 10);
                if (rand < 3)
                {
                    Instantiate(clayGround[0], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                }
                else
                {
                    Instantiate(clayGround[1], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                    rand = Random.Range(0, 5);
                    if (rand == 0)
                    {
                        Instantiate(tree, new Vector3(transform.position.x + i, transform.position.y + 1.5f, transform.position.z + j), Quaternion.identity);
                    }
                }
            }
        }
    }

    private void CreateWallSockets()
    {
        
        transform.position = new Vector3(-0.5f,0.5f,0f);
        for (float i = 0.5f; i < sizeMap; i++)
        {
            for (float j = 0.5f; j < sizeMap -1; j++)
            {
                Instantiate(myWallSocket, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + j), (Quaternion.Euler(0f, 90f, 0f)));
            }
        }
              
        //Creating Sockets along z-axis
        transform.position = new Vector3(0, 0.5f, -0.5f);
        for (float i = 0.5f; i < sizeMap -1; i++)
        {
            for (float j = 0.5f; j < sizeMap; j++)
            {
                Instantiate(myWallSocket, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + j), Quaternion.identity);
            }
        }
    }

    private void CreateRoofSockets()
    {
        transform.position = new Vector3(0.5f, 2.5f, 0.5f);
        for (float i = 0.5f; i < sizeMap - 2; i++)
        {
            for (float j = 0.5f; j < sizeMap - 2; j++)
            {
                Instantiate(myRoofSocket, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + j), Quaternion.identity);
            }
        }
    }
}
