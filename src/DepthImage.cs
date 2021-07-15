using nuitrack;
using VL.Lib.Basics.Imaging;
using System.Runtime.InteropServices;

namespace VL.Devices.Nuitrack
{
    // Exposes the kinect frame buffer directly
    public class DepthImage : IImage
    {
        public readonly DepthFrame Frame;
        private readonly ArrayImage<byte> image;

        public DepthImage(DepthFrame frame)
        {
            Frame = frame;
            Info = new ImageInfo(frame.Cols, frame.Rows, PixelFormat.R16);
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
