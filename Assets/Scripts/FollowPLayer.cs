using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPLayer : MonoBehaviour
{
   /*
    enum FollowAxis
    {
        X,
        Y,
        Z,
        XY,
        XZ,
        YZ,
        XYZ
    }
   */
    [SerializeField] private Transform player;
    //[SerializeField] private FollowAxis chooseAxis;
   void LateUpdate()
    {
        
        /*
        Vector3 newPos;

         if (chooseAxis == FollowAxis.X)
             newPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
         else if (chooseAxis == FollowAxis.Y)
             newPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
         else if (chooseAxis == FollowAxis.Z)
             newPos = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
         else if (chooseAxis == FollowAxis.XY)
             newPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
         else if (chooseAxis == FollowAxis.XZ)
             newPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
         else if (chooseAxis == FollowAxis.YZ)
             newPos = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);
         else
             newPos = player.transform.position;
        */

        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
    }
}
