using UnityEngine;

public class BatchPrefabCreator : MonoBehaviour
{
   [SerializeField] private Projectiles _ammoPrefab;

   [SerializeField] private Transform[] _spawns;
   
   private AmmoContainer _ammoContainer;
   
   private void Start()
   {
      _ammoContainer = FindObjectOfType<AmmoContainer>();
   }

   public void Create()
   {
      for (int i = 0; i < _spawns.Length; i++)
      {
         Instantiate(_ammoPrefab, _spawns[i].position, _spawns[i].rotation, _ammoContainer.transform);
      }
   }
}
