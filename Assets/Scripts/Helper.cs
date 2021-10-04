using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{

    public static void DoFaceLeft(GameObject obj, bool faceleft)
    {
        if (faceleft == true)
        {
            obj.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

   /*public static void followPlayer ( GameObject player , GameObject enemy)
    {
        float dist;
        dist = player.transform.x - enemy.transform.x;


        



    }*/






}
