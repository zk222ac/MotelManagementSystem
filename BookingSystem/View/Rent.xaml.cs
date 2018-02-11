using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using BookingSystem.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BookingSystem.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Rent : Page
    {
        public Rent()
        {
            this.InitializeComponent();
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            int count = 0;
            foreach (Char c in textBox.Text.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c) || (c == '.' && count == 0))
                {
                    newText += c;
                    if (c == '.')
                        count += 1;
                }
            }
            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
        }

       
            FileOpenPicker openPicker = new FileOpenPicker();

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    FileOpenPicker imagePicker = new FileOpenPicker();
        //    imagePicker.SuggestedStartLocation = PickerLocationId.Desktop;
        //    imagePicker.ViewMode = PickerViewMode.Thumbnail;
        //    imagePicker.FileTypeFilter.Add(".jpg");
        //    imagePicker.FileTypeFilter.Add(".png");
        //    imagePicker.FileTypeFilter.Add(".jpeg");
        //    StorageFile file = await imagePicker.PickSingleFileAsync();
        //    if (file != null)
        //    {
        //        var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
        //        var image = new BitmapImage();
        //        image.SetSource(stream);
        //        imageView.Source = image;
        //        string filePath = file.Path;
        //    }


        //}

        private void CommandBar_Opened(object sender, object e)
        {

        }
    }
    }
    

