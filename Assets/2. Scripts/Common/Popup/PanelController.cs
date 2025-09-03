using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class PanelController : MonoBehaviour
{
    private CanvasGroup background_canvas_group;

    [SerializeField] private RectTransform panel_rect_tf;

    public Action panel_hide_callback;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Awake()
    {
        this.background_canvas_group = this.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>  패널 표시 </summary>
    public void Show()
    {
        this.background_canvas_group.alpha = 0;
        panel_rect_tf.localScale = Vector3.zero;

        background_canvas_group.DOFade(1, 0.3f).SetEase(Ease.Linear);

        panel_rect_tf.DOScale(1, 0.3f).SetEase(Ease.OutBack);


    }

    /// <summary>  패기 숨기기 </summary>
    public void Hide(Action hide_act = null)
    {
        this.background_canvas_group.alpha = 1;
        panel_rect_tf.localScale = Vector3.one;

        background_canvas_group.DOFade(0, 0.3f).SetEase(Ease.Linear);

        panel_rect_tf.DOScale(1, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            hide_act?.Invoke();
        });

    }
}
