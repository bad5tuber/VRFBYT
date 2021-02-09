// to mark as serializable, need to delete 
// using System.Collections;
// using System.Collections.Generic;

using System;
using UnityEngine;
using UnityEngine.Events;

// uses UE.Events namespace

public class Target : MonoBehaviour
{
    // custom event that in inspector that can output an int value
    // similar to a slider
    [Serializable] public class HitEvent : UnityEvent<int> { }
    // same as our On Enter, On Exit, On Select, but passes additional value instead of bool
    // public UnityEvent onHit = new UnityEvent();
    // need to mark the below as 'serializable' 

    public HitEvent onHit = new HitEvent();
    // check for colliding objects
    // projectile hits target, feeds in the position of target
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            FigureOutScore(collision.transform.position);
        }
    }

    private void FigureOutScore(Vector3 hitPosition)
    {
        float distanceFromCenter = Vector3.Distance(transform.position, hitPosition);
        int score = 0;

        if (distanceFromCenter < 0.25f)
            score = 15;

        else if (distanceFromCenter < 0.5f)
            score = 5;

        // invoke is used for events, asks for integer value

        onHit.Invoke(score);
    }
}
