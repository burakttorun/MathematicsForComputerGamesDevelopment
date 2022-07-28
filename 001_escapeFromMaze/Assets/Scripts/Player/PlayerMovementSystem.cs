using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheGame.Scripts.Player
{

    public class PlayerMovementSystem : MonoBehaviour
    {

        void Update()
        {
            var xAxis = Input.GetAxis("Horizontal");
            var yAxis = Input.GetAxis("Vertical");

            transform.position += new Vector3(xAxis, 0, yAxis) * Time.deltaTime * 10;
        }
    }
}