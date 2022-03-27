using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum UIState
{
    MainMenu,
    OptionMenu,
}
[System.Serializable]
public struct UIStateStruct
{
    public UIState m_State;
    public GameObject m_uiObject;
}
public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    [SerializeField]
    List<UIStateStruct> m_uiStates = new List < UIStateStruct > ();
    UIState m_currentUIState = UIState.MainMenu;
    public void SetUiState(UIState newState)
    {
        uiStateMap[m_currentUIState].SetActive(false);
        uiStateMap[newState].SetActive(true);
        m_currentUIState = newState;
    }
    Dictionary<UIState, GameObject> uiStateMap = new Dictionary<UIState, GameObject>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //Fill up Dictionary
        foreach(UIStateStruct uiStateStruct in m_uiStates)
        {
            uiStateMap.Add(uiStateStruct.m_State, uiStateStruct.m_uiObject);
        }
    }
}
