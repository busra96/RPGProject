using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour,IAction
    {

        [SerializeField] private float weaponRange = 2f;
        [SerializeField] private float timeBetweenAttacks = 1f;
        [SerializeField] private float weaponDamage = 5f;
        
        Transform target;
        private float timeSinceLastAttack = 0;
        
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            
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
            if(timeSinceLastAttack < timeBetweenAttacks) return;
            //this will trigger the Hit() event
            timeSinceLastAttack = 0;
            GetComponent<Animator>().SetTrigger("attack");
            
            
        }
        
        //Animation Event
        void Hit()
        {
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
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

        
        
    }
}