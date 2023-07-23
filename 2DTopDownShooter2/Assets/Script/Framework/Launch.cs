using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{

    /// <summary>
    /// 单例解决重复创建物体
    /// </summary>
    private static Launch _instance;
    public static Launch Instance { get { return _instance; } }

    public GameObject UIRoot;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject); return;
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        //切换场景不会被销毁
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(UIRoot);

        InitUIRoot();

        UIManager.Instance.OpenPanel(UIConst.OnePanel);
    }

    void InitUIRoot() {
        string[] enumNames = Enum.GetNames(typeof(UILevel));
        foreach (var level in enumNames)
        {
            GameObject temp = new GameObject(level);
            temp.transform.SetParent(UIRoot.transform, false);
        }
    }
}
