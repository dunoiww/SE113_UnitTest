CREATE DATABASE QLYPHONGKHAMTU
GO

USE QLYPHONGKHAMTU
SET DATEFORMAT DMY

CREATE TABLE BenhNhan
(
	ID int identity(1,1),
	MaBN as 'BN' + right('000' + cast(ID as varchar(3)), 3) persisted,
	FullName NVARCHAR(40) not null,
	Birthday smalldatetime,
	Sex NVARCHAR(3) not null,
	DiaChi NVARCHAR(40),
	SDT  VARCHAR(11) not null,
	constraint PK_MaBN primary key(MaBN)	
)
Alter table BenhNhan add constraint Check_Sex check(Sex='Nam' or Sex=N'Nữ')

Insert into BenhNhan values(N'Nguyễn Văn Nam', '8/12/1990', N'Nam', N'Hà Nội', '0987654321')
Insert into BenhNhan values(N'Trần Thị Bích', '26/6/1995', N'Nữ', N'Hồ Chí Minh', '0123456789')
Insert into BenhNhan values(N'Lê Thị Nguyệt', '18/4/1998', N'Nữ', N'Đà Nẵng', '0987654321')
Insert into BenhNhan values(N'Nguyễn Cẩm Tú','12/5/2000',N'Nữ',N'125/2 Hòa Hưng, Phuờng 12, Q10, TpHCM','0914700915')
Insert into BenhNhan values(N'Phạm Thành An','15/7/2000',N'Nam',N'Đà Nẵng','0914700915')
Insert into BenhNhan values(N'Nguyễn Văn B', '01/10/1998', N'Nam', N'20 Nguyễn Văn Linh, Đà Nẵng', '0905123456')
Insert into BenhNhan values(N'Phạm Thị Ngọc Trâm', '02/03/1995', N'Nữ', N'15 Trần Phú, Hà Nội', '0987654321')
Insert into BenhNhan values(N'Trần Đức Anh', '05/08/2002', N'Nam', N'25 Lê Lợi, Huế', '0909123456')
Insert into BenhNhan values(N'Nguyễn Thị Thùy Linh', '23/7/1996', N'Nữ', N'123 Lê Duẩn, Hà Nội', '0987654321')
Insert into BenhNhan values(N'Phạm Văn Tiến', '01/12/1990', N'Nam', N'456 Trần Hưng Đạo, TP.HCM', '0912345678')
Insert into BenhNhan values(N'Lê Thị Thu', '02/3/1985', N'Nữ', N'789 Nguyễn Văn Linh, Đà Nẵng', '0909123456')
Insert into BenhNhan values(N'Nguyễn Văn An', '03/8/2001', N'Nam', N'12 Nguyễn Thái Học, Hà Nội', '0912345678')
Insert into BenhNhan values(N'Phạm Thị Kim Ngân', '12/12/1999', N'Nữ', N'321 Lê Thánh Tông, Hải Phòng', '0987654321')
Insert into BenhNhan values(N'Trần Đức Minh', '30/11/1997', N'Nam', N'456 Huỳnh Văn Bánh, TP.HCM', '0912123456')
Insert into BenhNhan values(N'Lê Thị Mỹ Hạnh', '15/4/1994', N'Nữ', N'789 Trần Phú, Huế', '0909123456')


CREATE TABLE ChiTietDS 
(
    ID int identity(1,1), 
	MaDS as 'CT' + right('000' + cast(ID as varchar(3)), 3) persisted,
    MaBN  varchar(5) not null,
    TrangThai NVARCHAR(50),
	constraint PK_CT_MaDS primary key(MaDS)	
)
alter table ChiTietDS add constraint FK_CTDS_MaBN foreign key(MaBN) references BenhNhan(MaBN)

Insert into ChiTietDS values('BN001',N'Đã lấy thuốc')
Insert into ChiTietDS VALUES ('BN002',N'Đã hủy đơn')
Insert into ChiTietDS values('BN003',N'Đang xử lí')
Insert into ChiTietDS VALUES ('BN004',N'Đã hủy đơn')
Insert into ChiTietDS values('BN005',N'Đang xử lí')


