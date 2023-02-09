using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    public RectTransform rectTransfrom;

    public static UIMgr Instance
    {
        get;
        private set;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetRectangle(Vector2 pos,Vector2 size)
    {
        rectTransfrom.gameObject.SetActive(true);//显示对象
        rectTransfrom.position = pos;//中心点位置赋值
        rectTransfrom.sizeDelta = size;//长宽赋值
    }

    public void HideRectangle()
    {
        //隐藏对象
        rectTransfrom.gameObject.SetActive(false);
    }
}
