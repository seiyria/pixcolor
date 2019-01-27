
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

public class Startup
{
  [DllImport("user32.dll")]
  static extern IntPtr GetDC(IntPtr hwnd);

  [DllImport("user32.dll")]
  static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

  [DllImport("gdi32.dll")]
  static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

  static public string GetPixelColor(int x, int y)
  {
    IntPtr hdc = GetDC(IntPtr.Zero);
    uint pixel = GetPixel(hdc, x, y);
    ReleaseDC(IntPtr.Zero, hdc);
    int r = (int)(pixel & 0x000000FF);
    int g = (int)(pixel & 0x0000FF00) >> 8;
    int b = (int)(pixel & 0x00FF0000) >> 16;
    return r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
  }

  public async Task<object> Invoke(Object[] xy)
  {
    return GetPixelColor((int)xy[0], (int)xy[1]);
  }
}