CREATE TABLE DanhSachKhamBenh
(
	ID int identity(1,1), 
	MaDS as 'CT' + right('000' + cast(ID as varchar(3)), 3) persisted,
	NgayKham smalldatetime,
	SoLuong int,
	constraint PK_MaDS primary key(MaDS)	
)


Insert into DanhSachKhamBenh values ('3/8/2023',15)
Insert into DanhSachKhamBenh values ('6/8/2023',20)
Insert into DanhSachKhamBenh values ('2/2/2023',25)
Insert into DanhSachKhamBenh values ('21/1/2023',30)
Insert into DanhSachKhamBenh values ('3/12/2023',34)
Insert into DanhSachKhamBenh values ('9/11/2023',29)
Insert into DanhSachKhamBenh values ('3/5/2023',24)

CREATE TABLE PhieuKhamBenh
(
	ID int identity(1,1), 
	MaPK as 'PK' + right('000' + cast(ID as varchar(3)), 3) persisted,
	MaBN  varchar(5) not null,
	NgayLap date NOT NULL,
	TrieuChung nvarchar(50) NOT NULL,
	DuDoan nvarchar(50) NOT NULL,
	CONSTRAINT PK_MaPK PRIMARY KEY (MaPK)
)
alter table PhieuKhamBenh add constraint FK_PKB_MaBN foreign key(MaBN) references BenhNhan(MaBN)

INSERT INTO PhieuKhamBenh VALUES ('BN001', '5/2/2023', N'Đau đầu', N'Mất ngủ')
INSERT INTO PhieuKhamBenh VALUES ('BN002', '4/12/2023', N'Sốt cao', N'Viêm phổi')
INSERT INTO PhieuKhamBenh VALUES ('BN003', '2/3/2023', N'Đau bụng', N'Viêm đường tiêu hóa')
INSERT INTO PhieuKhamBenh VALUES ('BN004', '6/1/2023', N'Đau họng', N'Viêm họng')
INSERT INTO PhieuKhamBenh VALUES ('BN005', '4/2/2023', N'Sốt nhẹ', N'Cảm cúm')
INSERT INTO PhieuKhamBenh VALUES ('BN006', '25/1/2023', N'Đau lưng', N'Viêm cột sống')
INSERT INTO PhieuKhamBenh VALUES ('BN007', '21/7/2023', N'Đau vai', N'Viêm khớp')
INSERT INTO PhieuKhamBenh VALUES ('BN008', '6/2/2023', N'Ho khan', N'Viêm phế quản')
INSERT INTO PhieuKhamBenh VALUES ('BN009', '7/11/2023', N'Đau đầu', N'Migraine')
INSERT INTO PhieuKhamBenh VALUES ('BN010', '8/1/2023', N'Buồn nôn', N'Viêm dạ dày')
INSERT INTO PhieuKhamBenh VALUES ('BN011', '5/7/2023', N'Đau mắt', N'Viêm kết mạc')

CREATE TABLE HoaDon
(
	ID int identity(1,1),
	MaHD as 'HD' + right('000' + cast(ID as varchar(3)), 3) persisted,
	MaPK varchar(5) not null,
	NgayLap datetime NOT NULL,
	TienKham int NOT NULL,
	TienThuoc int NOT NULL,
	TongTienThanhToan int NOT NULL,
	TrangThai int,
	constraint PK_MaHD primary key(MaHD)	
)
alter table HoaDon add constraint FK_HD_MaPK foreign key(MaPK) references PhieuKhamBenh(MaPK)

INSERT INTO HoaDon VALUES ('PK001', '5/2/2023', 100000, 50000, 150000 , 1)
INSERT INTO HoaDon VALUES ('PK002', '4/12/2023', 700000, 60000, 130000 , 1)
INSERT INTO HoaDon VALUES ('PK003', '2/3/2023', 80000, 60000, 140000 , 1)
INSERT INTO HoaDon VALUES ('PK004', '6/1/2023', 90000, 70000, 160000 , 1)
INSERT INTO HoaDon VALUES ('PK005', '4/2/2023', 70000, 50000, 120000 , 1)
INSERT INTO HoaDon VALUES ('PK006', '2/1/2023', 110000, 90000, 200000 , 1)
INSERT INTO HoaDon VALUES ('PK007', '1/7/2023', 95000, 75000, 170000 , 1)

