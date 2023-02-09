using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Solider : MonoBehaviour
{
    // Start is called before the first frame update

    //这里是挂在人物对象身上的代码
    public Transform circle;
    private bool pas;
    private NavMeshAgent play;
    public Animator plays;
    
    void Start()
    {
       // Instance = this;
       //添加寻路组件
       play=gameObject.AddComponent<NavMeshAgent>();
       //移除刚体
       Destroy(gameObject.GetComponent<Rigidbody>());
       //动画
       plays = gameObject.GetComponent<Animator>();
       //找到光圈父级
       Transform fa=transform.Find("350.!Root");
       //找到光圈
        circle = fa.Find("ring");
        Selecttion(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //隐藏显示光圈
    public void Selecttion(bool b)
    {
        circle.gameObject.SetActive(b);
    }
    //导航到指定位置
    public void SetNavPlayer(Vector3 pos)
    {
        play.SetDestination(pos);
    }
    //播放动画
    public void PlayAnitimation(bool a,Transform hit)
    {

        if (a)
        {
            StartCoroutine(Plays(hit));
            
        }
        {
            plays.SetBool("playz",false);
        }
        
    }
    //延迟做一些操作，不重要
    IEnumerator Plays(Transform hit)
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            plays.SetBool("playz",true);
            yield return new WaitForSeconds(3f);
            Destroy(hit.transform.gameObject);
        }
    }
    
    
    
}
