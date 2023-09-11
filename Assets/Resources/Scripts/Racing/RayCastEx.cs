using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastEx : MonoBehaviour
{
    [Range(0, 50)]
    public float distance = 10.0f;
    private RaycastHit rayHit;
    private Ray ray;
    private RaycastHit[] rayHits;

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.forward;


    }

    // Update is called once per frame
    void Update()
    {
        Ray_4();
    }

    void Ray_4()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;

        rayHits = Physics.RaycastAll(ray, distance);

        for (int index = 0; index < rayHits.Length; index++)
        {
            if (rayHits[index].collider.gameObject.layer == LayerMask.NameToLayer("Cube"))
                Debug.Log(rayHits[index].collider.gameObject.name + " hit!!");
            if (rayHits[index].collider.gameObject.tag == "Sphere")
                Debug.Log(rayHits[index].collider.gameObject.name + " hit!! - Tag");
        }
    }

    void Ray_3()
    {
        rayHits = Physics.SphereCastAll(ray, 2.0f, distance);
        string objName = "";
        foreach (RaycastHit hit in rayHits)
            objName += hit.collider.name + " , ";
        print(objName);
    }

    void Ray_2()
    {
        rayHits = Physics.RaycastAll(ray, distance);

        for(int index = 0; index < rayHits.Length; index++) 
        {
            Debug.Log(rayHits[index].collider.gameObject.name + " hit!!");    
        }
    }

    void Ray_1()
    {
        if (Physics.Raycast(ray.origin, ray.direction, out rayHit, distance))
        {
            Debug.Log(rayHit.collider.gameObject.name);
        };
    }

    private void OnDrawGizmos()
    {
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        Gizmos.DrawLine(ray.origin, ray.direction * distance + ray.origin);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(ray.origin, 0.1f);

        if(this.rayHits != null)
        {
            for (int i = 0; i < this.rayHits.Length; i++) 
            {
                // : collision point
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(this.rayHits[i].point, 0.1f);

                // : draw line
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(this.transform.position, transform.forward * rayHits[i].distance + ray.origin);
            
                // : normal vector
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(this.rayHits[i].point, this.rayHits[i].point + this.rayHits[i].normal);

                // : reflection vector
                Gizmos.color = new Color(1.0f, 0.0f, 1.0f);
                Vector3 reflect = Vector3.Reflect(this.transform.forward, this.rayHits[i].normal);

                Gizmos.DrawLine(this.rayHits[i].point, rayHits[i].point + reflect);

            }
        }
    }
}
