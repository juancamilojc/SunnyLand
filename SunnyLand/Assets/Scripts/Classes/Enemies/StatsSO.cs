using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StatsSO")]
public class StatsSO : ScriptableObject {
    [Header("Patrol State Detection")]
    public float moveSpeed;
    public float cliffCheckDistance;
    public float obstacleDistance;

    [Header("Player Detection")]
    public float playerDetectDistance;
    public float detectionPauseTime;
    public float playerDetectedWaitTime;

    [Header("Charge State")]
    public float chargeTime;
    public float chargeSpeed;
}
