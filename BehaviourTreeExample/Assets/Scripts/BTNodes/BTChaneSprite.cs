using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTChaneSprite : BTBaseNode
{
    private Image imageHolder;
    private Sprite sprite;

    public BTChaneSprite(Image _imageHolder, Sprite _sprite)
    {
        imageHolder = _imageHolder;
        sprite = _sprite;

    }
    public override BTResult Run()
    {
        imageHolder.sprite = sprite;
        return BTResult.Success;
    }
}
