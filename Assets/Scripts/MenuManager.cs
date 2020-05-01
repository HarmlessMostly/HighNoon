using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToGame()
    {
        /*if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {

        }*/
        SceneManager.LoadScene("SampleScene");
    }

    public void ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
