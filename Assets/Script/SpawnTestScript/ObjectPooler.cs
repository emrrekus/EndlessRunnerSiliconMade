using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool // scruct
    {
        public string tag;
        public GameObject parent;
        public GameObject spawnObject;
        public int size;
        
    }
    
    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public static ObjectPooler instance;
    private void Awake()
    {
        instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.spawnObject, pool.parent.transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
        
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
  


    public void SpawnRandomNumber(string tag, Quaternion rotation, int max, bool isObstacle, GameObject parentPos)
    {
        for (int i = 0; i < max; i++)
        {
            SpawnFromPool(tag, rotation, isObstacle, parentPos);
        }

    }

    public GameObject SpawnFromPool(string tag, Quaternion rotation, bool isObstacle, GameObject parentPos)
    {
        pare = parentPos;
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
            return null;
        }


        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);

        

            objectToSpawn.transform.position = parentPos.transform.position + randomPosition(isObstacle);

        
       

        objectToSpawn.transform.rotation = rotation;
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    GameObject pare;

    

    int[] xBound = new int[3] { -3, 0, 3 };
    float[] yBound = new float[3] { 0.5f, 1.5f, 3 }; // adjust according to jump height
    int zBound = 45;
    Vector3 randomPos;

    public Vector3 randomPosition(bool isObstacle)
    {

        if(isObstacle)
        {
            //adjust the random height so player can jump over or slide under
        }


        if(pare.transform.rotation == Quaternion.Euler(0,90,0)|| pare.transform.rotation == Quaternion.Euler(0, -90, 0))
        {
            randomPos = new Vector3(Random.Range(-zBound, zBound), yBound[Random.Range(0, yBound.Length)], xBound[Random.Range(0, xBound.Length)]);
        }
        if (pare.transform.rotation == Quaternion.Euler(0, 0, 0) || pare.transform.rotation == Quaternion.Euler(0, -180, 0))
        {
            randomPos = new Vector3(xBound[Random.Range(0, xBound.Length)], yBound[Random.Range(0, yBound.Length)], Random.Range(-zBound, zBound));
        }

        return randomPos;
    }

}
