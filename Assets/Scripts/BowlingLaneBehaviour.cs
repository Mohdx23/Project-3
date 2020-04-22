using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple bowling lane logic, is triggered externally by buttons that are routed
/// to the InitialiseRound, TalleyScore and ResetRack.
/// 
/// Future work;
///   Use the timer in update to limit how long a player has to bowl,
///   Detect that the player/ball is 'bowled' from behind the line
/// </summary>
public class BowlingLaneBehaviour : MonoBehaviour
{
    public GameObject pinPrefab;
    public GameObject bowlingBall;
    public Transform[] pinSpawnLocations;
    public Transform defaultBallLocation;
    //TODO; we need a way of tracking the pins that are used for scoring and so we can clean them up

    List<GameObject> pins = new List<GameObject>();
    BowlingCheckListItems bowlingCheckListItems;

     void Start()
    {
        bowlingCheckListItems = FindObjectOfType<BowlingCheckListItems>();
        bowlingCheckListItems.MaxScore = pinSpawnLocations.Length;
    }

    [ContextMenu("InitialiseRound")]
    public void InitialiseRound()
    {
        //TODO; need to move or init or create pins for a round of bowling, most likely to include some of the following;

        foreach (var pinLoc in pinSpawnLocations)
        {
            var newPin = Instantiate(pinPrefab, pinLoc.position, pinLoc.rotation);
            pins.Add(newPin);
        }
    }

    public void BallReachedEnd()
    {
        //bowlingBall.transform.position = defaultBallLocation.transform.position;
        //TODO; this needs to return the ball to the ball feed so the player could bowl again or at least clean ups
    }

    int score;

    [ContextMenu("TalleyScore")]
    public void TalleyScore()
    {
       int score = 0;
        
        for (int i = 0; i < pins.Count; i++) 
        {
            float angle = Vector3.Dot(Vector3.up, pins[i].transform.up);

            if (angle <= 0.9f)
             {
                score++;
             }
        }

        bowlingCheckListItems.Score = score;
        bowlingCheckListItems.OnBollowingScored();
       
        //TODO; determine score and get that information out to a checklist item, either via event or directly
    }

    [ContextMenu("ResetRack")]
    public void ResetRack()
    {
        for (int i = 0; i < pins.Count; i++)
        {

        pins[i].transform.position = pinSpawnLocations[i].transform.position;
        pins[i].transform.rotation = pinSpawnLocations[i].transform.rotation;
        }

        bowlingBall.transform.position = defaultBallLocation.transform.position;
        bowlingBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bowlingBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        bowlingCheckListItems.Score = 0;
        bowlingCheckListItems.OnBollowingScored();
    }
        //TODO; clean up all objects created by the bowling lane, preparing for a new round of bowling to occur


    protected void Update()
    {

    }
}
