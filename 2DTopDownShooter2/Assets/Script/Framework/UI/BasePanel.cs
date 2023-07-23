using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UILevel
{
    Base,
    Normal,
    High,
    Top
}

public class BasePanel : MonoBehaviour
{
    protected bool isRemove = false;
    protected new string name;
    public UILevel level;


    public virtual void SetParent(Transform uiRoot)
    {
        Transform parentTransform = uiRoot.Find(level.ToString());
        if (parentTransform != null)
        {
            transform.SetParent(parentTransform);
        }
        else transform.SetParent(uiRoot);
    }

    public virtual void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public virtual void OpenPanel(string name)
    {
        this.name = name;
        SetActive(true);
    }

    public virtual void ClosePanel()
    {
        isRemove = true;
        SetActive(false);
        Destroy(gameObject);

        if (UIManager.Instance.panelDict.ContainsKey(name))
        {
            UIManager.Instance.panelDict.Remove(name);
        }
    }
}