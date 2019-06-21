using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Skill
{
    /*Author: Michał Miciak*/
    /*Interface for skills*/
    public interface ISkill
    { 
        int Cost { get; }
        void ApplySkill(Vector3 position);
    }
}