CREATE TABLE Thuoc
(
	ID int identity(1,1),
	MaThuoc as 'TH' + right('000' + cast(ID as varchar(3)), 3) persisted,
	TenThuoc NVARCHAR(40) not null,
	LoaiThuoc NVARCHAR(40) not null,
	GiaThuoc int NOT NULL,
	TonKho int NOT NULL,
	constraint PK_MaThuoc primary key(MaThuoc)	
)

INSERT INTO Thuoc VALUES ('Paracetamol',N'Viên', 20000, 1000)
INSERT INTO Thuoc VALUES ('Amoxicillin', N'Viên', 50000, 500)
INSERT INTO Thuoc VALUES ('Vitamin C', N'Hộp', 100000, 1200)
INSERT INTO Thuoc VALUES ('Omeprazole', N'Chai', 40000, 400)
INSERT INTO Thuoc VALUES ('Loperamide', N'Ống', 35000, 300)
INSERT INTO Thuoc VALUES ('Cetirizine', N'Viên', 45000, 200)
INSERT INTO Thuoc VALUES ('Acyclovir', N'Ống', 55000, 100)

CREATE TABLE CachDungThuoc
(
	ID int identity(1,1),
	MaCachDung as 'CD' + right('000' + cast(ID as varchar(3)), 3) persisted,
	DienGiai NVarChar(40),
	constraint PK_MaCachDung primary key(MaCachDung)	
)

INSERT INTO CachDungThuoc VALUES (N'Uống trước bữa ăn 30 phút')
INSERT INTO CachDungThuoc VALUES (N'Tiêm bắp')
INSERT INTO CachDungThuoc VALUES (N'Xịt vào mũi')
INSERT INTO CachDungThuoc VALUES (N'Bôi ngoài da')
INSERT INTO CachDungThuoc VALUES (N'Hòa tan trong nước và uống')

CREATE TABLE DonViThuoc
(
	ID int identity(1,1),
	MaDonVi as 'DV' + right('000' + cast(ID as varchar(3)), 3) persisted,
	DienGiai NVarChar(40),
	constraint PK_MaDonVi primary key(MaDonVi)	
)

INSERT INTO DonViThuoc VALUES (N'Viên')
INSERT INTO DonViThuoc VALUES (N'Chai')
INSERT INTO DonViThuoc VALUES (N'Hộp')
INSERT INTO DonViThuoc VALUES (N'Lọ')
INSERT INTO DonViThuoc VALUES (N'Ống')
INSERT INTO DonViThuoc VALUES (N'Gói')
INSERT INTO DonViThuoc VALUES (N'Túi')
INSERT INTO DonViThuoc VALUES (N'Chai 100ml')

CREATE TABLE ChiDinhDungThuoc
(
	ID int identity(1,1), 
	MaPK varchar(5) not null,
	MaThuoc varchar(5) not null,
	SoLuong int ,
	MaDonVi varchar(5),
	MaCachDung varchar(5),
	GhiChu NVarChar(40),
	CONSTRAINT PK_CDDT PRIMARY KEY (MaPK, MaThuoc) 
)
alter table ChiDinhDungThuoc add constraint FK_CDDT_MaThuoc foreign key(MaThuoc) references Thuoc(MaThuoc)
alter table ChiDinhDungThuoc add constraint FK_CDDT_MaDonVi foreign key(MaDonVi) references DonViThuoc(MaDonVi)
alter table ChiDinhDungThuoc add constraint FK_CDDT_MaCachDung foreign key(MaCachDung) references CachDungThuoc(MaCachDung)

