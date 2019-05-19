﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public virtual void Die() { }
    public virtual void TakeDamage() { }
}
