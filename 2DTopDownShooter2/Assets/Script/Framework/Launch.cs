using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{

    /// <summary>
    /// ��������ظ���������
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
        //�л��������ᱻ����
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
