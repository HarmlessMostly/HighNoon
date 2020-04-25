using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class MenuManager : MonoBehaviour
{
    
    public void ToGame()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
        SceneManager.LoadScene("SampleScene");

        }
    }
    
    public void ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
