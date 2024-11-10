using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class QrCodeService
    {

        private readonly DB.DBContext _dbContext;

        public QrCodeService(DB.DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public byte[] CreateQrCodeRawData(string payload, int pixelsPerModule)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.H);
            PngByteQRCode pngByteQRCode = new PngByteQRCode(qrCodeData);

            return pngByteQRCode.GetGraphic(pixelsPerModule);
        }

        public string GenerateOrRetrieveQrCode(RequestQrCodeGenerationDto request)
        {
            // Check if a QR code already exists for the EmployeeId
            var existingQrCode = _dbContext.Admins
                .FirstOrDefault(u => u.UserQRCode == request.EmployeeId && !u.IsDeleted);

            if (existingQrCode != null)
            {
                // Return the existing QR code as a base64 string
                return Convert.ToBase64String(existingQrCode.QRCode);
            }

            // Generate the QR code payload
            var payload = $"{request.EmployeeId} - {request.Ar_FullName}";

            // Generate the QR code
            var qrCodeData = CreateQrCodeRawData(payload, request.PixelsPerModule);

            // Save the new QR code to the database
            var userQrCode = new UserQRCode
            {
                EmployeeId = request.EmployeeId,
                QRCode = qrCodeData,
                IsDeleted = false,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                UpdatedBy = "System",
                UpdatedOn = DateTime.Now
            };

            _dbContext.UserQRCodes.Add(userQrCode);
            _dbContext.SaveChanges();

            // Return the new QR code as a base64 string
            return Convert.ToBase64String(qrCodeData);
        }






    }
}
