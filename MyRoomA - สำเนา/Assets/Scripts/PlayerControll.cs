using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
      public float rotSpeed = 20f;
    public float speed = 2f;
        float newX = 0;
        float newY = 0;
        float newZ = 0;
        float newRotY = 0;
      
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
             newZ = transform.position.z + speed * Time.deltaTime;
              newRotY = 0;
        }
         if(Input.GetKey(KeyCode.DownArrow))
        {
             newZ = transform.position.z - speed * Time.deltaTime;
              newRotY = 180;
        }
         if(Input.GetKey(KeyCode.LeftArrow))
        {
             newX = transform.position.x - speed * Time.deltaTime;
             newRotY = -90;
        }
         if(Input.GetKey(KeyCode.RightArrow))
        {
             newX = transform.position.x + speed * Time.deltaTime;
             newRotY = 90;

        }
      
         transform.position = new Vector3(newX,newY,newZ);
         transform.rotation = Quaternion.Lerp(Quaternion.Euler(0,newRotY,0),
                                      transform.rotation,
                                      Time.deltaTime*rotSpeed);
                             

    }
        void OnCollisionEnter(Collision collision)
        {
             print(collision.gameObject.name);
}
        }
 

