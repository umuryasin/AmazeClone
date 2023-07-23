using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    public BlockType blockType;

    public MeshRenderer renderer;
    private MaterialPropertyBlock _propertyBlock;

    void Awake()
    {
        _propertyBlock = new MaterialPropertyBlock();
    }

    public void SetAsMarked(Color color)
    {
        renderer.GetPropertyBlock(_propertyBlock);
        _propertyBlock.SetColor("_Color", color);
        renderer.SetPropertyBlock(_propertyBlock);

        blockType = BlockType.Marked;
    }

}

public enum BlockType
{
    Wall,
    UnMarked,
    Marked,
}
