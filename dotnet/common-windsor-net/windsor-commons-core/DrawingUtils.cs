#region License
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Basic helper functions for dealing with exceptions.
    /// </summary>
    public static class DrawingUtils
    {
        public static ImageCodecInfo GetImageCodec(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (String.Compare(codec.MimeType, mimeType, true) == 0)
                {
                    return codec;
                }
            }

            return null;
        }
        public static ImageCodecInfo GetImageCodec(ImageFormat format)
        {
            return GetImageCodec(ImageFormatToMimeType(format));
        }
        public static string ImageFormatToMimeType(ImageFormat format)
        {
            return "image/" + format.ToString().ToLower();
            //if (format == ImageFormat.Jpeg)
            //{
            //    return "image/jpeg";
            //}
            //if (format == ImageFormat.Png)
            //{
            //    return "image/png";
            //}
        }
        public static Image ResizeImage(Image image, int width, int height)
        {
            ExceptionUtils.ThrowIfZeroOrNegative(width, "width");
            ExceptionUtils.ThrowIfZeroOrNegative(height, "height");

            if ((image.Width != width) || (image.Height != height))
            {
                Bitmap resizeImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                using (Graphics graphics = System.Drawing.Graphics.FromImage(resizeImage))
                {
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.DrawImage(image, 0, 0, width, height);
                }
                return resizeImage;
            }
            else
            {
                return image;
            }
        }
        public static Image ResizeImage(Image image, int maxWidthOrHeight)
        {
            ExceptionUtils.ThrowIfZeroOrNegative(maxWidthOrHeight, "maxWidthOrHeight");

            if ((image.Width <= maxWidthOrHeight) && (image.Height <= maxWidthOrHeight))
            {
                return image;
            }
            int newWidth, newHeight;
            if (image.Width > image.Height)
            {
                newWidth = maxWidthOrHeight;
                newHeight = (image.Height * maxWidthOrHeight) / image.Width;
                if (newHeight < 0)
                {
                    newHeight = 1;
                }
            }
            else
            {
                newWidth = (image.Width * maxWidthOrHeight) / image.Height;
                newHeight = maxWidthOrHeight;
                if (newWidth < 0)
                {
                    newWidth = 1;
                }
            }
            return ResizeImage(image, newWidth, newHeight);
        }
        public static Image ResizeImage(string imageFilePath, int maxWidthOrHeight)
        {
            Image image = Bitmap.FromFile(imageFilePath);
            return ResizeImage(image, maxWidthOrHeight);
        }
        public static Image ResizeImage(string imageFilePath, int width, int height)
        {
            Image image = Bitmap.FromFile(imageFilePath);
            return ResizeImage(image, width, height);
        }
        public static byte[] ResizeImageAndSaveAsJpeg(string imageFilePath, int width, int height, 
                                                      int jpegQuality)
        {
            Image image = ResizeImage(imageFilePath, width, height);
            return SaveImageAsJpeg(image, jpegQuality);
        }
        public static byte[] ResizeImageAndSaveAsJpeg(string imageFilePath, int maxWidthOrHeight,
                                                      int jpegQuality)
        {
            Image image = ResizeImage(imageFilePath, maxWidthOrHeight);
            return SaveImageAsJpeg(image, jpegQuality);
        }
        public static byte[] ResizeImageAndSaveAsJpeg(Image image, int width, int height, int jpegQuality)
        {
            image = ResizeImage(image, width, height);
            return SaveImageAsJpeg(image, jpegQuality);
        }
        public static byte[] ResizeImageAndSaveAsJpeg(Image image, int maxWidthOrHeight, int jpegQuality)
        {
            image = ResizeImage(image, maxWidthOrHeight);
            return SaveImageAsJpeg(image, jpegQuality);
        }
        public static byte[] SaveImageAsJpeg(Image image, int jpegQuality)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                ImageCodecInfo codecInfo = DrawingUtils.GetImageCodec(ImageFormat.Jpeg);
                EncoderParameters encoderParameters;
                encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                image.Save(stream, codecInfo, encoderParameters);
                stream.Flush();
                stream.Close();
                return stream.ToArray();
            }
        }
    }
}
