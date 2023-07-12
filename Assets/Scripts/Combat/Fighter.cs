using System;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        public Transform target;

        [SerializeField] private float weaponRange = 2f;
        private void Update()
        {
            bool isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
            if (target != null && !isInRange)
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
            }
        }


        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            print("Take that you short, squat peasant!");
        }
    }
}