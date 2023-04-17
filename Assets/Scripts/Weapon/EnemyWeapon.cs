using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private float _spread;
        [SerializeField] protected Transform _hole;
        [SerializeField] protected LineRenderer _lineRenderer;
        public void Shoot(Vector3 target)
        {
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPositions(new Vector3[] { _hole.position, target });
            StartCoroutine(DispawnBullet());
        }

        public IEnumerator DispawnBullet()
        {
            yield return new WaitForSeconds(0.1f);

            _lineRenderer.positionCount = 0;
        }
    }
}