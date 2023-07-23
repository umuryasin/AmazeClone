using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    public BlockType blockType;

    public MeshRenderer renderer;
    private MaterialPropertyBlock _propertyBlock;

    private Tweener _winAnimTween;

    void Awake()
    {
        _propertyBlock = new MaterialPropertyBlock();
    }

    private void OnDestroy()
    {
        if (_winAnimTween.IsActive())
            _winAnimTween.Complete();
    }

    public void SetAsMarked(Color color)
    {
        renderer.GetPropertyBlock(_propertyBlock);
        _propertyBlock.SetColor("_Color", color);
        renderer.SetPropertyBlock(_propertyBlock);

        blockType = BlockType.Marked;
    }

    public void WinAnim(float delay, float time)
    {
        float posZ = transform.position.z;
        _winAnimTween = transform.DOMoveZ(posZ + 0.5f, time)
                        .SetDelay(delay)
                        .SetLoops(-1, LoopType.Yoyo);
    }

}

public enum BlockType
{
    Wall,
    UnMarked,
    Marked,
}
