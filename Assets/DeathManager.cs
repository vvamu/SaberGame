using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathManager : MonoBehaviour
{
    public Action DeathCallback;
    public void Start()
    {
        DeathCallback += Death;
    }
    public void Death(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScene");
    }
}
