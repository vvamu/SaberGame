using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private bool _enableConsoleLog;
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_enableConsoleLog)
        {
            Debug.Log("Damage take " + damage + " health left " + _health);
        }
        if (_health <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
