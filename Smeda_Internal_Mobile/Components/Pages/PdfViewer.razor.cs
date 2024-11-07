//using Data.Models;
//using Logic.IServices;
//using Microsoft.AspNetCore.Components;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SmedaInternalMobile.Components.Pages
//{
//    public partial class PdfViewer
//    {
//        [Parameter]
//        public int RequestId { get; set; }


//        [Inject]
//        NavigationManager _navigationManager { get; set; }

//        [Inject]
//        IGenericService<DesignationRequestModel> _designationService { get; set; }

//        byte[] pdfBytes;

//        protected override void OnInitialized()
//        {
//            // Load your PDF byte array here
//            GetPdfByteArray();
//        }

//        private async Task GetPdfByteArray()
//        {
//            // Replace this with the actual logic to fetch your PDF byte array
//            // For example, you might fetch it from a service or a file
//            // byte[] pdfBytes = YourPdfFetchingLogic();
//            var requestModel =await  _designationService.GetById(RequestId);
//            pdfBytes = requestModel.DocumentData;

//        }
//        private void OpenPdfInViewer()
//        {
//            try
//            {
//                // Save the PDF to a file
//                string filePath = SavePdfToFile(pdfBytes, "example.pdf");

//                // Launch the default PDF viewer
//                Launcher.OpenAsync(new OpenFileRequest
//                {
//                    File = new ReadOnlyFile(filePath)
//                });
//            }
//            catch (Exception ex)
//            {
//                // Handle exceptions
//                Console.WriteLine($"Error opening PDF: {ex.Message}");
//            }
//        }

//        private string SavePdfToFile(byte[] pdfBytes, string fileName)
//        {
//            // Save the PDF byte array to a file
//            string filePath = Path.Combine(FileSystem.CacheDirectory, fileName);
//            File.WriteAllBytes(filePath, pdfBytes);

//            return filePath;
//        }
//    }
//}
