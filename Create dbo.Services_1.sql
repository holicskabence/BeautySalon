USE [AppDb]
GO

/****** Object: Table [dbo].[Services] Script Date: 2023. 07. 31. 19:43:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Services] (
    [Id]       NVARCHAR (450) NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    [Cost]     INT            NOT NULL,
    [Time]     INT            NOT NULL,
    [Category] NVARCHAR (MAX) NOT NULL
);


INSERT INTO Services (name, cost, time, category)
VALUES
  ('Arctisztító kezelés', 9500, 45, 'Kezelés'),
  ('Arcmaszírozás', 5500, 30, 'Kezelés'),
  ('Arc-dekoltázs tisztító kezelés', 10500, 60, 'Kezelés'),
  ('Arc-dekoltázs masszázs', 6300, 40, 'Kezelés'),
  ('Itenzív ápolás ultrahanggal', 4000, 20, 'Kezelés'),
  ('Szempillafestés', 2000, 15, 'Kezelés'),
  ('7', 'Szemöldökfestés', 1300, 10, 'Kezelés'),
  ('8', 'Szemöldök festés – szedés', 2000, 20, 'Kezelés'),
  ('9', 'Szemöldök szedés', 900, 10, 'Kezelés'),
  ('10', 'Bajusz szőkítés', 900, 5, 'Kezelés'),
  ('11', 'Bajuszgyanta', 500, 10, 'Kezelés'),
  ('12', 'Arcgyanta', 1500, 20, 'Kezelés'),
  ('13', 'Smink', 4000, 30, 'Kezelés'),
  ('14', 'Paraffin kezelés', 3000, 25, 'Kezelés'),
  ('15', 'Fülbelövés', 4500, 5, 'Kezelés'),
  ('16', 'Gyantázás - Láb térdig', 2500, 20, 'Gyantázás'),
  ('17', 'Gyantázás - Hónalj', 2500, 15, 'Gyantázás'),
  ('18', 'Gyantázás - Láb végig', 4000, 30, 'Gyantázás'),
  ('19', 'Gyantázás - Kar', 2500, 20, 'Gyantázás'),
  ('20', 'Gyantázás - Bikini vonal', 2000, 15, 'Gyantázás'),
  ('21', 'Gyantázás - Áll', 1500, 10, 'Gyantázás'),
  ('22', 'Gyantázás - Teljes fazon', 4000, 30, 'Gyantázás'),
  ('23', 'Gyantázás - Bajusz', 500, 5, 'Gyantázás'),
  ('24', 'Gyantázás - Mellkas', 3500, 25, 'Gyantázás'),
  ('25', 'Gyantázás - Hát', 3500, 25, 'Gyantázás'),
  ('26', 'Kéz-és lábápolás - Pedikűr, lábápolás', 5500, 45, 'Kéz-és lábápolás'),
  ('27', 'Kéz-és lábápolás - Lábköröm ápolás', 3000, 20, 'Kéz-és lábápolás'),
  ('28', 'Kéz-és lábápolás - Lábköröm lakkozás', 3800, 30, 'Kéz-és lábápolás'),
  ('29', 'Pedikűr, ápolás körömlakkal', 6300, 50, 'Kéz-és lábápolás'),
  ('30', 'Lábköröm géllakkozás', 6000, 40, 'Kéz-és lábápolás'),
  ('31', 'Pedikűr, ápolás géllakkal', 10000, 60, 'Kéz-és lábápolás'),
  ('32', 'Benőtt köröm kezelés', 1000, 15, 'Kéz-és lábápolás');


