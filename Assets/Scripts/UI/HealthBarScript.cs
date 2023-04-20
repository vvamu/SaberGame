using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public GameObject Player;
    public Slider HealthBarSlider;
    // Start is called before the first frame update
    void Start()
    {
        HealthBarSlider.maxValue = Player.GetComponent<Player>().MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarSlider.value = Player.GetComponent<Player>().Health;
    }
}
