using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConst
{
    public const string OnePanel = "OnePanel";
}

public class UIManager
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    private Transform _uiRoot;
    public Transform UIRoot
    {
        get
        {
            if (_uiRoot == null)
            {
                _uiRoot = GameObject.Find("UIRoot").transform;
                return _uiRoot;
            }
            return _uiRoot;
        }
    }

    // ·�������ֵ�
    private Dictionary<string, string> pathDict;

    private UIManager()
    {
        InitDicts();
    }

    // Ԥ�Ƽ������ֵ�
    private Dictionary<string, GameObject> prefabDict;
    // �Ѵ򿪽���Ļ����ֵ�
    public Dictionary<string, BasePanel> panelDict;

    private void InitDicts()
    {
        prefabDict = new Dictionary<string, GameObject>();
        panelDict = new Dictionary<string, BasePanel>();
        pathDict = new Dictionary<string, string> { 
            { UIConst.OnePanel, "OnePanel"},
        };
        // ...
    }

    public BasePanel OpenPanel(string name)
    {
        BasePanel panel = null;
        // ����Ƿ��Ѵ�
        if (panelDict.TryGetValue(name, out panel))
        {
            Debug.LogError("�����Ѵ�: " + name);
            return null;
        }

        // ���·���Ƿ�����
        string path = "";
        if (!pathDict.TryGetValue(name, out path))
        {
            Debug.LogError("�������ƴ��󣬻�δ����·��: " + name);
            return null;
        }

        // ʹ�û���Ԥ�Ƽ�
        GameObject panelPrefab = null;
        if (!prefabDict.TryGetValue(name, out panelPrefab))
        {
            string realPath = "UI/Prefabs/Panel/" + path;
            panelPrefab = Resources.Load<GameObject>(realPath) as GameObject;
            prefabDict.Add(name, panelPrefab);
        }

        // �򿪽���
        GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
        panel = panelObject.GetComponent<BasePanel>();
        panelDict.Add(name, panel);
        panel.SetParent(UIRoot);
        panel.OpenPanel(name);
        return panel;
    }

    public bool ClosePanel(string name)
    {
        BasePanel panel = null;
        if (!panelDict.TryGetValue(name, out panel))
        {
            Debug.LogError("����δ��: " + name);
            return false;
        }

        panel.ClosePanel();
        return true;
    }

}