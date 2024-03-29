using TMPro;
using UnityEngine;

public class Riffle : Gun
{
   [Header("Riffle")] 
   [SerializeField] private int _numberOfBullets;

   [SerializeField] private TextMeshProUGUI _bulletText;
   [SerializeField] private GameObject _bulletInfoScreen;

   [SerializeField] private PlayerArmory _playerArmory;

   protected override void Shot()
   {
      base.Shot();

      _numberOfBullets -= 1;

      UpdateText();

      if (_numberOfBullets == 0)
      {
         _playerArmory.TakeGunByIndex(0);
      }
   }

   public override void Activate()
   {
      base.Activate();
      _bulletInfoScreen.SetActive(true);
   }

   public override void Deactivate()
   {
      base.Deactivate();
      _bulletInfoScreen.SetActive(false);

   }

   public override void AddBullets(int numberOfBullets)
   {
      _numberOfBullets += numberOfBullets;
      
      UpdateText();
      
      _playerArmory.TakeGunByIndex(1);
   }

   private void UpdateText()
   {
      _bulletText.text = _numberOfBullets.ToString();
   }
}
