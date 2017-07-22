﻿using System;
using Windows.UI.Xaml.Media.Imaging;
using Touch.Models;

namespace Touch.ViewModels
{
    /// <summary>
    ///     图片ViewModel
    /// </summary>
    public class MyImageViewModel : NotificationBase<MyImage>
    {
        public MyImageViewModel(MyImage myImage = null) : base(myImage)
        {
        }

        /// <summary>
        ///     图片路径
        /// </summary>
        public string ImagePath
        {
            get => This.ImagePath;
            set { SetProperty(This.ImagePath, value, () => This.ImagePath = value); }
        }

        /// <summary>
        ///     图片内容
        /// </summary>
        public BitmapImage Bitmap
        {
            get => This.Bitmap;
            set { SetProperty(This.Bitmap, value, () => This.Bitmap = value); }
        }

        /// <summary>
        ///     图片纬度
        /// </summary>
        public double? Latitude
        {
            get => This.Latitude;
            set { SetProperty(This.Latitude, value, () => This.Latitude = value); }
        }

        /// <summary>
        ///     图片经度
        /// </summary>
        public double? Longitude
        {
            get => This.Longitude;
            set { SetProperty(This.Longitude, value, () => This.Longitude = value); }
        }

        /// <summary>
        ///     拍摄日期
        /// </summary>
        public DateTime DateTaken
        {
            get => This.DateTaken;
            set { SetProperty(This.DateTaken, value, () => This.DateTaken = value); }
        }
    }
}