using System;
using UnityEngine.Playables;
using UnityEngine;

public class TimeLineManager : MonoBehaviour
{
   private bool isFix = false;
   [SerializeField] private Animator _HeroAnimator;
   [SerializeField] private RuntimeAnimatorController _HeroController;
   [SerializeField] private PlayableDirector _Director;

   private void Start()
   {
      _HeroController = _HeroAnimator.runtimeAnimatorController;
      _HeroAnimator.runtimeAnimatorController = null;
   }

   private void Update()
   {
      if (_Director.state != PlayState.Playing && !isFix)
      {
         isFix = true;
         _HeroAnimator.runtimeAnimatorController = _HeroController;
      }
   }
}
