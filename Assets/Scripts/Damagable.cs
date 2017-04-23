using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Damagable {
    /// <summary>
    /// Deal damage to object with given hp.
    /// </summary>
    /// <param name="damageToHp"></param>
    void damage(float damageToHp);

    /// <summary>
    /// Heal amount of health to object.
    /// </summary>
    /// <param name="healHp"></param>
    void heal(float healHp);

    /// <summary>
    /// Returns whether true when object has 0 or less health.
    /// </summary>
    /// <returns></returns>
    bool isDead();
	
}
