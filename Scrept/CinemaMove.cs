using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinemaMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //鼠标的y>屏幕的高
        if (Input.mousePosition.y>=Screen.height)
        {
            //相机位置+=向前
            transform.position+=Vector3.forward*Time.deltaTime;
        }       //如果鼠标的y<=0
        else if (Input.mousePosition.y<=0)
        {
            // //相机位置+=向后
            transform.position+=Vector3.back*Time.deltaTime;
        }
            //鼠标的x>屏幕的宽
        if (Input.mousePosition.x>=Screen.width)
        {   //相机位置+=向右
            transform.position+=Vector3.right*Time.deltaTime;
        }   //鼠标的x<0
        else if (Input.mousePosition.x<=0)
        {   //相机位置+=向左
            transform.position+=Vector3.left*Time.deltaTime;
        }

        //使用wasd向四个方向进行移动
        transform.position += Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical");
        transform.position += Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal");


    }
}
