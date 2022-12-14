using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Geek
{
    public interface ITouch
    {
        virtual bool Touch()
        {
            return false;
        }
    }
}
