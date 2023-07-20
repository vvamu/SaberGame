using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyPress : MonoBehaviour
{
    public string SceneName;
    void Update()
    {
        if(Input.anyKeyDown){
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
        }
    }
}
