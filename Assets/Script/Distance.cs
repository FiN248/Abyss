using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Distance : MonoBehaviour
{   
    public GameObject Laserend;
    public GameObject Laserend2;
    public GameObject trigg;
    public GameObject Laser;
    public GameObject RoadLamp1;
    public GameObject RoadLamp2;
    public GameObject RoadLamp3;
    public GameObject RoadLamp4;
    public GameObject Statue;
    public Flowchart Variables;
    public Camera cam;
    public int a;
    private float main_time;

    // Start is called before the first frame update
    void Start()
    {
        Variables = GameObject.Find("Variables").GetComponent<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetDistance() <= 1.5 && isHit() && MouceLongPressLeft()){
            Debug.Log("trig");
            print("tgg");
        }

        if(GetRoadLampDistance1(RoadLamp1) <= 1.5 && isHit() && MouceLongPressLeft()){
            litOn(RoadLamp1);
            Variables.SetBooleanVariable("Lamp1",true);
        }
        if(GetRoadLampDistance2(RoadLamp1) <= 1.5 && isHit() && MouceLongPressRight()){
            litOff(RoadLamp1);
            Variables.SetBooleanVariable("Lamp1",false);
        }

        if(GetRoadLampDistance1(RoadLamp2) <= 1.5 && isHit() && MouceLongPressLeft()){
            litOn(RoadLamp2);
            Variables.SetBooleanVariable("Lamp2",true);
        }
        if(GetRoadLampDistance2(RoadLamp2) <= 1.5 && isHit() && MouceLongPressRight()){
            litOff(RoadLamp2);
            Variables.SetBooleanVariable("Lamp2",false);
        }

        if(GetRoadLampDistance1(RoadLamp3) <= 1.5 && isHit() && MouceLongPressLeft()){
            litOn(RoadLamp3);
            Variables.SetBooleanVariable("Lamp3",true);
        }
        if(GetRoadLampDistance2(RoadLamp3) <= 1.5 && isHit() && MouceLongPressRight()){
            litOff(RoadLamp3);
            Variables.SetBooleanVariable("Lamp3",false);
        }

        if(GetRoadLampDistance1(RoadLamp4) <= 1.5 && isHit() && MouceLongPressLeft()){
            litOn(RoadLamp4);
            Variables.SetBooleanVariable("Lamp4",true);
        }
        if(GetRoadLampDistance2(RoadLamp4) <= 1.5 && isHit() && MouceLongPressRight()){
            litOff(RoadLamp4);
            Variables.SetBooleanVariable("Lamp4",false);
        }

        if (GetStatueDistance() <= 1.5 && isHit() && MouceLongPressLeft()){
            Variables.SetBooleanVariable("Statue2Key",true);
        }

    }

    float GetDistance(){
        float result = 99999;

        if(trigg != null && Laserend != null){
            Vector2 position1 = trigg.transform.position;
            Vector2 position2 = Laserend.transform.position;

            float _distance = Vector2.Distance(position1, position2);

            result = _distance;
        }

        return result;
    }

    
    
    bool isHit(){
        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)Laser.transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)Laser.transform.position, direction.normalized, direction.magnitude);
        if (hit){
            return true;
        }else{
            return false;
        }
    }

    float GetRoadLampDistance1(GameObject RoadLamp){
        float result = 99999;
        if(RoadLamp != null && Laserend != null){
            Vector2 position1 = RoadLamp.transform.Find("Road Lamp Light On").transform.position;
            Vector2 position2 = Laserend.transform.position;
            

            float _distance = Vector2.Distance(position1, position2);

            result = _distance;
        }
        return result;

    }

    float GetStatueDistance(){
        float result = 99999;

        if( Statue != null && Laserend != null){
            Vector2 position1 = Statue.transform.position;
            Vector2 position2 = Laserend.transform.position;

            float _distance = Vector2.Distance(position1, position2);

            result = _distance;
        }

        return result;
    }

    float GetRoadLampDistance2(GameObject RoadLamp){
        float result = 99999;
        if(RoadLamp != null && Laserend != null){
            Vector2 position1 = RoadLamp.transform.Find("Road Lamp Light Off").transform.position;
            Vector2 position2 = Laserend2.transform.position;
            

            float _distance = Vector2.Distance(position1, position2);

            result = _distance;
        }
        return result;

    }

    
    
    void litOn(GameObject RoadLamp){
        RoadLamp.transform.Find("Road Lamp Light On").GetComponent<SpriteRenderer>().sortingOrder=1;
        RoadLamp.transform.Find("Road Lamp Light Off").GetComponent<SpriteRenderer>().sortingOrder=0;
    }

    void litOff(GameObject RoadLamp){
        RoadLamp.transform.Find("Road Lamp Light Off").GetComponent<SpriteRenderer>().sortingOrder=1;
        RoadLamp.transform.Find("Road Lamp Light On").GetComponent<SpriteRenderer>().sortingOrder=0;
    }

    bool MouceLongPressLeft(){

        if (Input.GetMouseButton(0)){
            if (main_time == 0.0f){
                main_time = Time.time;
                return false;
            }

            if (Time.time - main_time > 0.2f) {
                return true;
            }else{
                return false;
            }
        }
        return false;
    }

    bool MouceLongPressRight(){

        if (Input.GetMouseButton(1)){
            if (main_time == 0.0f){
                main_time = Time.time;
                return false;
            }

            if (Time.time - main_time > 0.2f) {
                return true;
            }else{
                return false;
            }
        }
        return false;
    }

}
