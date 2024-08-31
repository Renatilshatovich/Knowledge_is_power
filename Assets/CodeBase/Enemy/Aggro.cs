using UnityEngine;

namespace CodeBase.Enemy
{
    public class Aggro: MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public AgentMoveToHero Follow;
        
        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;

            SwitchFollowOff();
        }

        private void TriggerEnter(Collider obj) => 
            SwitchFollowOn();

        private void TriggerExit(Collider obj) => 
            SwitchFollowOff();

        private void SwitchFollowOn() => 
            Follow.enabled = true;

        private void SwitchFollowOff() => 
            Follow.enabled = false;
    }
}