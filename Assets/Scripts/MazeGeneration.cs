using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class MazeGeneration : MonoBehaviour
{
    [SerializeField] public GameObject wall_wall;
    [SerializeField] public GameObject wall_floor;
    [SerializeField] public GameObject wall_ceiling;
    [SerializeField] public GameObject stair;
    [SerializeField] public GameObject stairA;
    [SerializeField] public GameObject stairB;
    public int width = 8;
    public int height = 8;
    public bool[,] visited;
    public List<GameObject> walls = new List<GameObject>();
    public float wallSize;


    void Start()
    {
        GenerateRoom();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ClearMaze();
            //GenerateMaze();
            return;
        }
    }


    void GenerateRoom()
    {
        Vector3 center = Vector3.zero;
        float halfRoomSize = 5f;

        // Measure wall length
        GameObject temp = CreateWall();
        float wallLength = temp.GetComponentInChildren<Renderer>().bounds.size.x;
        Destroy(temp);

        // Define corners (clockwise)
        Vector3[] corners = new Vector3[4];
        corners[0] = center + new Vector3(-halfRoomSize, 0, -halfRoomSize);
        corners[1] = center + new Vector3(-halfRoomSize, 0, halfRoomSize);
        corners[2] = center + new Vector3(halfRoomSize, 0, halfRoomSize);
        corners[3] = center + new Vector3(halfRoomSize, 0, -halfRoomSize);

        for (int side = 0; side < 4; side++)
        {
            Vector3 start = corners[side];
            Vector3 end = corners[(side + 1) % 4];

            Vector3 dir = (end - start).normalized;
            float sideLength = Vector3.Distance(start, end);
            int wallCount = Mathf.RoundToInt(sideLength / wallLength);

            for (int i = 0; i < wallCount; i++)
            {
                GameObject wall = CreateWall();

                wall.transform.position =
                    start + dir * (i * wallLength);

                wall.transform.rotation =
                    Quaternion.FromToRotation(Vector3.right, dir);
            }
        }
    }


    GameObject CreateWall()
    {
        GameObject wall = Instantiate(wall_wall);
        return wall;
    }

   
}
