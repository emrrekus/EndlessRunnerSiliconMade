using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float movementSpeed = 5;
    public SpawnManager spawnManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        float hMovement=Input.GetAxis("Horizontal")*movementSpeed;
        

        transform.Translate(new Vector3(hMovement,0,0)* Time.deltaTime);
        

    }
    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEnter();
    }
}
