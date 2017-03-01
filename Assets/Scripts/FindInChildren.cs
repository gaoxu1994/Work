using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 寻找子物体
/// </summary>
public class FindInChildren : MonoBehaviour
{
    public static FindInChildren find = null;
    // Use this for initialization
    void Awake()
    {
        if (find == null)
        {
            find = this;
        }
    }
    /// <summary>
    /// 获取GameObject
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject GameObject(string name)
    {
        return GameObject(gameObject, name);
    }

    public Image Image(string name)
    {
        return GameObject(name).GetComponent<Image>();
    }

    /// <summary>
    /// 获取Button
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Button Button(string name)
    {
        return GameObject(name).GetComponent<Button>();
    }
    /// <summary>
    /// 获取Text
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Text Text(string name)
    {
        return GameObject(name).GetComponent<Text>();
    }
    /// <summary>
    /// 获取Transform
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Transform Transform(string name)
    {
        return GameObject(name).transform;
    }
    /// <summary>
    /// 获取GameObject
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject GameObject(GameObject parent, string name)
    {
        if (parent.name == name)
        {
            return parent;
        }
        if (parent.transform.childCount < 1)
        {
            return null;
        }
        GameObject obj = null;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject go = parent.transform.GetChild(i).gameObject;
            obj = GameObject(go, name);
            if (obj != null)
            {
                break;
            }
        }
        return obj;
    }


    public Image Image(GameObject parent , string name)
    {
        return GameObject(parent, name).GetComponent<Image>();
    }

    /// <summary>
    /// 获取Button
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Button Button(GameObject parent, string name)
    {
        return GameObject(parent, name).GetComponent<Button>();
    }
    /// <summary>
    /// 获取Text
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Text Text(GameObject parent, string name)
    {
        return GameObject(parent, name).GetComponent<Text>();
    }
    /// <summary>
    /// 获取Transform
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Transform Transform(GameObject parent, string name)
    {
        return GameObject(parent, name).transform;
    }
}
