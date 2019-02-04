--
-- Inserting data into table dbo.CreativeTeamMember
--
SET IDENTITY_INSERT dbo.CreativeTeamMember ON
GO
INSERT dbo.CreativeTeamMember(CreativeTeamMemberId) VALUES (1)
INSERT dbo.CreativeTeamMember(CreativeTeamMemberId) VALUES (2)
INSERT dbo.CreativeTeamMember(CreativeTeamMemberId) VALUES (3)
INSERT dbo.CreativeTeamMember(CreativeTeamMemberId) VALUES (4)
INSERT dbo.CreativeTeamMember(CreativeTeamMemberId) VALUES (5)
INSERT dbo.CreativeTeamMember(CreativeTeamMemberId) VALUES (6)
INSERT dbo.CreativeTeamMember(CreativeTeamMemberId) VALUES (7)
INSERT dbo.CreativeTeamMember(CreativeTeamMemberId) VALUES (8)
INSERT dbo.CreativeTeamMember(CreativeTeamMemberId) VALUES (9)
INSERT dbo.CreativeTeamMember(CreativeTeamMemberId) VALUES (10)
GO
SET IDENTITY_INSERT dbo.CreativeTeamMember OFF
GO

--
-- Inserting data into table dbo.HashTag
--
SET IDENTITY_INSERT dbo.HashTag ON
GO
INSERT dbo.HashTag(HashTagId) VALUES (1)
INSERT dbo.HashTag(HashTagId) VALUES (2)
INSERT dbo.HashTag(HashTagId) VALUES (3)
INSERT dbo.HashTag(HashTagId) VALUES (4)
INSERT dbo.HashTag(HashTagId) VALUES (5)
INSERT dbo.HashTag(HashTagId) VALUES (6)
INSERT dbo.HashTag(HashTagId) VALUES (7)
INSERT dbo.HashTag(HashTagId) VALUES (8)
INSERT dbo.HashTag(HashTagId) VALUES (9)
INSERT dbo.HashTag(HashTagId) VALUES (10)
GO
SET IDENTITY_INSERT dbo.HashTag OFF
GO

--
-- Inserting data into table dbo.Language
--
SET IDENTITY_INSERT dbo.Language ON
GO
INSERT dbo.Language(LanguageId, LanguageName) VALUES (1, N'English')
INSERT dbo.Language(LanguageId, LanguageName) VALUES (2, N'���������')
INSERT dbo.Language(LanguageId, LanguageName) VALUES (3, N'Polski')
INSERT dbo.Language(LanguageId, LanguageName) VALUES (4, N'Espa?ol')
INSERT dbo.Language(LanguageId, LanguageName) VALUES (5, N'�������')
GO
SET IDENTITY_INSERT dbo.Language OFF
GO

