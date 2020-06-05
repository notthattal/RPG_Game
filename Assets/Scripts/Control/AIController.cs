using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter = default;
        GameObject player = default;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
        }
        private void Update()
        {

            if (InAttackRange() && fighter.CanAttack(player))
            {
                GetComponent<Fighter>().Attack(player);
            }
        }

        private bool InAttackRange()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }
    }
}