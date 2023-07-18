using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyPress : MonoBehaviour
{
    void Update()
    {
        if(Input.anyKeyDown){
            GetComponent<SceneManager>().StartGame();
        }
    }
}