INSERT INTO ChiDinhDungThuoc VALUES ('PK001', 'TH001', 2, 'DV001', 'CD001', N'Uống trước bữa ăn 30 phút')
INSERT INTO ChiDinhDungThuoc VALUES ('PK001','TH002', 1, 'DV002', 'CD002', N'Bôi ngoài da')
INSERT INTO ChiDinhDungThuoc VALUES ('PK001','TH003', 1, 'DV003', 'CD003', N'Uống sau bữa ăn')
INSERT INTO ChiDinhDungThuoc VALUES ('PK002','TH001', 3, 'DV004', 'CD004', N'Xịt vào mũi')
INSERT INTO ChiDinhDungThuoc VALUES ('PK002','TH002', 1, 'DV005', 'CD005', N'Tiêm bắp')
INSERT INTO ChiDinhDungThuoc VALUES ('PK001','TH004', 1, 'DV003', 'CD003', N'Bôi vào vùng đau')

CREATE TABLE ChiTietThongKeThuoc
(
	ID int identity(1,1), 
	MaTKThuoc as 'TK' + right('000' + cast(ID as varchar(3)), 3) persisted,
	MaThuoc varchar(5) not null,
	SoLuong int ,
	SoLanBan int,
	CONSTRAINT PK_CTMaTKThuoc PRIMARY KEY (MaTKThuoc)
)
alter table ChiTietThongKeThuoc add constraint FK_CTTKT_MaThuoc foreign key(MaThuoc) references Thuoc(MaThuoc)

INSERT INTO ChiTietThongKeThuoc VALUES ('TH002', 100, 50)
INSERT INTO ChiTietThongKeThuoc VALUES ('TH002', 200, 100)
INSERT INTO ChiTietThongKeThuoc VALUES ('TH003', 50, 20)
INSERT INTO ChiTietThongKeThuoc VALUES ('TH001', 150, 75)

CREATE TABLE ThongKeThuoc
(
	ID int identity(1,1), 
	MaTKThuoc as 'TK' + right('000' + cast(ID as varchar(3)), 3) persisted,
	Thang int,
	CONSTRAINT PK_MaTKThuoc PRIMARY KEY (MaTKThuoc)
)

INSERT INTO ThongKeThuoc VALUES (1)
INSERT INTO ThongKeThuoc VALUES (2)
INSERT INTO ThongKeThuoc VALUES (3)
INSERT INTO ThongKeThuoc VALUES (4)
INSERT INTO ThongKeThuoc VALUES (5)
INSERT INTO ThongKeThuoc VALUES (6)
INSERT INTO ThongKeThuoc VALUES (7)
INSERT INTO ThongKeThuoc VALUES (8)
INSERT INTO ThongKeThuoc VALUES (9)
INSERT INTO ThongKeThuoc VALUES (10)
INSERT INTO ThongKeThuoc VALUES (11)
INSERT INTO ThongKeThuoc VALUES (12)

CREATE TABLE NhanVien
(
	ID int identity(1,1),
	MaNV as 'NV' + right('000' + cast(ID as varchar(3)), 3) persisted,
	TenNV NVARCHAR(40) not null,
	Birthday smalldatetime,
	Sex NVARCHAR(3) not null,
	DiaChi NVARCHAR(40),
	SDT  VARCHAR(10) not null,
	ChucVu NVarChar(20) not null,
	UserName Nvarchar(15) unique not null,
	Password Nvarchar(20) not null,
	constraint PK_MaNV primary key(MaNV)	
)
Alter table NhanVien add constraint Check_SexNV check(Sex='Nam' or Sex=N'Nữ')

