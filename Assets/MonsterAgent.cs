﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MonsterAgent : Agent
{

  public Transform Target;

  private Rigidbody rBody;

  // Start is called before the first frame update
  void Start()
  {
    rBody = GetComponent<Rigidbody>();
  }

  public override void OnEpisodeBegin()
  {
    // If the Agent fell, zero its momentum
    if (this.transform.localPosition.y < 0)
    {
      this.rBody.angularVelocity = Vector3.zero;
      this.rBody.velocity = Vector3.zero;
      this.transform.localPosition = new Vector3(0, 0.5f, 0);
    }

    // Move the target to a new spot
    Target.localPosition = new Vector3(Random.value * 10 - 5,
                                       0.5f,
                                       Random.value * 10 - 5);
  }

  public override void CollectObservations(VectorSensor sensor)
  {
    // Target and Agent positions
    sensor.AddObservation(Target.localPosition);
    sensor.AddObservation(this.transform.localPosition);

    // Agent velocity
    sensor.AddObservation(rBody.velocity.x);
    sensor.AddObservation(rBody.velocity.z);
  }

  public float forceMultiplier = 10;
  public override void OnActionReceived(ActionBuffers actionBuffers)
  {
    // Actions, size = 2
    Vector3 controlSignal = Vector3.zero;
    controlSignal.x = actionBuffers.ContinuousActions[0];
    controlSignal.z = actionBuffers.ContinuousActions[1];
    rBody.AddForce(controlSignal * forceMultiplier);

    // Rewards
    float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

    // Reached target
    if (distanceToTarget < 1.6f)
    {
      SetReward(1.0f);
      EndEpisode();
    }

    // Fell off platform
    else if (this.transform.localPosition.y < 0)
    {
      EndEpisode();
    }
  }

  public override void Heuristic(in ActionBuffers actionsOut)
  {
    var continuousActionsOut = actionsOut.ContinuousActions;
    continuousActionsOut[0] = Input.GetAxis("Horizontal");
    continuousActionsOut[1] = Input.GetAxis("Vertical");
  }


}
