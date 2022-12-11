using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //sigue al jugador
    public Transform player;
    public float range;
    public float speedFollow;
    public float stopDistance;

    //ataca al jugador
    public float attackRange;
    public float attackSpeed;
    public float attackDamage;
    public float attackTime;
    private float attackTimeCounter;

    private void FollowPlayer(){
        //seguir jugador
        if (Vector3.Distance(transform.position, player.position) > range) {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speedFollow * Time.deltaTime);
        }
        //atacar jugador
        if (Vector3.Distance(transform.position, player.position) < range
            && Vector3.Distance(transform.position, player.position) > stopDistance) {
            transform.position = this.transform.position;
        }
    }

    private void Update()
    {
        FollowPlayer();
    }
    
    //enemigo que patrulle un area
    //public float speed;
    //public float waitTime;
    //public float startWaitTime;
    //public Transform[] moveSpots;
    //private int randomSpot;

    //private void Start() {
    //    randomSpot = Random.Range(0, moveSpots.Length);
    //}

    //private void Update() {
    //    transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

    //    if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) {
    //        if (waitTime <= 0) {
    //            randomSpot = Random.Range(0, moveSpots.Length);

    //            waitTime = startWaitTime;
    //        } else {
    //            waitTime -= Time.deltaTime;
    //        }
    //    }
    //}













}
