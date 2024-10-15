using System.Collections;
using TMPro;
using UnityEngine;

public class WaveUIPanel : MonoBehaviour, ISwitchableUI
{
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private TextMeshProUGUI _timeText;

    private Coroutine _skipTimeCoroutine;
    private WaveSetting _model;

    /// <summary>
    /// 모델 받아오기
    /// </summary>
    /// <param name="model"></param>
    public void SetUp(WaveSetting model)
    {
        _model = model;

        int currentWave = model.CurrentWave;

        _waveText.text = $"{currentWave + 1} WAVE";
    }

    public void ShowUI()
    {
        _timeText.gameObject.SetActive(true);
    }

    public void HideUI()
    {
        _timeText.gameObject.SetActive(false);
    }

    /// <summary>
    /// 웨이브 타이머 외부 호출
    /// </summary>
    public void SkipCoolTime()
    {
        ShowUI();

        if (_skipTimeCoroutine != null)
            _skipTimeCoroutine = null;

        _skipTimeCoroutine = StartCoroutine(SkipTimeEventCoroutine());
    }

    /// <summary>
    /// 모델을 기반으로 웨이브 타이머 구현
    /// </summary>
    /// <returns></returns>
    private IEnumerator SkipTimeEventCoroutine()
    {
        float currentTime = _model.TimeToSkip;

        while (currentTime > 0)
        {
            if (!_timeText.gameObject.activeSelf) break;

            currentTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);

            _timeText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);

            yield return null;
        }

        HideUI();
        _timeText.text = "00:00";
    }
}