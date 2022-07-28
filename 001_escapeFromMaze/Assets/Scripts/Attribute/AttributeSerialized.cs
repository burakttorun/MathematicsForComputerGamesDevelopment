using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheGame.Scripts.Attribute
{

    public enum AttributeType
    {
        MAGIC = 16,
        INTELLIGENCE = 8,
        CHARISMA = 4,
        FLY = 2,
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