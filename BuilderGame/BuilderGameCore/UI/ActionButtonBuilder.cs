using SBad.Visual.Sprites;
using SBad.Visual.UI.Buttons;

namespace BuilderGameCore.UI
{
    public class ActionButtonBuilder : ButtonBuilder
    {
        private readonly TextureFrameStore _textureFrames;
        public ActionButtonBuilder(TextureFrameStore textureFrames)
        {
            _textureFrames = textureFrames;
        }

        public override IButtonBuilder SetClickAnimation() => SetClickAnimation("button-click");
        public override IButtonBuilder SetHoverAnimation() => SetHoverAnimation("button-hover");
        public override IButtonBuilder SetSize() => SetSize(96, 96);
        public override IButtonBuilder SetVisual() => SetTextureFrame("button", _textureFrames);
    }
}
