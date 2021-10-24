using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerRigidbody : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1f;
    public float JumpPower = 1f;
    public float rotSpeed = 30f;
    float newRotY = 0; 
    
    public GameObject prefabBullet;
    public GameObject gunPosition;
    public float gunPower = 20f;
    public float gunCooldown = 1f;
    public float gunCooldownCount = 0;
    public int bulletCount = 0;
    public bool hasGun = false;
    public int coinCount = 0;
    public AudioSource audioCoin;
    public AudioSource audioFire;

    public PlaygroundSceneManager  manager;
    
   
    

// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(manager == null)
        {
            manager = FindObjectOfType<PlaygroundSceneManager>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        /*if(Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0,0,speed,ForceMode.VelocityChange);
         
        }
         if(Input.GetKey(KeyCode.DownArrow))
        {
             rb.AddForce(0,0,-speed,ForceMode.VelocityChange);
            
        }
         if(Input.GetKey(KeyCode.LeftArrow))
        {
            
             rb.AddForce(-speed,0,0,ForceMode.VelocityChange);
        }
         if(Input.GetKey(KeyCode.RightArrow))
        {
              rb.AddForce(speed,0,0,ForceMode.VelocityChange);
         
        }*/
         float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
            rb.AddForce(horizontal,0,vertical,ForceMode.VelocityChange);
              transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, newRotY, 0),transform.rotation,rotSpeed * Time.deltaTime);

            if(horizontal > 0)
            {
                newRotY = 90;
            } else if(horizontal < 0)
                {
                    newRotY = -90;
                } else if(vertical > 0)
                    {
                        newRotY = 0;
                    }
                    else if(vertical < 0)
                    {
                        newRotY = 180;
                    }
            
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0,JumpPower,0,ForceMode.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.F) && bulletCount > 0 && hasGun && (gunCooldownCount >= gunCooldown))
        {
            gunCooldownCount = 0;
            bulletCount-- ;
            audioFire.Play();
            /*manager.SetTextBullet(bulletCount);*/
            GameObject Bullets = Instantiate(prefabBullet,gunPosition.transform.position,gunPosition.transform.rotation);
            Bullets.GetComponent<Rigidbody>().AddForce(transform.forward * gunPower, ForceMode.Impulse);
            Destroy(Bullets, 3f);
           
        }
         gunCooldownCount += Time.fixedDeltaTime;
    }
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "coin")
            {
                 Destroy(other.gameObject);
                 coinCount++ ;
                 manager.SetTextCoin(coinCount);
                 audioCoin.Play();

            }

            if(other.gameObject.tag == "Gun")
            {
                Destroy(other.gameObject);
                hasGun = true;
                bulletCount += 10;
                 manager.SetTextBullet(bulletCount);
            }
            
           


        
         }       
}
