using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDist : MonoBehaviour
{   
    public GameObject Door;
    public Animator DoorOpen;
    public GameObject ending;
    public GameObject BillBoard;
    public GameObject Leader;

    public int a;
    void Start(){
        a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetDoorDistance() <= 3 && GetDoorDistance() >= 1.5){
            DoorOpen.SetBool("nearDoor", true);
            Debug.Log("open");
        }

        if (GetDoorDistance() <= 1.5){
            ending.transform.Find("Panel").gameObject.SetActive(true);
        }

        if (GetBillBoardDistance() <= 2 && a == 1){
            mouseAppear(BillBoard);
        }

        if(GetBillBoardDistance() > 2 && a == 0){
            mouseDisap(BillBoard);
        }

        
    }

    float GetDoorDistance(){
        float result = 99999;

        if(Door != null){
            Vector2 position1 = transform.position;
            Vector2 position2 = Door.transform.position;

            float _distance = Vector2.Distance(position1, position2);

            result = _distance;
        }

        return result;
    }
    
    float GetBillBoardDistance(){
        float result = 99999;

        if(BillBoard != null){
            Vector2 position1 = transform.position;
            Vector2 position2 = BillBoard.transform.position;

            float _distance = Vector2.Distance(position1, position2);

            result = _distance;
        }

        return result;
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
