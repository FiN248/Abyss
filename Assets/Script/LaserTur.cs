using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTur : MonoBehaviour
{   
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firepoint;
    public GameObject startVFX;
    public GameObject endVFX;   

    private Quaternion rotation;
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    // Start is called before the first frame update
    void Start()
    {   
        FillLists();
        DisableLaser();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            EnableLaser();
        }

        if(Input.GetButton("Fire1")){
            UpdateLaser();
        }     

        if(Input.GetButtonUp("Fire1")){
            DisableLaser();
        }

        RotateToMouse();   
    }

    void EnableLaser(){
        lineRenderer.enabled = true;

        for(int i=0; i<particles.Count; i++){
            particles[i].Play();
        }

    }

    void UpdateLaser(){
        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

        transform.position = firepoint.position;
        lineRenderer.SetPosition(0,firepoint.position);
        startVFX.transform.position = (Vector2)firepoint.position;
        lineRenderer.SetPosition(1, mousePos);

        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude);

        if(hit){
            lineRenderer.SetPosition(1, hit.point);
        }

        endVFX.transform.position = lineRenderer.GetPosition(1);
    }

    void DisableLaser(){
        lineRenderer.enabled = false;

        for(int i=0; i<particles.Count; i++){
            particles[i].Stop();
        }
    }

    void RotateToMouse(){
        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition);
        
        float angle = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg;

        rotation.eulerAngles = new Vector3(0,0,angle);

        transform.rotation = rotation;
    }

    void FillLists(){

        for(int i=0; i< startVFX.transform.childCount; i++){
            var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps != null){
                particles.Add(ps);
            }
        }
        for(int i=0; i< endVFX.transform.childCount; i++){
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps != null){
                particles.Add(ps);
            }
        }
    }

    
}
