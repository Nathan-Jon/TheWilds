using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface used to access entities which are damageable
/// </summary>
public interface IDamageable {

    float CurrentHealth { get; set; }
    float MaxHealth { get; set; }
    void ChangeHealth(float value);
}
