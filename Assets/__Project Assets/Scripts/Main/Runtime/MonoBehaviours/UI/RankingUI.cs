using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingUI : MonoBehaviour
{
    public RankingEntry[] entries;

    public void GetPlayfabRanking(string stat)
    {
        GetLeaderboardRequest request = new GetLeaderboardRequest() { StatisticName = stat };
        PlayFab.PlayFabClientAPI.GetLeaderboard(request, (result) =>
        {
            for (int i = 0; i < result.Leaderboard.Count; i++)
            {
                if (i < entries.Length)
                {
                    entries[i].Update(result.Leaderboard[i].Profile.DisplayName, result.Leaderboard[i].StatValue.ToString());
                }
            }

            result.Leaderboard.ForEach(x => Debug.Log(x.ToString()));
            
        }, (error) => { 
        
        });
    }
}
