using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static WaveUIController;

public class WaveSkipUIPanel : MonoBehaviour, ISwitchableUI
{
    [SerializeField] private Button _skipButton;
    [SerializeField] private Button _cancelButton;

    private IEventContainer<ActionType> _event;

    private void Awake()
    {
        _skipButton.onClick.AddListener(HandleSkip);
        _cancelButton.onClick.AddListener(HandleCancel);
    }

    /// <summary>
    /// 모델 받아오기
    /// </summary>
    /// <param name="evt">모델</param>
    public void SetUp(IEventContainer<ActionType> evt)
    {
        _event = evt;
    }

    /// <summary>
    /// 웨이브 스킵하기 버튼
    /// </summary>
    private void HandleSkip()
    {
        _event.NotifyEvent(ActionType.Skip);
        HideUI();
    }

    /// <summary>
    /// 웨이브 스킵 취소 버튼
    /// </summary>
    private void HandleCancel()
    {
        HideUI();
    }

    /// <summary>
    /// UI 켜기
    /// </summary>
    public void ShowUI()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// UI 끄기
    /// </summary>
    public void HideUI()
    {
        gameObject.SetActive(false);
    }
}