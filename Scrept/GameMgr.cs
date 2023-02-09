using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    //单例
        public  static  GameMgr Instance 
        {   get; 
            private set; }

        public Transform Solider;//挂载父级对象
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //框选获取对象组件
    public Transform[] GetAllSelectsUnites()
    {
        List<Transform> result = new List<Transform>();
        foreach (Transform trans in Solider)
        {
            result.Add(trans);
        }
        
        return result.ToArray();
        //return Solider.Cast<Transform>().ToArray();
    }
}
