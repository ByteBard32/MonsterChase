using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX,maxX;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    //Lateupdate is called when all calculations in update() function are finished
    void LateUpdate()
    {
        //using this because player is destroyhe but we keep accesing its position in
        // line27 onward
        if (player==null)
        {
            return;
        }
        //current position of the camera 
        tempPos=transform.position;
        //now take current postion x value aand store it to player x axis comp value
        tempPos.x=player.position.x;
        //comparing player position with some position taqa camera sirf ak jagah tak follow kara player ko      ****now remain is in 35 line**
        if(tempPos.x<minX){
            tempPos.x=minX;
        }
        if (tempPos.x>maxX)
        {
            tempPos.x=maxX;
        }
        //after storing current position assign that value back to the current position of the camera 
        transform.position=tempPos;
    }
}

