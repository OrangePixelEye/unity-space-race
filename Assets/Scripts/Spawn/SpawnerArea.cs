using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

enum Direction{Left, Right}
public class SpawnerArea : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objects = new GameObject[1];
    
    private int sizeOfObjects = 0;

    [SerializeField]
    private Direction direction;
    
    [Range(0.001f , 3f)]
    [SerializeField]
    private float spawnTime = 0.5f;

    [SerializeField] 
    BoxCollider2D bc;
    Vector2 cubeSize;
    Vector2 cubeCenter;

    [SerializeField]
    private Transform spawnArea;

    void Awake()
    {
        Transform myColliderSpawn = bc.GetComponent<Transform>();
        cubeCenter = myColliderSpawn.position;
 
        cubeSize.x = myColliderSpawn.localScale.x * bc.size.x;
        cubeSize.y = myColliderSpawn.localScale.y * bc.size.y;
    	
    }

    void OnEnable() => StartSpawn();

    private void StartSpawn()
    {
    	sizeOfObjects = objects.Length;
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
    	BoxCollider2D renderer = GetComponent<BoxCollider2D>();
        
        Vector2 vector = new Vector2(0,0);
        if (direction == Direction.Left)
            vector = Vector2.right;
        else
            vector = Vector2.left;

        var x2 = renderer.bounds.size.x;
        
        for(;;)
    	{
            yield return new WaitForSeconds(spawnTime);
            GameObject go = Instantiate(objects[UnityEngine.Random.Range(0, sizeOfObjects)], GetRandomPosition(), Quaternion.identity, spawnArea);
            go.GetComponent<Meteor>().Initialize(vector);
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 randomPosition = new Vector2(UnityEngine.Random.Range(-cubeSize.x / 2, cubeSize.x / 2), UnityEngine.Random.Range(-cubeSize.y / 2, cubeSize.y / 2));
        return cubeCenter + randomPosition;
    }
}