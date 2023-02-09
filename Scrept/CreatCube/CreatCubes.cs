using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCubes : MonoBehaviour
{

    public GameObject cube;
    public Camera cam;
    public void Creat()
    {
        cube=GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Renderer>().material.color = new Color(1,1,1,0.5f);
        Destroy(cube.GetComponent<BoxCollider>());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cube!=null)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit hit))
            {
                cube.transform.position = hit.point;
                if (hit.transform.CompareTag("Tree"))
                {
                    cube.GetComponent<Renderer>().material.color = new Color(1,0,0,0.5f);
                }
                else
                {
                    cube.GetComponent<Renderer>().material.color = new Color(0,1,0,0.5f);
                    if (Input.GetMouseButtonDown(0))
                    {
                        cube.GetComponent<Renderer>().material.color = Color.white;
                        cube = null;
                    }
                }
            }
        }
    }
}
