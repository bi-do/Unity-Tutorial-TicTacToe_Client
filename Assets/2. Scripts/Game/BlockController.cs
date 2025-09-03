using System;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private Block[] blocks;

    public Action<int, int> on_block_click_callback;

    public void InitBlocks()
    {
        int cnt = 0;
        foreach (Block element in blocks)
        {
            element.InitMarker(cnt, BlcokClickCallback);
            cnt++;
        }
    }

    private void BlcokClickCallback(int param_idx)
    {
        int row = param_idx / Constants.BlcokColumnCount;
        int col = param_idx % Constants.BlcokColumnCount;

        this.on_block_click_callback?.Invoke(row, col);
    }

    public void PlaceMarker(Block.MarkerType maker_t, int row , int col)
    {
        int block_idx = row * Constants.BlcokColumnCount + col;
        blocks[block_idx].Marking(maker_t);
    }

    public void SetBlockColor()
    {
        //  TODO: 게임 로직 완성시 구현
    }

}
