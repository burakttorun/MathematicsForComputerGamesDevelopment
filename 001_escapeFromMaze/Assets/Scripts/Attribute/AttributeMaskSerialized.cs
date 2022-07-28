using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheGame.Scripts.Attribute
{
    [Serializable]
    public struct AttributeMask
    {
        public List<Attribute> attributes;
    }
    public class AttributeMaskSerialized : MonoBehaviour
    {
        public AttributeMask attributeMask;
    }
}
