using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingCheckListItems : CheckListItem
{
    public int Score { get; set; }
    public int MaxScore { get; set; }
    //this code is used to see if the player has reached the max score and if it is true the it will show us the sign of completion.
    public override bool IsComplete { get { return Score == MaxScore;  } }

    public override float GetProgress()
    {
        return (float)Score / (float)MaxScore;
        //This gives you the true value of your progress as it ranges from 0,1 because we divide the current score by the max score.
    }

    public override string GetStatusReadout()
    {
        return Score + " / " + MaxScore.ToString();
        //Getstatusreadout returns the score of bowling pins knocked down.
    }

    public override string GetTaskReadout()
    {
        return "Total bowling tally: ";
        //Gettaskreadout returns a string showing you what the task is.
    }

    public void OnBollowingScored()
        //this function is used to see if any data in this class was changed which is the score and if it is then it shows you the new score.
    {
        {
            var ourData = new GameEvents.CheckListItemChangedData();
            ourData.item = this;
            ourData.previousItemProgress = GetProgress();
            
            GameEvents.InvokeCheckListItemChanged(ourData);
        }
        //if (numberofHoopsScored < numberOfRequiredHoops)
    }
   
}
