CREATE DATABASE StudioBookingDb;
GO
USE StudioBookingDb;
GO
CREATE TABLE Services (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Description NVARCHAR(1000) NOT NULL,
    Price DECIMAL(18,2) NOT NULL CHECK (Price >= 0),
    IsActive BIT NOT NULL DEFAULT 1
);
GO
CREATE TABLE Bookings (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    BookingCode VARCHAR(40) NOT NULL UNIQUE,
    ServiceId INT NOT NULL,
    CustomerName NVARCHAR(150) NOT NULL,
    Phone VARCHAR(30) NOT NULL,
    PreferredDate DATE NOT NULL,
    PriceSnapshot DECIMAL(18,2) NOT NULL,
    ServiceNameSnapshot NVARCHAR(150) NOT NULL,
    Status VARCHAR(30) NOT NULL DEFAULT 'Pending',
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_Bookings_Services FOREIGN KEY (ServiceId) REFERENCES Services(Id)
);
GO
INSERT INTO Services(Name,Description,Price) VALUES
(N'Chụp ảnh chân dung',N'Gói chụp cá nhân trong studio, phù hợp hồ sơ và thương hiệu cá nhân.',1200000),
(N'Chụp ảnh couple',N'Lưu giữ câu chuyện của hai bạn với concept được tư vấn riêng.',2200000),
(N'Chụp ảnh sự kiện',N'Ghi lại những khoảnh khắc đáng nhớ trong sự kiện của bạn.',3500000);
GO