INSERT INTO NhanVien VALUES (N'Nguyễn Văn Bình', '1/1/1990', N'Nam', N'Hà Nội', '0912345678', N'Quản lý', 'Ngquanly1', '123456')
INSERT INTO NhanVien VALUES (N'Nguyễn Văn Nam', '7/5/1989', N'Nam', N'Nghệ An', '0965432109', N'Bác Sĩ', 'bacsi1', 'ghi789')
INSERT INTO NhanVien VALUES (N'Lê Quốc Dũng', '10/5/1989', N'Nam', N'Quảng Ngãi', '0965451210', N'Bác Sĩ', 'bai1', '789jqk')
INSERT INTO NhanVien VALUES (N'Trần Thị Thùy', '15/3/1995', N'Nữ', N'Hồ Chí Minh', '0987654321', N'Nhân viên', 'ttb', 'abc123')
INSERT INTO NhanVien VALUES (N'Nguyễn Thị Cẩm Tú', '6/3/1994', N'Nữ', N'Hồ Chí Minh', '0264565421', N'Bác Sĩ', 'ttu', 'ab123')
INSERT INTO NhanVien VALUES (N'Lê Văn Hùng', '29/8/1995', N'Nam', N'Đà Nẵng', '0945678901', N'Y tá', 'lvc', 'xyz789')
INSERT INTO NhanVien VALUES (N'Phạm Thị Dương', '13/2/1991', N'Nữ', N'Hà Tĩnh', '0976543210', N'Nhân viên', 'ptd', 'def456')

create TABLE QuyDinh
(
	ID int identity(1,1),
	MaQD as 'QD' + right('000' + cast(ID as varchar(3)), 3) persisted,
	TenQD nvarchar(100) NOT NULL,
	GiaTri nvarchar(50) NOT NULL,
 CONSTRAINT PK_MaQD PRIMARY KEY (MaQD)
 )

 INSERT INTO QuyDinh VALUES (N'Thời gian tối đa cho một bệnh nhân trong phòng khám', N'30 phút')
 INSERT INTO QuyDinh VALUES (N'Số lượng bác sĩ tối đa trong phòng khám', '5')
 INSERT INTO QuyDinh VALUES (N'Thời gian tối đa để đợi khám bệnh', N'60 phút')
 INSERT INTO QuyDinh VALUES (N'Số lượng lịch khám tối đa một ngày', '30')
 INSERT INTO QuyDinh VALUES (N'Thời gian tối đa để chờ đợi kết quả xét nghiệm', N'120 phút')
 INSERT INTO QuyDinh VALUES (N'Tiền khám', N'40000')


-- create table UserApp
--(
--	MaNV varchar(5),
--	UserName Nvarchar(15) unique not null,
--	Password Nvarchar(20) not null,
--	Email NVarchar(30) not null,   /*Email để khôi phục mật khẩu nếu cần*/
--	constraint PK_UA_MaNV primary key(MaNV)
--)

--alter table UserApp add constraint FK_UA_MaNV foreign key(MaNV) references NhanVien(MaNV)
--Insert into UserApp values('NV006',N'Ngquanly1',N'123456ABCDEF',N'lequocdung2983@gmail.com') /*NV Quản Lý*/ 
--Insert into UserApp values('NV004',N'Nhvien1',N'ABCDEF123456',N'21520739@gm.uit.edu.vn')  /*NV Văn Phòng*/

alter table ChiTietDS add constraint FK_CTDS_MaDS foreign key(MaDS) references DanhSachKhamBenh(MaDS)
alter table ChiDinhDungThuoc add constraint FK_CTTKT_MaPK foreign key(MaPK) references PhieuKhamBenh(MaPK)
alter table ChiTietThongKeThuoc add constraint FK_CTTKT_MaTKThuoc foreign key(MaTKThuoc) references ThongKeThuoc(MaTKThuoc)

--Thêm khóa chính ChiTietDS
ALTER TABLE ChiTietDS
DROP CONSTRAINT PK_CT_MaDS -- Xóa ràng buộc khóa chính cũ
ALTER TABLE ChiTietDS
ADD CONSTRAINT PK_CT PRIMARY KEY (MaDS, MaBN) -- Thêm ràng buộc khóa chính mới trên hai cột MaDS và MaBN

--Thêm khóa chính ChiDinhDungThuoc
ALTER TABLE ChiTietThongKeThuoc
DROP CONSTRAINT PK_CTMaTKThuoc
ALTER TABLE ChiTietThongKeThuoc
ADD CONSTRAINT PK_CTTKThuoc PRIMARY KEY (MaTKThuoc, MaThuoc) 