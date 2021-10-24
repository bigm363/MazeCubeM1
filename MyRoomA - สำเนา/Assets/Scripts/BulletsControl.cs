using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulletsControl : MonoBehaviour
{

     public int ScoreCount;
     public PlaygroundSceneManager manager; 
     public Text uiTextScore;

    void Start()
    {
        ScoreCount = 0;
    }
   
    // Start is called before the first frame update
   
   
    
    
    private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "target")
            {
           
                ScoreCount++ ;
                uiTextScore.text = "Score =" + ScoreCount;
                Destroy(other.gameObject);
            }
         }
}
