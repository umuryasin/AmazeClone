using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    public BlockType blockType;

    public MeshRenderer renderer;
    private MaterialPropertyBlock propertyBlock;

    void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();
    }

    public void SetAsMarked(Color color)
    {
        renderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetColor("_Color", color);
        renderer.SetPropertyBlock(propertyBlock);

        blockType = BlockType.Marked;
    }

}

public enum BlockType
{
    Wall,
    UnMarked,
    Marked,
}
