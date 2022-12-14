using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheGame.Scripts.Attribute
{

    public enum AttributeType
    {
        MAGIC = 1 << 5,
        INTELLIGENCE = 1 << 4,
        CHARISMA = 1 << 3,
        FLY = 1 << 2,
        INVISIBLE = 1
    }

    [Serializable]
    public struct Attribute
    {
        public bool isAntiAttribute;
        public AttributeType attributeType;
    }

    public class AttributeSerialized : MonoBehaviour
    {
        public Attribute attribute;
    }

}