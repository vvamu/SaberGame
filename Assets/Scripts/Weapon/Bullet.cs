using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody _rb;
        private Vector3 _targetPosition;
        private void Start()
        {
            
            //transform.Rotate(90,0,0);
            //_rb.AddForce(0, 0, _speed);
        }

        private void FixedUpdate()
        {

            transform.Translate(0, 0, _speed);
            //_rb.MovePosition(transform.TransformDirection(transform.forward*2));//+ _speed * transform.forward));

        }
        //public void SetTarget()
        //{

        //}
    }
}
