using System;
using System.Collections;
using System.Collections.Generic;
using TheGame.Scripts.Library;
using UnityEngine;

namespace TheGame.Scripts.TankSim.TankControl
{
    public class TankMovement : MonoBehaviour
    {
        public float speed = 2f;
        [SerializeField] private Transform _followObj;
        private Vector3 _direction;
        private Vector3 _targetDirection;
        [SerializeField] private float _stopDistance = 0.1f;
        [SerializeField] private float _time = 0f;
        
        private void Start()
        {
            _direction = _followObj.position - transform.position;
            _direction = HolisticMath.GetNormal(new Coords(_direction)).ToVector();
            float angle = HolisticMath.Angle(new Coords(_direction), new Coords(transform.up), false);
            bool clockwise = HolisticMath.Cross(new Coords(transform.up), new Coords(_direction)).z <0;
            _targetDirection = HolisticMath.Rotate(new Coords(transform.up), angle,clockwise).ToVector();
          
        }

        private void Update()
        {
            _time += Time.deltaTime*0.01f;
            transform.up = Vector3.Slerp(transform.up, _targetDirection, _time);
            if (HolisticMath.Magnitude(new Coords(transform.position),
                    new Coords(_followObj.position)) > _stopDistance)
                transform.position += _direction * speed * Time.deltaTime;
        }
    }
} 