--
-- Inserting data into table dbo.Performance
--
SET IDENTITY_INSERT dbo.Performance ON
GO
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (1, 0x1E8502F406977FE4F71652FFD1466515EF0215C35F680DC1EDB5362A489DD04235943A1F2ECFF2460442D55F49D05F334E51F81F04B54F405386699C3164BBA00A4D3BB8BC4BE18C7B796CBA2D1CE804C016DF1F0E1CCFEE07515240040318A667314CB8D61DC859AF5A2F8F03ACACF6506A383AB693EB9C72F6E7B791E8501B45EB630FBE5506759D8A02AEE121008EB63B0D7ED2050BD83BBAAE01D5F91DCC516BFDA6B09609, 83, 65, 408, 8)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (2, 0xB40EF9390D4FCAE4FEEA126E2951F5601F7247AE75D0AF10717A361B5585AEC1D72183B423DEE248028605F21CF86F337A746D89EDC500091273F06F71BF5C8A17C032090EFC671CED5947D4518F41F3199FF1E35EAC428351422EA0DA5AFF1B4607EBA153DF0E92930827BD535328E5E5235CC2076EB8052D7AB508F042F1643B050B82495C92E003F8054CD5203DC70122E4, 126, 61, 400, 2)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (3, 0x0EAABB851E32F97201244A236F3258CD5C66CF1D64D00A04C31C85FA0A3F9E17A60903F0041895BE04CCCAE385ED75E442046C1DED096E, 114, 50, 430, 4)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (4, 0xD588D62886850D703006B0E00CE71BC04F2AFB05476BA87040EE745603DCC4D47538AD4822AAB37BA7E3B984, 180, 62, 478, 3)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (5, 0xDCC5C0D27F4B6B1102C2570F52F508035AD782EBCD2923018EE766B65F084B01D7875D6BEB5329750000052D479E64E2836DE75E22A7D60981C247FC721D13733763BC2088E4BF12C35404B8809742F89F79ECE8C85EC2B30278A56807024ACD035A2705789A39447C81591828EC0A600C035F06C35C8E3B55014804870624F6D53F80C8942D09F7AD688C232BB73BEC4E75ED0287016F95DD6C6CA988C6D82B439501D15D82427EB57E9506DECCC4E8FE705AA3BB4005, 165, 54, 305, 2)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (6, 0x5B0889DBC703241D63CFE64C090525212C01CD698AB4F7C276908D477D2A543D152E08BE74E6A35C6D0025012135472F8B061E29763E170FEE592EDCFFADFE05DCD27CF4D5109389E703DEEEE34646FA62F797A7E8E3374A1A03B43BD89A, 61, 52, 360, 5)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (7, 0xB3153F434F1110026F3B1509A2B5D5EC1797090B42AAB79B5A993255E3B005ED6B7B004F06B286EEC0016EFF9A2708256C01AF6301DABC21F5A07251C3C923101E751D5F0C4BD5766994294704B70C3FC34007694BF9CF1370EA129127DF029131DE89D94C8F2E845891FA571D3B0603B93B56689FBD8AA3A8D55939292C56B0EF4E092AE1F690, 135, 66, 346, 5)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (8, 0x1B, 71, 55, 386, 5)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (9, 0x09824CCFB8B24C47EB35575FE58DC205017E60C9DF01110429C53B30C6FE7DDD04D8B5444976074B2AE7CE27EB17FB4CEF058DCD4528F600769FBEC7940B45219573AE508506BE5E69824A508BC3BEFCEE3559E2D3DAF52A3C90AA1EA99D647F3E2CAC8D69218FA76DFF071C6D5FC39E27879DD74DBB340F018B97BC5B60BBF83F4D98FB09AE0808EAF5DF1787FFCC03E876B3020C845F3A0B7476B12E278925F4484E28083285B74F3D1BA202ED685B3816968C1014A501D59380470D026A949E08978707, 126, 56, 462, 9)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (10, 0x593CAF, 159, 54, 340, 3)
GO
SET IDENTITY_INSERT dbo.Performance OFF
GO

--
-- Inserting data into table dbo.PerformanceCreativeTeamMember
--
SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember ON
GO
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (10, 10, 1)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (5, 5, 2)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (1, 1, 3)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (6, 6, 4)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (2, 2, 5)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (7, 7, 6)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (3, 3, 7)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (8, 8, 8)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (4, 4, 9)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (9, 9, 10)
GO
SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember OFF
GO

--
-- Inserting data into table dbo.Schedule
--
SET IDENTITY_INSERT dbo.Schedule ON
GO
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (1, '2019-02-13 14:13:15.880', 4)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (2, '2019-03-26 11:54:04.750', 3)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (3, '2019-02-24 13:52:12.790', 1)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (4, '2019-02-27 12:16:41.300', 7)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (5, '2019-02-19 17:49:23.260', 3)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (6, '2019-02-09 11:02:14.020', 8)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (7, '2019-03-03 22:53:09.750', 4)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (8, '2019-03-15 14:53:03.480', 8)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (9, '2019-03-28 23:10:31.780', 5)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (10, '2019-03-04 11:07:00.680', 2)
GO
SET IDENTITY_INSERT dbo.Schedule OFF
GO

--
-- Inserting data into table dbo.Settings
--
SET IDENTITY_INSERT dbo.Settings ON
GO
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (1, 5)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (2, 1)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (3, 4)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (4, 3)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (5, 1)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (6, 5)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (7, 3)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (8, 4)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (9, 3)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (10, 2)
GO
SET IDENTITY_INSERT dbo.Settings OFF
GO

