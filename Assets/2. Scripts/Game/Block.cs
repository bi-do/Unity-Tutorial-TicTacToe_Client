using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;

public class Block : MonoBehaviour
{
    public enum MarkerType { None, O, X }

    [SerializeField] private Sprite o_sprite;
    [SerializeField] private Sprite x_sprite;
    [SerializeField] private SpriteRenderer marker_renderer;

    private int block_idx;

    /// <summary> 블럭 자신의 BG 색을 변경하는 렌더러 </summary>
    private SpriteRenderer block_renderer;
    private Color default_block_color;

    public Action<int> on_block_click_act;

    public void InitMarker(int block_idx, Action<int> on_block_click_callback)
    {
        this.block_idx = block_idx;
        Marking(MarkerType.None);

        this.on_block_click_act = on_block_click_callback;
    }

    public void Marking(MarkerType param_type)
    {
        switch (param_type)
        {
            case MarkerType.None:
                break;
            case MarkerType.O:
                this.marker_renderer.sprite = o_sprite;
                break;
            case MarkerType.X:
                this.marker_renderer.sprite = x_sprite;
                break;
        }
    }

    public void SetBlockColor(Color color)
    {
        this.marker_renderer.color = color;
    }

    private void OnMouseUpAsButton()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        Debug.Log($"Selected Block : {this.block_idx}");
        on_block_click_act?.Invoke(this.block_idx);
    }

}
