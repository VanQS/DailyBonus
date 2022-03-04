
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DailyBonusMange : MonoBehaviour
{
    private static string KEY_TIME_DAILY ="time_dailybonus";
    private static string KEY_INDEX_DAILY = "index_dailybonus";
    
    public static bool CheckTime()
    {
        string timed = PlayerPrefs.GetString(KEY_TIME_DAILY);

        if(string.IsNullOrEmpty(timed))
        {
            return true;
        }

        if (DateTime.TryParse(timed, out DateTime result))
        {
            if (DateTime.Now.Date > result.Date)
            {
                return true;
            }
           
        }

        return false;
    }

    public static void OnClaim()
    {
        PlayerPrefs.SetString(KEY_TIME_DAILY, DateTime.Now.Date.ToString());
        int index = PlayerPrefs.GetInt(KEY_INDEX_DAILY,0) ;
        index ++;
        if(index >6 )
        {
            index = 0;
        }
        PlayerPrefs.SetInt(KEY_INDEX_DAILY, index);
    }
    public static int GetIndex()
    {
        return PlayerPrefs.GetInt(KEY_INDEX_DAILY);
    }
}
