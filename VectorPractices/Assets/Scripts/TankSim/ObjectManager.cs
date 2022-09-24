using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectManager : MonoBehaviour
{
   [SerializeField] private GameObject _fuelPrefab;
   private const float _maxLimit = 100f;
   private void Start()
   {
      var obj = Instantiate(_fuelPrefab,
         new Vector3(Random.Range(-_maxLimit, _maxLimit), Random.Range(-_maxLimit, _maxLimit), _fuelPrefab.transform.position.z),
         Quaternion.identity);
   }
}
