using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geek
{
    public interface IHitable
    {
        virtual bool Hit(Vector3 attackPoint, Transform attacker, float damage)
        {
            return false;
        }
    }
}
