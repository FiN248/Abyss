// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Fungus;



// public class objectDistance : MonoBehaviour
// {
//     public GameObject Play;
//     public GameObject Barrel_1;
//     public Flowchart ObInteraction;
//     public Flowchart Vars;
//     public int a;
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         a = 1;
//         ObInteraction = GameObject.Find("ObjectInteraction").GetComponent<Flowchart>();
//         Vars = GameObject.Find("Vars").GetComponent<Flowchart>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (GetModelDistance() < 1 && a ==1)    //take place only once
//         {
//             Barrel_1.transform.Find("mouse_right").gameObject.SetActive(true);
//             //Barrel_1.AddComponent<Fungus.Clickable2D>();
//             Vars.SetIntegerVariable("test",a);
//             a = 0;

//         }
//         else if (GetModelDistance() >= 1 && a == 0)
//         {
//             Barrel_1.transform.Find("mouse_right").gameObject.SetActive(false);
//             //Destroy(Barrel_1.transform.GetComponent<Fungus.Clickable2D>());
//             Vars.SetIntegerVariable("test",a);
//             a = 1;
//         }
//     }

//     float GetModelDistance()
//     {
//         float result = 999999;
//         if (Play != null && Barrel_1 != null  )
//         {
            

//             Vector2 position1 = Play.transform.position;
//             Vector2 position2 = Barrel_1.transform.position;

//             float _distance = Vector2.Distance(position1, position2);

//             result = _distance;
            
//         }
//         return result;
//     }
// }
