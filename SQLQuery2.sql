insert into Rooms
(Price,Description,Taxes,TotalPrice,ByteArrayImage)
values(4000, 'Suite 101 – Spacious and Superior King Suite', 5, 4000.05,

 

(SELECT * FROM OPENROWSET (BULK N'C:\Users\DPU\source\repos\BookingEngine\BookingEngine\wwwroot\Images\Room101.jpg', SINGLE_BLOB) AS T1));