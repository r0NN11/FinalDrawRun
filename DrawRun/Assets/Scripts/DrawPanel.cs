using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[RequireComponent(typeof(GameRules))]
public class DrawPanel : MonoBehaviour
{
    [SerializeField] private GameObject _drawPanel;
    private GameRules _gameRules;
    private void Start()
    {
        _gameRules = GetComponent<GameRules>();
        _gameRules.OnGameOver.AddListener(DeactivateDrawPanel);
        _gameRules.OnLevelEnd.AddListener(DeactivateDrawPanel);
    }
    private void DeactivateDrawPanel()
    {
        _drawPanel.SetActive(false);
    }
    public bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrent = new PointerEventData(EventSystem.current);
        eventDataCurrent.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrent, results);
        foreach (RaycastResult r in results)
        {
            bool isUIClicked = r.gameObject.transform.IsChildOf(_drawPanel.transform);
            if (isUIClicked)
            {
                return true;
            }
        }
        return false;
    }
}
