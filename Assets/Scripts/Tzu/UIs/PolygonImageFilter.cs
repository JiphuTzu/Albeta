using UnityEngine;
using UnityEngine.UI;
///====================================
///接受异形的Image。忽略透明度在ignoreAlpha及以下的像素
///Image Settings中的Read/Write enabled 要设置为true。
///Image属性SpriteMode为Single，Raycast Target 取消勾选
///====================================
namespace Tzu.UIs
{
    [RequireComponent(typeof(Image))]
    public class PolygonImageFilter : MonoBehaviour, ICanvasRaycastFilter
    {
        [Range(0, 1)]
        public float ignoreAlpha = 0;
        private Image _image;
        private RectTransform _rectTrans;

        private void Start()
        {
            _image = GetComponent<Image>();
            _rectTrans = _image.rectTransform;
        }
        // Parameters:
        //   sp:
        //     Screen position.
        //
        //   eventCamera:
        //     Raycast camera.
        public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
        {
            if (!enabled) return true;
            Sprite sprite = _image.overrideSprite;
            if (sprite == null) return true;

            Vector2 local;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTrans, sp, eventCamera, out local);
            Rect rect = _rectTrans.rect;
            Vector2 pivot = _rectTrans.pivot;
            // Convert to lower left corner as reference point.
            local.x += pivot.x * rect.width;
            local.y += pivot.y * rect.height;

            float u = local.x / rect.width;
            float v = local.y / rect.height;

            return sprite.texture.GetPixelBilinear(u, v).a > ignoreAlpha;
        }
    }
}