using System;
using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float chaseDistance = 5f;
        [SerializeField] private float suspicionTime = 3f;

        private Fighter fighter;
        private Health health;
        private Mover mover;
        private GameObject player;
        

        private Vector3 guardPosition;
        private float timeSinceLastSawPlayer = Mathf.Infinity;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            mover = GetComponent<Mover>();
            player = GameObject.FindGameObjectWithTag("Player");

            guardPosition = transform.position;
        }

        private void Update()
        {
            if(health.IsDead()) return;
            
            if (InAttackRangeOfPlayer(player) && fighter.CanAttack(player))
            {
                timeSinceLastSawPlayer = 0;
                AttackBehaviour();
            }
            else if (timeSinceLastSawPlayer < suspicionTime)
            {
                SuspicionBehaviour();
            }
            else
            {
                GuardBehaviour();
            }

            timeSinceLastSawPlayer += Time.deltaTime;
        }

        private void GuardBehaviour()
        {
            fighter.Cancel();
            mover.StartMoveAction(guardPosition);
        }

        private void SuspicionBehaviour()
        {
            GetComponent<ActionScheduler>().CancelAction();
        }

        private void AttackBehaviour()
        {
            fighter.Attack(player);
        }

        private bool InAttackRangeOfPlayer(GameObject player)
        {
            var distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }


        //called by unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