--
-- Inserting data into table dbo.Account
--
SET IDENTITY_INSERT dbo.Account ON
GO
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier) VALUES (6, N'061A269220293916GY', N'Bolt@nowhere.com', N'Letha', N'Wahl', '1950-03-09', N'(459) 613-9467')
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier) VALUES (10, N'D4G1H66LQ8SI15W457', N'Morehead@example.com', N'Kraig', N'Boucher', '1930-03-09', N'(730) 955-6764')
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier) VALUES (2, N'5115I09IOJ232X9E64WZ507C02627871M5U1V6', N'qpzre411@example.com', N'Harlan', N'Ludwig', '1981-09-13', N'(681) 747-0352')
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier) VALUES (7, N'NAMS722HRM8INU36V71KJ12T6S09DCX7JHN4N3USVDCUE720Y0KCZ', N'Bray162@example.com', N'Brad', N'Craven', '1978-10-25', N'(513) 643-0254')
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier) VALUES (3, N'D8257J9C9HT2W39O2QGSX55MD8WQ4V48JVFPP', N'Sidney_Agnew3@nowhere.com', N'Enrique', N'Sizemore', '1951-03-23', N'(776) 960-1978')
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier) VALUES (8, N'74198D85DH', N'xmhz1900@nowhere.com', N'Bennie', N'Flowers', '1964-03-15', N'(943) 664-5705')
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier) VALUES (4, N'B1XLA34H7BP8U098SA9NB4RU5W92', N'Monroe.Rinehart@nowhere.com', N'Francis', N'Conway', '1972-04-02', N'(282) 510-9326')
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier) VALUES (9, N'9SKKLJB914O9J5U80I57Q', N'Gutierrez73@example.com', N'Nickie', N'Waite', '2002-03-09', N'(350) 234-6559')
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier) VALUES (5, N'UK311H1D5I0530I', N'FelipaAbernathy@nowhere.com', N'Boyd', N'Skaggs', NULL, N'(157) 934-3116')
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier) VALUES (1, N'83HED0WQMG0RNZ23CLW0U21', N'Adler@example.com', N'Alonzo', N'Peacock', '1944-10-28', N'(465) 454-8347')
GO
SET IDENTITY_INSERT dbo.Account OFF
GO

--
-- Inserting data into table dbo.CreativeTeamMember_TR
--
SET IDENTITY_INSERT dbo.CreativeTeamMember_TR ON
GO
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (1, 4, 3, N'Conrad', N'Baumann')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (2, 5, 3, N'������', N'��������')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (3, 1, 8, N'Micheal', N'Neeley')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (4, 3, 2, N'Adam', N'Reyes')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (5, 4, 10, N'Kittie', N'Mathews')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (6, 4, 6, N'Stefani', N'Keenan')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (7, 3, 10, N'Madelene', N'Neely')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (8, 4, 8, N'Ramiro', N'Galindo')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (9, 2, 9, N'�����', N'�������')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (10, 5, 7, N'������', N'�������')
GO
SET IDENTITY_INSERT dbo.CreativeTeamMember_TR OFF
GO

--
-- Inserting data into table dbo.GalleryImage
--
SET IDENTITY_INSERT dbo.GalleryImage ON
GO
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (1, 0x06081A0B07C55EB32309648F63F42A8EF75CEA460190A0F3A81FD403381004ADFD6606866190450B1E599E032EC265, 3)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (2, 0xC0939EFEE3211C12B70D9BDD273FABCABAACD08FBEB9DBE4226301346239E298B2651402E2FD63C93B0E051867400B06F044050C40449101777E62B04FF47C, 3)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (3, 0x1494763EDD5E2E, 8)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (4, 0x1F8F7E03028BA45B2023509A356AFA150D4EDD06FCA6D9, 2)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (5, 0x929BBE9FCB6C7C1023D39B47DE1D, 10)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (6, 0x52DB030807D1505BE555CD9BC629472F092205DA4B1214944A5EBA3954F97093CD3B1725DC4145470FA804070992E21CAB, 6)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (7, 0xA4B18FB9231BB78B704EBD516183178F862F60BAE1BA094F068E3035A4BF269608C338955A2600BF1D04A219C8EE7F52CEB368E73FAE63381C390769A9491204A452D93080E8D0462F03070333E01BBE64CE7AE65209B836699D54AAFC48D102BFCBFD8F7431F7D5054FCBC20963525A1184A156F328FBC3AF62, 10)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (8, 0x0FC036E85E5AE8CF09C6BB8F022390C7D97E1FF00FE392C4164DB0D6AC2B11525F5106A1893D5862820002DA2875150F399CAF6607C279E837CD321D7E22C36C6206D37A01692D2656B0F6B4038C5E4D0608D4F64DC1AA2508BB124B004219F360FC9D196FA2815854, 8)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (9, 0x4A4626AE82B942343ED3D9F3208B0507E0248074AE15A63B44911E5358478373BC068EB42C40000EDC2C027EE6BDFE90069A, 9)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (10, 0x079E5E51E35E08A9C4F6EBFCFE3DF3113527F2035817B235676A79B6E0E08A251E8A0960B031BC2263A2A507E9D7054FC9173D64219702436F56C04C05C72396F7EAF9644ACB3955606006CD00181BC1E489B0DC70BFE3194874A2045BE059E39DAC2E1B4B6697DE84038B40CE56F99005BB002F4CE868D937935D8697695BB600D81F3BB2FCF843A8AC79432DD037DE086BC691993783B306872E27F620169FA8C15479F5DDE24201CC77975176360D, NULL)
GO
SET IDENTITY_INSERT dbo.GalleryImage OFF
GO

