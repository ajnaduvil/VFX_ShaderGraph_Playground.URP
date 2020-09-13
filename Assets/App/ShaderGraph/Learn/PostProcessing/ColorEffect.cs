using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(GrayscaleRenderer), PostProcessEvent.AfterStack, "Custom/ColorEffect")]
public sealed class ColorEffect : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Grayscale effect intensity.")]
    public TextureParameter texture = new TextureParameter();
}

public sealed class GrayscaleRenderer : PostProcessEffectRenderer<ColorEffect>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Shader Graphs/ColorEffect"));
        sheet.properties.SetTexture("_Input", context.camera.activeTexture);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
