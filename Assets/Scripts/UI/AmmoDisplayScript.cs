using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplayScript : MonoBehaviour
{
    public TextMeshProUGUI AmmoDisplayText;
    public GameObject Weapon;

        // Start is called before the first frame update

        // Update is called once per frame
    void Update()
    {
        AmmoDisplayText.text = Weapon.GetComponent<Ammo>().CurrentInClipCount.ToString()+" / "+ Weapon.GetComponent<Ammo>().CurrentCount.ToString();
    }
}