--
-- Inserting data into table dbo.HashTag_Performance
--
SET IDENTITY_INSERT dbo.HashTag_Performance ON
GO
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (1, 6, 3)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (2, 4, 9)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (3, 6, 2)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (4, 3, 8)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (5, 8, 2)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (6, 5, 3)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (7, 3, 4)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (8, 5, 4)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (9, 6, 9)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (10, 2, 1)
GO
SET IDENTITY_INSERT dbo.HashTag_Performance OFF
GO

--
-- Inserting data into table dbo.HashTag_TR
--
SET IDENTITY_INSERT dbo.HashTag_TR ON
GO
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (1, N'#do ogl?dania rodzin', 3, 10)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (2, N'#�������� �������', 2, 10)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (3, N'#for family viewing', 1, 1)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (4, N'#juego adolescente', 4, 8)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (5, N'#nastoletnia gra', 3, 5)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (6, N'#pokaz kognitywny', 3, 5)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (7, N'#para ver en familia', 4, 7)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (8, N'#��� ��������� ���������', 5, 5)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (9, N'##��� �������� ���������', 2, 9)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (10, N'#teenage play', 1, 4)
GO
SET IDENTITY_INSERT dbo.HashTag_TR OFF
GO

--
-- Inserting data into table dbo.Performance_TR
--
SET IDENTITY_INSERT dbo.Performance_TR ON
GO
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (1, N'Tajemnica lasu', 3, 'Urokliwy las le?nik?w jest bardzo podobny do cz?owieka. S? w?r?d nich tak?e dobre i z?e stworzenia. Jedno jest fajne, aby zamrozi? dziecko, a drugie rozpaczliwie ratuje j?. Czy ma?a dziewczynka zagubiona w zimowym lesie znajdzie pomoc, by uciec przed z?ymi warunkami pogodowymi? Lub po prostu nauczy? si? odr??nia? prawd? od szczero?ci od hipokryzji i pochlebstw? Dowiedz si? z Dziewczyn?, co jest naprawd? wa?ne i konieczne w tym ?yciu, a co tylko psuje i bawi.', 4)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (2, N'Droga do Betlejem', 3, 'Sztuka "Droga do Betlejem" to wi?cej ni? opowie?? o narodzinach Jezusa. Los os?a, kt?ry nosi ma?ego ch?opca na rowerze, to opowie?? o tym, jak zosta? cz?owiekiem. Ma?y osio? szuka Boga i marzy o zostaniu gwiazd?. Czy zrozumie, jakie jest jego powo?anie? Odpowied? na to pytanie mo?e by? przeszukiwana przez ca?? rodzin? w spektaklu "Droga do Betlejem".', 9)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (3, N'�����', 5, '�� ������������ ������������ �. ���������. ���������� ������ �������� ����� ����������� � ������������� ��������� "�����". �������, ������� �� ���� � �������� ������������ ����������� ����� ������������������ ����� ��������, ��� ������ ������. ��� ������������� ������� ������ �������� ��� �������� �� ���� �� �������. ������ � ����� � ��������� ������������ ������������ �������� ������ ��������.', 4)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (4, N'����������� ���', 5, '�� ������ �� �������. ��� ��������� ��������� - �� 3 �� 103 ���. ��������� ���� ��� ���� ����� ���-��� ��������! ����������� � ��� ��������� ������ � ������������ �������� � ������ ����������� �����������. ������� ����������� � ����� ��������, ���� ����� �������� ����� ��� ����� � ���������� ����� �� ���. �� ��������� ��������� ������ � ������ ����������� � ��������� ������, ��� ����� ���� ������������ ����������� � ��� ����� �������� �������� ��������, ������ � ������. ������ ���� �������� ��������� �������, ������� ��������� � ���� ��������. ��������� �������� ����������� ��������� � ���������, ��������� � ���������� ����������� �����������.', 8)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (5, N'Sadzonki cedru', 3, 'Spektakl "The Cherry Seducer" jest wizualnym ?wi?tem duszy. Wdycha wiosn? i przyci?ga jej ?yw? scenografi?, kt?ra pog??bia ?wiatopogl?d Tarasa Szewczenki. Energia poezji wype?nia spektakl g??bokim znaczeniem, kt?re staje si? jasne dla wszystkich. B?dziesz zaskoczony animacj? piasku, kt?ra jest filigranowa po??czona z niezwyk?ym muzycznym designem. Ten spektakl nie pozostanie oboj?tny dla tych, kt?rzy doceniaj? nowe oblicza na drodze do zrozumienia tw?rczo?ci T. Szewczenki.', 3)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (6, N'Goat-Dereza', 1, 'Once, one very cunning Goat got into one very good family, where she was terribly loved by all. But most of all cares about her master. And it would have been nice if Goat was not such a "Dereza"! Despite the love of the family, Goza has been tricked, deceived and behaved very nicely with their masters. Do you know what happens with dishonest kits? This is a fairy tale telling you about it.', 10)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (7, N'Fortuna de miel', 4, '?Qu? dif?cil es superar tu pereza! Cuando un peque?o Toro no quiere trabajar, est? listo para todo para que no lo ocupe. Y, una vez, huy? del abuelo con Babu al bosque. ?Pero una libertad tan atractiva no era tan f?cil! ?Este dif?cil viaje ense?ar? a nuestro h?roe a amar el trabajo y su hogar?', 4)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (8, N'��� ������� �������', 2, '����� ��� �����-����� ����� ��� ������� �� ���� ������� ����. � �� �� ����� ���� ������� ������ ��� �����, ���� �������� �� ��������� � ������? ��� �� �������, �� �������� ��������� ����� ������� �������� ���������. ����������� �� ������ �������� �������, ������������ � ���� ����� ������ �� �������� ��� ��� � ��������� �� ���� ������ �� ������!', 6)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (9, N'Chanterelle, gato y gallo', 4, 'Viv?an un gato y una polla para s? mismos. Juntos lograron y cantaron canciones. Pero una vez un astuto zorro rob? un gallo y un valiente gatito tuvo que salvarlo. Sin embargo, esta maldita aventura solo favoreci? a la imprudente cucaracha: se volvi? valiente y prometi? obedecer a su hermano. Recomendamos este espect?culo para peque?os espectadores.', 2)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (10, N'ʳ� � �������', 2, '������� �� ������ ��������� ������������ ����������� ����� ����� �ʳ� � ��������. �������� ������� � ���� ������� �������� ��� ������������� ����, �������� ������ �� ��� ��, �� ���� ���������� �����, ���� � �����, ������������� �� ��� � ����. �� �������, ��������, ������ ������ �� �������� �������� ��������� ��������.', 6)
GO
SET IDENTITY_INSERT dbo.Performance_TR OFF
GO

