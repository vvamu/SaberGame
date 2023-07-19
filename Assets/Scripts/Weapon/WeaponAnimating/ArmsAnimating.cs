using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsAnimating : MonoBehaviour
{
    public Animator _animator;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            _animator.SetTrigger("Reload");
        }
    }
}
