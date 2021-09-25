using DevExpress.Skins;
using DevExpress.Skins.XtraForm;
using DevExpress.Utils;
using System.Drawing;
using System.Windows.Controls;
public partial class XtraFormCenterText : DevExpress.XtraEditors.XtraForm
{
    protected override DevExpress.Skins.XtraForm.FormPainter CreateFormBorderPainter()
    {
        HorzAlignment formCaptionAlignment = HorzAlignment.Center;
        return new CustomFormPainter(this, LookAndFeel, formCaptionAlignment);
    }
}
public class CustomFormPainter : FormPainter
{
    public CustomFormPainter(XtraFormCenterText owner, DevExpress.Skins.ISkinProvider provider)
        : base(owner, provider)
    {
    }
    public CustomFormPainter(XtraFormCenterText owner, DevExpress.LookAndFeel.UserLookAndFeel provider, HorzAlignment captionAlignment)
        : base(owner, provider)
    {
        CaptionAlignment = captionAlignment;
    }
    private HorzAlignment _CaptionAlignment = HorzAlignment.Default;
    public HorzAlignment CaptionAlignment
    {
        get
        {
            return _CaptionAlignment;
        }
        set
        {
            _CaptionAlignment = value;
        }
    }
    protected override void DrawText(DevExpress.Utils.Drawing.GraphicsCache cache)
    {
        string text = Text;
        if (text == null || text.Length == 0 || TextBounds.IsEmpty)
        {
            return;
        }
        AppearanceObject appearance = new AppearanceObject(GetDefaultAppearance());
        appearance.TextOptions.Trimming = Trimming.EllipsisCharacter;
        appearance.TextOptions.HAlignment = CaptionAlignment;
        if (AllowHtmlDraw)
        {
            DrawHtmlText(cache, appearance);
            return;
        }
        Rectangle r = RectangleHelper.GetCenterBounds(TextBounds, new Size(TextBounds.Width, CalcTextHeight(cache.Graphics, appearance)));
        DrawTextShadow(cache, appearance, r);
        cache.DrawString(text, appearance.Font, appearance.GetForeBrush(cache), r, appearance.GetStringFormat());
    }
}