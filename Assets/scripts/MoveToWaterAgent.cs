using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;

public class MoveToWaterAgent : Agent {
    public override void OnActionReceived(ActionBuffers action)
    {
        Debug.Log(action.DiscreteActions[0]);
    }
}
