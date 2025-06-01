using Microsoft.AspNetCore.Mvc;
using System.Drawing;


namespace BeanSceneApp.Controllers
{
    public class GraphicsController : Controller
    {
        Pen pen;
        Brush brush;
        Brush brush2;
        Brush brush3;

        public GraphicsController()
        {
            pen = new Pen(Color.Black, 2);
            brush = new SolidBrush(Color.Blue);
            brush2 = new SolidBrush(Color.Aquamarine);
            brush3 = new SolidBrush(Color.Green);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GenerateCircle()
        {
            int width = 200;
            int height = 200;
            using (var bitmap = new Bitmap(width, height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    //graphics.Clear(Color.White);
                    graphics.FillEllipse(brush, 0, 0, width, height);
                    graphics.DrawEllipse(pen, 0, 0, width, height);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Seek(0, SeekOrigin.Begin);
                    return File(ms.ToArray(), "image/png");
                }
            }
        }
        public IActionResult GenerateRectangle()
        {
            int width = 200;
            int height = 200;
            using (var bitmap = new Bitmap(width, height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);
                    graphics.FillRectangle(brush2, 0, 0, width, height);
                    graphics.DrawRectangle(pen, 0, 0, width, height);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Seek(0, SeekOrigin.Begin);
                    return File(ms.ToArray(), "image/png");
                }
            }
        }
        public IActionResult GenerateTriangle()
        {
            int width = 200;
            int height = 200;
            using (var bitmap = new Bitmap(width, height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                   // graphics.Clear(Color.);
                    Point[] points = new Point[]
                    {
                        new Point(0, 0),
                        new Point(width, 0),
                        new Point(width/2, height),
                    };
                    graphics.FillPolygon(brush3, points);
                    graphics.DrawPolygon(pen, points);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Seek(0, SeekOrigin.Begin);
                    return File(ms.ToArray(), "image/png");
                }
            }

        }
    }
}
