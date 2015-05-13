using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace leavemessage
{
    public partial class yzm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string yzm = string.Empty;
            Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
            string[] font = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };
            char[] character = { '2', '3', '4', '5', '6', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                yzm += character[rand.Next(character.Length)];
            }
            Bitmap bmp = new Bitmap(100, 40);
            Graphics g = Graphics.FromImage(bmp);
            Color c = System.Drawing.ColorTranslator.FromHtml("#EDF8FE");
            g.Clear(c);
            for(int i = 0; i < 10; i++)
            {
                int x1 = rand.Next(100);
                int y1 = rand.Next(40);
                int x2 = rand.Next(100);
                int y2 = rand.Next(40);
                Color col = color[rand.Next(color.Length)];
                g.DrawLine(new Pen(col), x1, y1, x2, y2);
            }
            for(int i=0; i < yzm.Length; i++)
            {
                string fnt = font[rand.Next(font.Length)];
                Font ft = new Font(fnt, 18);
                Color col = color[rand.Next(color.Length)];
                g.DrawString(yzm[i].ToString(), ft, new SolidBrush(col), (float)i * 20 + 8, (float)8);
            }
            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(bmp.Width);
                int y = rand.Next(bmp.Height);
                Color col = color[rand.Next(color.Length)];
                bmp.SetPixel(x, y, col);
            }
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);

            Response.ClearContent();
            Response.ContentType = "image/Png";
            Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            bmp.Dispose();
            Response.End();
        }
    }
}