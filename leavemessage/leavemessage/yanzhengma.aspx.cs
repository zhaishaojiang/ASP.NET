using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace leavemessage
{
    public partial class yanzhengma : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            string yzm = string.Empty;
            Color[] color = { Color.Black, Color.Blue, Color.Red, Color.Gray, Color.Green, Color.Orange };
            string[] font = { "Helvetica", "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };
            char[] character = { '2', '3', '4', '5', '6', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            { 
                yzm+=character[rand.Next(character.Length)];
            }
            Bitmap bmp = new Bitmap(100, 40);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            for (int i = 0; i < 10; i++)
            {
                int x1 = rand.Next(bmp.Width);
                int y1 = rand.Next(bmp.Height);
                int x2 = rand.Next(bmp.Width);
                int y2 = rand.Next(bmp.Height);
                Color col=color[rand.Next(color.Length)];
                graphics.DrawLine(new Pen(col), x1, y1, x2, y2);
            }
            for (int i = 0; i < 4; i++)
            {
                string fnt = font[rand.Next(font.Length)];
                Font ft = new Font(fnt, 18);
                Color col = color[rand.Next(color.Length)];
                graphics.DrawString(yzm[i].ToString(), ft, new SolidBrush(col), (float)i * 20 + 8, (float)8);
            }
            for (int i = 0; i < 80; i++)
            {
                int x = rand.Next(bmp.Width);
                int y = rand.Next(bmp.Height);
                Color col = color[rand.Next(color.Length)];
                bmp.SetPixel(x, y, col);
            }
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);
            Response.ClearContent();
            Response.ContentType = "image/png";
            Response.BinaryWrite(ms.ToArray());
            graphics.Dispose();
            bmp.Dispose();
            Response.End();
        }
    }
}