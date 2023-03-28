using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _hole;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _spread;
    [SerializeField] private float _bulletForce;

    private void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = new Ray(_hole.position, _hole.forward);
            Vector3 targetPoint;
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = ray.GetPoint(100);
            }
            var spreadX = Random.Range(-_spread, _spread);
            var spreadY = Random.Range(-_spread, _spread);

            var direction = targetPoint - _hole.position + new Vector3(spreadX, spreadY, 0);

            var bullet = Instantiate(_bullet, _hole.position, Quaternion.AngleAxis(90, Vector3.right));

            bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * _bulletForce, ForceMode.Impulse);
        }
    }

}
