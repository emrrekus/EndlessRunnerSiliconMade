using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
   // public ObjectPooler pools;
    public float height = 10;
    public RaycastHit hit;
  

    // Update is called once per frame
    void Update()
    {

       RayCase();
    
    }

    private void RayCase()
    {
        
        Ray rayDown = new Ray(transform.position, Vector3.down);
        Ray rayForward = new Ray(transform.position, Vector3.forward);
        

        Debug.DrawRay(transform.position, Vector3.down * height, Color.green);
        Debug.DrawRay(transform.position, Vector3.forward * 1, Color.red);

        if (Physics.Raycast(rayDown, out hit))
        {
            if (hit.collider.tag =="Sphere" || hit.collider.tag=="Cube")
            {
                
                gameObject.transform.position = randomPosition();
               // hit.collider.gameObject.SetActive(false);



                Debug.Log("Konum Deðiþti");
            }


        }
        if (Physics.Raycast(rayForward, out hit))
        {
            if (hit.collider.tag == "Sphere" || hit.collider.tag == "Cube")
            {

                gameObject.transform.position = randomPosition();
                // hit.collider.gameObject.SetActive(false);



                Debug.Log("Konum Deðiþti");
            }


        }


    }
    int[] xBound = new int[3] { -3, 0, 3 };
    float[] yBound = new float[3] { 0.5f, 1.5f, 3 }; // adjust according to jump height
    int zBound = 45;
    Vector3 randomPos;

    public Vector3 randomPosition()
    {

      


        if (gameObject.transform.rotation == Quaternion.Euler(0, 90, 0) || gameObject.transform.rotation == Quaternion.Euler(0, -90, 0))
        {
            randomPos = new Vector3(Random.Range(-zBound, zBound), yBound[Random.Range(0, yBound.Length)], xBound[Random.Range(0, xBound.Length)]);
        }
        if (gameObject.transform.rotation == Quaternion.Euler(0, 0, 0) || gameObject.transform.rotation == Quaternion.Euler(0, -180, 0))
        {
            randomPos = new Vector3(xBound[Random.Range(0, xBound.Length)], yBound[Random.Range(0, yBound.Length)], Random.Range(-zBound, zBound));
        }

        return randomPos;
    }
}
