using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    ObjectPooler pooler;
    [SerializeField] GameObject parentPrefab;
    Vector3 parentBound;

    [SerializeField] string[] objectsToSpawn;

    private void Awake()
    {
        parentBound = parentPrefab.transform.position;
    }
    private void OnEnable()
    {
        
        pooler = ObjectPooler.instance;

       for(int i = 0; i < objectsToSpawn.Length; i++)
        {
            pooler.SpawnRandomNumber(objectsToSpawn[i], Quaternion.identity, 5, false, parentPrefab);
        }
     
    }

   

}
