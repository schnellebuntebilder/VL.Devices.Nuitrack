using nuitrack;
using VL.Lib.Basics.Imaging;
using System.Runtime.InteropServices;

namespace VL.Devices.Nuitrack
{
    // Exposes the kinect frame buffer directly
    public class ColorImage : IImage
    {
        public readonly ColorFrame Frame;
        private readonly ArrayImage<byte> image;

        public ColorImage(ColorFrame frame)
        {
            Frame = frame;
            Info = new ImageInfo(frame.Cols, frame.Rows, PixelFormat.B8G8R8);
            byte[] temp = new byte[frame.DataSize];
            Marshal.Copy(frame.Data, temp, 0, frame.DataSize);
            image = new ArrayImage<byte>(temp, Info, true);
            temp = null;
        }

        public ImageInfo Info { get; }

        public bool IsVolatile => true;

        public IImageData GetData()
        {
            return image.GetData();
        }
    }
}
