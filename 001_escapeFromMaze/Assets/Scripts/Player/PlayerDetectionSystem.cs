using System;
using System.Collections;
using System.Collections.Generic;
using TheGame.Scripts.Attribute;
using UnityEngine;


public class PlayerDetectionSystem : MonoBehaviour
{
    [NonSerialized] public int attributes;
    [NonSerialized] public Collider[] buffer = new Collider[32];

    void Update()
    {
        var nResult = Physics.OverlapSphereNonAlloc(transform.position, 0.75f, buffer, Physics.AllLayers);

        if (nResult > 0)
        {
            for (int i = 0; i < nResult; i++)
            {
                if (buffer[i].TryGetComponent(out AttributeSerialized attributeSerialized))
                {
                    if (attributeSerialized.attribute.isAntiAttribute)
                    {
                        RemoveAttribute((int)attributeSerialized.attribute.attributeType);

                    }
                    else
                    {

                        AddAttribute((int)attributeSerialized.attribute.attributeType);
                    }
                }
            }
        }

        Debug.Log(Convert.ToString(attributes, 2).PadLeft(8, '0'));
    }

    private void RemoveAttribute(int attributeType)
    {
        attributes &= ~attributeType;
    }

    private void AddAttribute(int attributeType)
    {
        attributes |= attributeType;
    }
}
