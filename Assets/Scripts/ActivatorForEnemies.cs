using System.Collections.Generic;
using UnityEngine;

public class ActivatorForEnemies : MonoBehaviour
{
   [SerializeField] private Transform _player;

   private List<ActivateByDistance> _enemiesForActivate = new();

   private void Update()
   {
      for (int i = 0; i < _enemiesForActivate.Count; i++)
      {
        _enemiesForActivate[i].CheckDistance(_player.position);
      }
   }

   public void AddEnemyToList(ActivateByDistance newEnemy)
   {
      _enemiesForActivate.Add(newEnemy);
   }

   public void RemoveEnemyFromList(ActivateByDistance enemy)
   {
      _enemiesForActivate.Remove(enemy);
   }
}
