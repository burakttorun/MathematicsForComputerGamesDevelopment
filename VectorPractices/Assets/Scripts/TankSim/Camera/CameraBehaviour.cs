using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheGame.Scripts.TankSim.Camera
{
    public class CameraBehaviour : MonoBehaviour
    {
       [SerializeField] private Transform _tankTransform;

       private void Update()
       {
           var position = _tankTransform.position;
           transform.position = new Vector3(position.x, position.y, transform.position.z);
       }
    }
}