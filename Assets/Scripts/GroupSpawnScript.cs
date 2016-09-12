using UnityEngine;
using System.Collections;

public class GroupSpawnScript : MonoBehaviour
{

    public GameObject obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;
    public float distancia = 0.8f;
    private Vector3 _position;
    private float[][,] functions;
    private float[,] function1, function2, function3, function4, function5, function6, function7, function8, function9, function10;

    private void Awake()
    {
        function1 = new float[,]{
                                {-2, -1, 0, 1, 2, -3, -2, -1, 0, 1, 2, 3, -2, -1, 0, 1, 2},
                                { 0,  0, 0, 0, 0,  1,  1,  1, 1, 1, 1, 1,  2,  2, 2, 2, 2}
                                };

        function2 = new float[,]{
                                {  -3,  -2,  -1,   0,   1,   2,   3,  -3,  -2,  -1,   0,   1,   2,   3},
                                {0.5f,0.5f,0.5f,0.5f,0.5f,0.5f,0.5f,1.5f,1.5f,1.5f,1.5f,1.5f,1.5f,1.5f}
                                };

        function3 = new float[,]{
                                {-3, -4, -5, 3, 4, 5,-3, -2, -1, 0, 1, 2, 3,-3, -4, -5, 3, 4, 5},
                                { 0,  0,  0, 0, 0, 0, 1,  1,  1, 1, 1, 1, 1, 2,  2,  2, 2, 2, 2}
                                };

        function4 = new float[,]{
                                {-5, -4,-3, -2, -1, 0, 1, 2, 3, 4, 5,-5,-3, -1, 1, 3, 5, -5, -4,-3, -2, -1, 0, 1, 2, 3, 4, 5},
                                { 0,  0, 0,  0,  0, 0, 0, 0, 0, 0, 0, 1, 1,  1, 1, 1, 1,  2,  2, 2,  2,  2, 2, 2, 2, 2, 2, 2}
                                };

        function5 = new float[,]{
                                {-5,    -4,   -3,    -2,    -1, 0,    1,    2,    3,    4, 5,-5,    -4,   -3,    -2,    -1, 0,    1,    2,    3,    4, 5},
                                { 1,  0.8f, 0.6f,  0.4f,  0.2f, 0, 0.2f, 0.4f, 0.6f, 0.8f, 1, 2,  1.8f, 1.6f,  1.4f,  1.2f, 1, 1.2f, 1.4f, 1.6f, 1.8f, 2}
                                };

        function6 = new float[,]{
                                {-2, -1, 1, 2, -2.5f,-0.5f, 0.5f, 2.5f, -1, -2, 1, 2},
                                { 0,  0, 0, 0,     1,    1,    1,    1,  2,  2, 2, 2}
                                };

        function7 = new float[,]{
                                {-5, -4,-3, -2, -1, 0, 1, 2, 3, 4, 5,-5, 5, -5, -4,-3, -2, -1, 0, 1, 2, 3, 4, 5},
                                { 0,  0, 0,  0,  0, 0, 0, 0, 0, 0, 0, 1, 1,  2,  2, 2,  2,  2, 2, 2, 2, 2, 2, 2}
                                };

        function8 = new float[,]{
                                {-3, -2, -1, 0, 1, 2, 3, -3.5f, -2.5f, 2.5f, 3.5f,-4, -3, 3, 4},
                                { 0,  0,  0, 0, 0, 0, 0,     1,     1,    1,    1, 2,  2, 2, 2}
                                };

        function9 = new float[,]{
                                {-4, -3, -2, -1, 0, 1, 2, 3, 4, -4, -3, 3, 4,-4, -3, 3, 4},
                                { 0,  0,  0,  0, 0, 0, 0, 0, 0,  1,  1, 1, 1, 2,  2, 2, 2}
                                };

        function10 = new float[,]{
                                 {-2, 0, 2,-2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f, -3, -1, 1, 3},
                                 { 0, 0, 0,    1,     1,     1,    1,    1,    1,  2,  2, 2, 2}
                                 };

        functions = new float[][,] { function1, function2, function3, function4, function5, function6, function7, function8, function9, function10 };
    }

    // Use this for initialization
    private void Start()
    {
        Invoke("GroupSpawn", Random.Range(spawnMin, spawnMax));
    }

    private void GroupSpawn()
    {
        //Generate(function1);
        Generate(functions[Random.Range(0, functions.Length)]);
        Invoke("GroupSpawn", Random.Range(spawnMin, spawnMax));
    }

    private void Generate(float[,] function)
    {
        for (int i = 0; i < function.GetLength(1); i++)
        {
            _position = new Vector3(transform.position.x + (distancia * function[0, i]), transform.position.y + (distancia * function[1, i]));
            Instantiate(obj, _position, Quaternion.identity);
        }
    }
}
