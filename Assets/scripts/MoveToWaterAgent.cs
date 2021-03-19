using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class MoveToWaterAgent : Agent {
    [SerializeField] private Transform target_transform = null;
    private Monster monster;
    private Vector3 nextMove;

    void Start()
    {
        monster = gameObject.GetComponent<Monster>() as Monster;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(target_transform);

    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        nextMove = Vector3.zero;
        //Debug.Log("\ncontinuous action 0 = "+actions.ContinuousActions[0]);
        //Debug.Log("continuous action 1 = " + actions.ContinuousActions[1]);
        //Debug.Log("discrete action 0 = " + actions.DiscreteActions[0]);

        nextMove.x = actions.ContinuousActions[0];
        nextMove.z = actions.ContinuousActions[1];
        nextMove.y = 0;

        if (actions.DiscreteActions[0]==1)
        {
            //Debug.Log("manger!");
            monster.setInteraction(true);
        }
        else
        {
            monster.setInteraction(false);
        }
     

        monster.SetDirection(nextMove);

        //Debug.Log(actions.DiscreteActions[0]);
        //Debug.Log("log");

    }

}
