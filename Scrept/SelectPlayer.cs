using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectPlayer : MonoBehaviour
{
    private bool _isDrang;
    private Vector3 _startPos;
    private Vector3 _endPos;
    private Rect _selectRect;

    private List<Solider> selectSoliderList = new List<Solider>();
    

    void Start()
    {
       
    }

   
    void Update()
    {   //鼠标左击款选
        Projector();
        //鼠标右击选中
        ProSessetmont();
    }

    private void ProSessetmont()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //射线选中对象
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out  var  hit,1000))
            {
                if (hit.transform.tag=="enpty")
                {
                    var s = hit.point;
                
                    Debug.Log(s);
                
                    foreach (var solider in selectSoliderList)
                    {
                        solider.SetNavPlayer(s);
                        Transform hits = hit.transform;
                        //携程播放动画
                        solider.PlayAnitimation(true,hits);
                    }
                    
                    

                }
                else
                {
                    //导航到指定位置
                    var s = hit.point;
                                    
                     Debug.Log(s);
                                    
                     foreach (var solider in selectSoliderList)
                     {
                         solider.SetNavPlayer(s);
                     }
                }
            }
        }
    }

    void Projector()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            _isDrang = true;
            _startPos = Input.mousePosition;
        }

        if (_isDrang)
        {
            _endPos = Input.mousePosition;
            
            Vector2 center=(_startPos+_endPos)/2; //中心的位置
            var size = new Vector2(Mathf.Abs(_endPos.x-_startPos.x),Mathf.Abs(_endPos.y-_startPos.y));//绝对值算边框 长 宽
            UIMgr.Instance.SetRectangle(center,size);//这个目标对象要做单例
            _selectRect= new Rect(center-size/2,size);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isDrang = false;
            UIMgr.Instance.HideRectangle();

            ClearSelectionList();
            
            var  allUnity=GameMgr.Instance.GetAllSelectsUnites();
            var mainCamera = Camera.main;
            foreach (var unit in allUnity)
            {
                var screenPos =mainCamera.WorldToScreenPoint(unit.position);
                if (_selectRect.Contains(screenPos))
                {
                    Debug.Log(unit.name);
                    var s=unit.GetComponent<Solider>();
                    
                    
                    AddSelectpersonList(s);
                }
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out  var  hit,1000,1<<8))
            {
                var s=hit.transform.GetComponent<Solider>();
                
                if (s!=null)
                {
                    AddSelectpersonList(s);
                }

            }
            
        }
    }

   
    //刷新 清空状态，选中框和选中的对象
    private void ClearSelectionList()
    {
        foreach (Solider s in selectSoliderList)
        {
            s.Selecttion(false);
        }
        
        selectSoliderList.Clear();
        
    }
    //显示光圈 添加选中对象
    private void AddSelectpersonList(Solider unit)
    {
        unit.Selecttion(true);
        selectSoliderList.Add(unit);
        
    }

  
}
