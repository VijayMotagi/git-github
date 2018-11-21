using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace KeywordsDriver
{
   public static class FrameworkSettings
    {
      public static  bool RunParentScenarionSheet = false;

      public static string ChildScenarioSheetName = string.Empty;

      public static int ExecutionSheetActiveWorksheetIndex = 0;

      public static string TestExecutionSheetFilePath = string.Empty;

      public static string TestResultFolderPath = string.Empty;

      public static void ScreenShotsCapture(string fileName)
      {
          string filePath = FrameworkSettings.TestResultFolderPath + "\\" + fileName;

          Rectangle totalSize = Rectangle.Empty;
          foreach (Screen s in Screen.AllScreens)
          totalSize = Rectangle.Union(totalSize, s.Bounds);

          Bitmap screenShotBMP = new Bitmap(totalSize.Width, totalSize.Height, PixelFormat.Format32bppPArgb);

          Graphics screenShotGraphics = Graphics.FromImage(screenShotBMP);

          screenShotGraphics.CopyFromScreen(totalSize.X, totalSize.Y, 0, 0, totalSize.Size, CopyPixelOperation.SourceCopy);

          screenShotGraphics.Dispose();
          screenShotBMP.Save(filePath, ImageFormat.Jpeg);

      }
    }
}
