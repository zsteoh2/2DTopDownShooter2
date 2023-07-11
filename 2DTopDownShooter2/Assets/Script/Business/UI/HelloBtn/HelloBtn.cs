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
        // �޲μ���
        EventSingle.Instance.AddListener(EventDefine.ClickHelloBtn, click);

        // �вμ���
        EventSingle.Instance.AddListener(EventDefine.ClickHelloBtn, clickWithArgs);

    }


    private void OnDisable()
    {
        // �޲�ȡ������
        EventSingle.Instance.RemoveListener(EventDefine.ClickHelloBtn, click);

        // �в�ȡ������
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
        // �޲η����¼�
        EventSingle.Instance.SendEvent(EventDefine.ClickHelloBtn);

        // ���η����¼�
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
