using LiveCharts.Wpf;
using LiveCharts;
using PhongMachTu.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace PhongMachTu.Controllers.Pages.Statistics
{
    public partial class DoanhThuPageController :Page
    {
        Dashboard dashboard = Application.Current.Windows.OfType<Dashboard>().FirstOrDefault();
        DateTime batdau;
        DateTime ketthuc;
        public DoanhThuPageController()
        {
            InitializeComponent();

            var doanhThu = new ChartValues<double>();
            var labels = new List<string>();

            // Tạo đối tượng DbContext
            using (var context = new PhongMach())
            {
             

                var query = context.HoaDon
                    .Where(hd => hd.TrangThai == 1)
                    .GroupBy(hd => new { hd.NgayLap.Year, hd.NgayLap.Month })
                    .Select(g => new { Nam = g.Key.Year, Thang = g.Key.Month, TongTien = g.Sum(hd => hd.TongTienThanhToan) })
                    .OrderBy(g => g.Nam)
                    .ThenBy(g => g.Thang)
                    .ToList();

                // Thêm giá trị DoanhThu và nhãn vào danh sách
                foreach (var item in query)
                {
                    doanhThu.Add(item.TongTien);
                    var label = $"{item.Thang}/{item.Nam}";
                    labels.Add(label);
                }
            }

            // Tạo đối tượng ColumnSeries
            var series = new ColumnSeries
            {
                Title = "Doanh thu",
                Values = doanhThu
            };

            // Tạo đối tượng SeriesCollection và thêm ColumnSeries vào đó
            var seriesCollection = new SeriesCollection { series };

            // Định dạng giá trị trục y
            Func<double, string> yFormatter = value => value.ToString("C");

            // Đặt tooltip cho biểu đồ
            var tooltip = new DefaultTooltip
            {
                SelectionMode = TooltipSelectionMode.SharedYValues
            };
            chartDoanhThu.DataTooltip = tooltip;

            // Gán dữ liệu cho biểu đồ
            chartDoanhThu.Series = seriesCollection;
            chartDoanhThu.AxisX.Clear();
            chartDoanhThu.AxisX.Add(new LiveCharts.Wpf.Axis { Labels = labels });
            chartDoanhThu.AxisY.Clear();
            chartDoanhThu.AxisY.Add(new LiveCharts.Wpf.Axis { LabelFormatter = yFormatter });
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            dashboard.fContainer.GoBack();
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            batdau = dtpTuNgay.SelectedDate.Value.Date;
            ketthuc = dtpDenNgay.SelectedDate.Value.Date.AddDays(1).AddSeconds(-1);

            if (batdau > ketthuc)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Hiển thị biểu đồ so sánh các ngày trong khoảng thời gian được chọn
            var doanhThu = new ChartValues<double>();
            var labels = new List<string>();

            // Tạo đối tượng DbContext
            using (var context = new PhongMach())
            {
                var query = context.HoaDon
                    .Where(hd => hd.TrangThai == 1 && DbFunctions.TruncateTime(hd.NgayLap) >= batdau.Date && DbFunctions.TruncateTime(hd.NgayLap) <= ketthuc.Date)
                    .GroupBy(hd => DbFunctions.TruncateTime(hd.NgayLap))
                    .Select(g => new { Ngay = g.Key, TongTien = g.Sum(hd => hd.TongTienThanhToan) })
                    .OrderBy(g => g.Ngay)
                    .ToList();

                // Thêm giá trị DoanhThu và nhãn vào danh sách
                foreach (var item in query)
                {
                    doanhThu.Add(item.TongTien);
                    var label = item.Ngay?.ToString("dd/MM/yyyy");
                    labels.Add(label);
                }
            }

            // Tạo đối tượng ColumnSeries và thêm vào đối tượng SeriesCollection
            var series = new ColumnSeries
            {
                Title = "Doanh thu",
                Values = doanhThu
            };
            var seriesCollection = new SeriesCollection { series };

            // Định dạng giá trị trục y
            Func<double, string> yFormatter = value => value.ToString("C");

            // Đặt tooltip cho biểu đồ
            var tooltip = new DefaultTooltip
            {
                SelectionMode = TooltipSelectionMode.SharedYValues
            };
            chartDoanhThu.DataTooltip = tooltip;

            // Gán dữ liệu cho biểu đồ
            chartDoanhThu.Series = seriesCollection;
            chartDoanhThu.AxisX.Clear();
            chartDoanhThu.AxisX.Add(new LiveCharts.Wpf.Axis { Labels = labels });
            chartDoanhThu.AxisY.Clear();
            chartDoanhThu.AxisY.Add(new LiveCharts.Wpf.Axis { LabelFormatter = yFormatter });
        }

        private void btnPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var streamBitmap = new MemoryStream();
                Bitmap chartBitmap = ConvertChartToBitmap(chartDoanhThu);
                BitmapImage chartBitmapImage = ConvertFromBitmapToBitmapImage(chartBitmap, streamBitmap);
                ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders()
                        .First(codec1 => codec1.FormatID == ImageFormat.Png.Guid);
                EncoderParameters parameters = new EncoderParameters(1);
                parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L); // Đặt chất lượng ảnh

                // Lưu ảnh dưới định dạng img
                chartBitmap.Save("output.png", codec, parameters);
                var saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Save PDF Document";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    var doc = DocX.Create("myDocx.docx");

                    // Tạo đầu đề "CUSTOMER REPORT 16/06/2023"
                    var headingFormat = new Formatting
                    {
                        FontFamily = new Xceed.Document.NET.Font("Times New Roman"),
                        Size = 16,
                        Bold = true
                    };
                    var heading = doc.InsertParagraph("BÁO CÁO DOANH THU", false, headingFormat);
                    heading.Alignment = Xceed.Document.NET.Alignment.center;
                    var dateTimeReportFormat = new Formatting
                    {
                        FontFamily = new Xceed.Document.NET.Font("Times New Roman"),
                        Size = 13,
                        Italic = true
                    };
                    doc.InsertParagraph("");
                    var dateTimeReport = doc.InsertParagraph("At " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"), false, dateTimeReportFormat);
                    dateTimeReport.Alignment = Xceed.Document.NET.Alignment.center;

                    #region Add chart into docx file
                    // Thêm hình ảnh chart vào 
                    doc.InsertParagraph("");
                    doc.InsertParagraph("");
                    var chartPicture = doc.AddImage(chartBitmapImage.StreamSource);
                    var chartPictureParagraph = doc.InsertParagraph("", false);
                    chartPictureParagraph.AppendPicture(chartPicture.CreatePicture());
                    chartPictureParagraph.Alignment = Xceed.Document.NET.Alignment.center;
                    var NameChartFormat = new Formatting
                    {
                        FontFamily = new Xceed.Document.NET.Font("Times New Roman"),
                        Size = 13,
                        Italic = true,
                        Bold = true
                    };
                    var NameChart = doc.InsertParagraph("BÁO CÁO DOANH THU từ " + batdau.ToString("dd/MM/yyyy") + " đến " + ketthuc.ToString("dd/MM/yyyy"), false, NameChartFormat);
                    NameChart.InsertParagraphBeforeSelf("");
                    NameChart.Alignment = Xceed.Document.NET.Alignment.center;
                    #endregion

                    #region Save word and pdf
                    // Lưu tài liệu Word
                    doc.Save();
                    SautinSoft.Document.DocumentCore documentCore = SautinSoft.Document.DocumentCore.Load("myDocx.docx");

                    documentCore.Save(saveFileDialog.FileName);
                    File.Delete("myDocx.docx");
                    #endregion
                    MessageBox.Show("Đã lưu biểu đồ dưới dạng tệp PDF.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Bitmap ConvertChartToBitmap(CartesianChart chart)
        {
            int maxWidth = 600;
            // Tạo đối tượng RenderTargetBitmap với kích thước bằng với kích thước của CartesianChart
            var renderBitmap = new RenderTargetBitmap(
                1300, 900,
                96, 96, PixelFormats.Pbgra32);

            // Vẽ CartesianChart vào đối tượng RenderTargetBitmap
            renderBitmap.Render(chart);

            // Tạo đối tượng Bitmap từ đối tượng RenderTargetBitmap
            var chartBitmap = new Bitmap(
                1300, 900,
                System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            // Sao chép dữ liệu pixel từ đối tượng RenderTargetBitmap sang đối tượng Bitmap
            var bitmapData = chartBitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, 1300, 900),
                ImageLockMode.WriteOnly, chartBitmap.PixelFormat);

            renderBitmap.CopyPixels(
                Int32Rect.Empty, bitmapData.Scan0,
                bitmapData.Stride * 900, bitmapData.Stride);

            chartBitmap.UnlockBits(bitmapData);
            if (chartBitmap.Width > maxWidth)
            {
                var scaleFactor = (float)maxWidth / (float)chartBitmap.Width;
                var newWidth = (int)(chartBitmap.Width * scaleFactor);
                var newHeight = (int)(chartBitmap.Height * scaleFactor * 1.2);
                var newBitmap = new Bitmap(chartBitmap, new System.Drawing.Size(newWidth, newHeight));
                chartBitmap.Dispose();
                chartBitmap = newBitmap;
            }
            //Trả về đối tượng Bitmap
            return chartBitmap;
        }
        private BitmapImage ConvertFromBitmapToBitmapImage(Bitmap chartBitmap, MemoryStream chartMemoryStream)
        {
            // Lưu hình ảnh vào đối tượng MemoryStream
            chartBitmap.Save(chartMemoryStream, ImageFormat.Png);
            // Tạo đối tượng BitmapImage từ đối tượng MemoryStream
            var chartBitmapImage = new BitmapImage();
            chartBitmapImage.BeginInit();
            chartBitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            chartBitmapImage.StreamSource = chartMemoryStream;
            chartBitmapImage.EndInit();
            // Trả về đối tượng BitmapImage
            return chartBitmapImage;
        }
    }
}
