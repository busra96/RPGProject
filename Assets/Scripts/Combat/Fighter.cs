using System;
using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour,IAction
    {
        public Transform target;

        [SerializeField] private float weaponRange = 2f;
        private void Update()
        {
            if(target == null) return;
            
            if (!GetIsRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            GetComponent<Animator>().SetTrigger("attack");
        }

        private bool GetIsRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            print("Take that you short, squat peasant!");
           
        }

        public void Cancel()
        {
            target = null;
        }

        //Animation Event
        void Hit()
        {
            
        }
        
    }
}