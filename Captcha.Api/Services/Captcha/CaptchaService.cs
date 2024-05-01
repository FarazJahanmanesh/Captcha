using Captcha.Api.Interfaces;using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Captcha.Api.Services.Captcha;

public class CaptchaService: ICaptchaService
{
    public string GenerateCaptcha(string captchaStr)
    {
        int height = 30;
        int width = 70;
        Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        Graphics g = Graphics.FromImage(bmp);

        g.Clear(Color.White);
        Pen blackPen = new Pen(Color.Orange, 2);
        Random generator = new Random();
        int randomNumberX1 = generator.Next(42, 69);
        int randomNumberY1 = generator.Next(2, 13);
        int randomNumberX2 = generator.Next(5, 28);
        int randomNumberY2 = generator.Next(17, 29);
        g.DrawLine(blackPen, randomNumberX1, randomNumberY1, randomNumberX2, randomNumberY2);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.Low;
        Brush[] colors = new Brush[5];
        colors[0] = Brushes.DarkRed;
        colors[1] = Brushes.DarkBlue;
        colors[2] = Brushes.Black;
        colors[3] = Brushes.DarkCyan;
        colors[4] = Brushes.DarkGreen;
        Random g1 = new Random();
        for (int i = 0; i < captchaStr.Length; i++)
        {
            RectangleF rectf = new RectangleF(5 + i * 9, 5 + i, 0, 0);
            int rn1 = g1.Next(0, 5);
            Brush cl1 = colors[rn1];
            g.DrawString(captchaStr.Substring(i, 1), new System.Drawing.Font("Thaoma", 12 + (i - 2), FontStyle.Italic), cl1, rectf);
        }

        Pen penR = new Pen(Color.White);
        penR.Width = 1;
        g.DrawRectangle(penR, 1, 1, width - 2, height - 2);
        g.Dispose();
        System.IO.MemoryStream ms = new MemoryStream();
        bmp.Save(ms, ImageFormat.Jpeg);
        byte[] byteImage = ms.ToArray();
        var SigBase64 = Convert.ToBase64String(byteImage);
        ms.Close();
        bmp.Dispose();
        return SigBase64;
    }
}
