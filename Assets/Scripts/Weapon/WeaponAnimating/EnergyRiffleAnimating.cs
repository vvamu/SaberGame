using UnityEditor.Animations;
using UnityEngine;

public class EnergyRiffleAnimating : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private void Start() 
    {
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            _animator.SetBool("Run", true);
            _animator.SetBool("Aiming", false);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)) _animator.SetBool("Run", false);
        if(Input.GetMouseButtonDown(1)) _animator.SetBool("Aiming", true);

        if(Input.GetMouseButtonUp(1)) _animator.SetBool("Aiming", false);
        if(Input.GetMouseButton(0)) _animator.SetTrigger("Shoot");
        if(Input.GetKey(KeyCode.R)) _animator.SetTrigger("Reload");
    }
}