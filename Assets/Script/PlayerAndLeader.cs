using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndLeader : MonoBehaviour
{   
    public GameObject Leader;
    public int a;

    void Start(){
        a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        

        

        if (GetLeaderDistance() <= 2 && a == 1){
            mouseAppear(Leader);
        }

        if(GetLeaderDistance() > 2 && a == 0){
            mouseDisap(Leader);
        }

        
    }

    float GetLeaderDistance(){
        float result = 99999;

        if(Leader != null){
            Vector2 position1 = transform.position;
            Vector2 position2 = Leader.transform.position;

            float _distance = Vector2.Distance(position1, position2);

            result = _distance;
        }

        return result;
    }

    void mouseAppear(GameObject other)
    {
        other.transform.Find("mouse_left").gameObject.SetActive(true);
        a = 0;
    }

    void mouseDisap(GameObject other)
    {
        other.transform.Find("mouse_left").gameObject.SetActive(false);
        a = 1;
    }
}
