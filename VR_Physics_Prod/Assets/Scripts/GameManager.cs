using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PedestalCollision[] pedestals;   
    public static GameManager instance;

    public AudioClip WinnerAudio;
    private void Awake()
    {
        instance = this;
    }

    public void CheckForWin()
    {
        foreach(var ped in pedestals)
        {
           if(!ped.rightCube)
            {
                return;
            }
        }
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WinnerAudio);
    }
}