--
-- Inserting data into table dbo.PerformanceCreativeTeamMember_TR
--
SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember_TR ON
GO
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (1, N'��������', 5, 2)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (2, N'����������', 5, 4)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (3, N'Core?grafo', 4, 5)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (4, N'Producer', 1, 2)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (5, N'Kompozytor', 3, 6)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (6, N'��������', 5, 7)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (7, N'Dirigido por', 4, 9)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (8, N'����������', 2, 7)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (9, N'���������', 5, 8)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (10, N'Kompozytor', 3, 2)
GO
SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember_TR OFF
GO

--
-- Inserting data into table dbo.Watchlist
--
INSERT dbo.Watchlist(AccountId, ScheduleId) VALUES (1, 10)
INSERT dbo.Watchlist(AccountId, ScheduleId) VALUES (3, 5)
INSERT dbo.Watchlist(AccountId, ScheduleId) VALUES (6, 1)
INSERT dbo.Watchlist(AccountId, ScheduleId) VALUES (8, 6)
INSERT dbo.Watchlist(AccountId, ScheduleId) VALUES (10, 2)
INSERT dbo.Watchlist(AccountId, ScheduleId) VALUES (4, 7)
INSERT dbo.Watchlist(AccountId, ScheduleId) VALUES (2, 3)
INSERT dbo.Watchlist(AccountId, ScheduleId) VALUES (9, 8)
INSERT dbo.Watchlist(AccountId, ScheduleId) VALUES (7, 4)
INSERT dbo.Watchlist(AccountId, ScheduleId) VALUES (5, 9)
GO