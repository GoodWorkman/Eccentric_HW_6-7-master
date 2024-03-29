using System;
using UnityEngine;

public class AmmoCreator : MonoBehaviour
{
   [SerializeField] private GameObject _ammoPrefab;
   [SerializeField] private Transform _spawnPoint;
   
   private AmmoContainer _ammoContainer;


   private void Start()
   {
      _ammoContainer = FindObjectOfType<AmmoContainer>();
   }

   public void CreateAmmo()
   {
      Instantiate(_ammoPrefab, _spawnPoint.position, _spawnPoint.rotation, _ammoContainer.transform);
   }
}
