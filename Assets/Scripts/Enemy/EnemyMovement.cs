using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform _player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    private NavMeshAgent _nav;


    private void Awake ()
    {
        _player = GameObject.FindGameObjectWithTag ("Player").transform;
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        _nav = GetComponent <NavMeshAgent> ();
    }


    void Update ()
    {
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
            _nav.SetDestination (_player.position);
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
}
