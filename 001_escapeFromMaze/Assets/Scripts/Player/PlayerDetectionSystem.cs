using System;
using System.Collections;
using System.Collections.Generic;
using TheGame.Scripts.Attribute;
using UnityEngine;

namespace TheGame.Scripts.Player
{

    public class PlayerDetectionSystem : MonoBehaviour
    {
        [NonSerialized] public int attributes;
        [NonSerialized] public Collider[] buffer = new Collider[32];

        private int doorMask;

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
                        Destroy(buffer[i].gameObject);
                        SaveAndLoadSystem.Instance.AddDatas(new Datas
                        {
                            Id = 1,
                            Data = attributes
                        }); ;
                    }
                    else if (buffer[i].TryGetComponent(out AttributeMaskSerialized attributeMaskSerialized))
                    {
                        if (CheckMask(attributeMaskSerialized))
                        {
                            buffer[i].GetComponent<Collider>().isTrigger = true;
                        }
                        else
                        {
                            buffer[i].GetComponent<Collider>().isTrigger = false;
                        }
                    }
                }
            }

         //   Debug.Log(Convert.ToString(attributes, 2).PadLeft(8, '0'));
        }

        private bool CheckMask(AttributeMaskSerialized attributeMaskSerialized)
        {
            attributeMaskSerialized.attributeMask.attributes.ForEach(x => doorMask |= (int)x.attributeType);

            if ((doorMask & attributes) == doorMask)
            {
                return true;
            }
            else
            {
                return false;
            }
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

}