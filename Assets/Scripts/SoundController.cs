using UnityEngine;

public class SoundController : MonoBehaviour
{
   [SerializeField] private AudioSource _music;

   public void SetMusicEnabled(bool value)
   {
      _music.enabled = value;
   }

   public void SetVolume(float value)
   {
      AudioListener.volume = value;
   }
}
