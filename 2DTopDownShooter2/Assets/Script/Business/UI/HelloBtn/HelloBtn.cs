using Assets.Scripts.Framework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct HelloArgs : IEventArgs
{
    public string Name;
}

public class HelloBtn : MonoBehaviour
{

    private void OnEnable()
    {
        // 无参监听
        EventSingle.Instance.AddListener(EventDefine.ClickHelloBtn, click);

        // 有参监听
        EventSingle.Instance.AddListener(EventDefine.ClickHelloBtn, clickWithArgs);

    }


    private void OnDisable()
    {
        // 无参取消监听
        EventSingle.Instance.RemoveListener(EventDefine.ClickHelloBtn, click);

        // 有参取消监听
        EventSingle.Instance.RemoveListener(EventDefine.ClickHelloBtn, clickWithArgs);
    }

    private void click()
    {
        Debug.Log("click");
    }

    private void clickWithArgs(IEventArgs args)
    {
        if (args is HelloArgs)
        {
            HelloArgs helloArgs = (HelloArgs)args;

            Debug.Log(helloArgs.Name);
        }
    }

    public void ClickBtn()
    {
        // 无参发送事件
        EventSingle.Instance.SendEvent(EventDefine.ClickHelloBtn);

        // 传参发送事件
        HelloArgs helloArgs = new HelloArgs();
        helloArgs.Name = "HelloA";
        EventSingle.Instance.SendEvent(EventDefine.ClickHelloBtn, helloArgs);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
