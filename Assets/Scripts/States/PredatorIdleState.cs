using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorIdleState : PredatorBaseState
{
    public override void EnterState(PredatorStateManager predator)
    {
        message = "I am hungry searching for food";

        //message = "I am in idle state, started moving";
    }

    public override void UpdateState(PredatorStateManager predator)
    {
        //message = "I am hungry searching for food";
    }

    public override void OnTriggerStay(PredatorStateManager predator, Collider other)
    {
        GameObject prey = other.gameObject;

        if (prey.GetComponent<Prey>())
        {
            predator.predMovement.Move(other.transform.position);
            message = "Gotach! Prey, Chasing you";
        }
    }

    public override void OnCollisionEnter(PredatorStateManager predator, Collision collision)
    {
        GameObject prey = collision.gameObject;

        if (prey.GetComponent<Prey>())
        {
            predator.SwitchState(predator.predatorEvolveState);
            collision.gameObject.GetComponent<Prey>().ResetPosition();
        }
    }
}