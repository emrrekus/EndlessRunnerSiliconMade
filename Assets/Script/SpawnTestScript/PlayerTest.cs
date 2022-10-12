using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public float moveSpeed = 5;
    public float movementSpeed = 5;
    ObjectPooler pooler;

    private void Start()
    {
        pooler = ObjectPooler.instance;
    }

    public void RemoveFromSceneAndAddToQueue(GameObject objectToRemove)
    {
        objectToRemove.SetActive(false);
        pooler.poolDictionary[objectToRemove.tag].Enqueue(objectToRemove);
    }
    void Update()
    {
      transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        float hMovement=Input.GetAxis("Horizontal")*movementSpeed;
        transform.Translate(new Vector3(hMovement,0,0)* Time.deltaTime);        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            RemoveFromSceneAndAddToQueue(other.gameObject);
        }
    }
}
