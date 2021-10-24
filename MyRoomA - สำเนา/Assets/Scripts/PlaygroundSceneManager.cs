using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaygroundSceneManager : MonoBehaviour
{
    public Text uiTextCoin;    
    public Text uiTextBullet;
    public Text uiTextScore;  
    

    public void GotoHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void SetTextCoin(int amount)
    {
        uiTextCoin.text = amount.ToString();
    }
    public void SetTextBullet(int amount)
    {
         uiTextBullet.text = amount.ToString();
    }
     public void SetTextScore(int amount)
    {
        uiTextScore.text = amount.ToString();
    }    
    

}
