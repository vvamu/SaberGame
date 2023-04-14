﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] protected UnityEvent OnDeath;

        [Min(0)]
        [SerializeField] protected float Health;
    }
}
