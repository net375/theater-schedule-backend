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
INSERT dbo.Language(LanguageId, LanguageName) VALUES (2, N'Ukrainian')
INSERT dbo.Language(LanguageId, LanguageName) VALUES (3, N'Polish')
INSERT dbo.Language(LanguageId, LanguageName) VALUES (4, N'Spanish')
INSERT dbo.Language(LanguageId, LanguageName) VALUES (5, N'Russian')
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
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (2, 5, 3, N'Morgan', N'Renteria')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (3, 1, 8, N'Micheal', N'Neeley')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (4, 3, 2, N'Adam', N'Reyes')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (5, 4, 10, N'Kittie', N'Mathews')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (6, 4, 6, N'Stefani', N'Keenan')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (7, 3, 10, N'Madelene', N'Neely')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (8, 4, 8, N'Ramiro', N'Galindo')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (9, 2, 9, N'Abraham', N'Cary')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (10, 5, 7, N'Amos', N'Reyna')
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
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (1, N'#polishTag1', 3, 10)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (2, N'#ukrainianTag2', 2, 10)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (3, N'#englishTag3', 1, 1)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (4, N'#spanishTag4', 4, 8)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (5, N'#polishTag5', 3, 5)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (6, N'#polishTag6', 3, 5)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (7, N'#spanishTag7', 4, 7)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (8, N'#russianTag8', 5, 5)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (9, N'#ukrainianTag9', 2, 9)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (10, N'#englishTag10', 1, 4)
GO
SET IDENTITY_INSERT dbo.HashTag_TR OFF
GO

--
-- Inserting data into table dbo.Performance_TR
--
SET IDENTITY_INSERT dbo.Performance_TR ON
GO
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (1, N'Cinderella', 3, 'Labore inventore est dolorum quia dolor ad voluptatem nulla error recusandae voluptas accusantium iste ea; amet nisi, recusandae ut voluptas quam nihil ipsam eos suscipit consequatur hic reprehenderit ut illum...
Molestiae aut, officiis aut reprehenderit omnis natus dolore unde iste sit non voluptatem reprehenderit esse. Eaque excepturi aut exercitationem recusandae quia perspiciatis et quod perspiciatis sint error molestiae voluptate dolore. Quibusdam voluptatem cum perspiciatis animi ut perspiciatis amet perspiciatis minima illo iusto laboriosam aut perspiciatis. Est repellendus dolores et sint quo illo accusantium error sed, sunt rerum et iste necessitatibus! Nobis delectus corrupti, repudiandae esse temporibus laudantium et iste iure sit error iste cupiditate consequatur. Sequi excepturi eum dolorum necessitatibus error omnis maiores, placeat minus adipisci quia distinctio error consectetur; ut explicabo omnis sed temporibus sint, labore mollitia itaque exercitationem perspiciatis quibusdam vitae beatae est. Sunt voluptatibus tempora iusto sit quia impedit omnis nobis ex sunt tempore culpa dolor voluptatem! Tempora ullam aut voluptatem rerum consequatur minima accusantium laborum a nostrum, consequuntur aut magnam qui. Et veritatis, autem veniam veritatis omnis quae odit omnis quo tempore ut suscipit fugiat aut. Quam iste consequatur deleniti a recusandae totam minima sed quis voluptas modi consequatur similique ad! Nisi molestiae fugiat dicta saepe sunt natus consectetur numquam est at aperiam corrupti natus iste. Unde quidem hic perspiciatis, et ut corporis in accusamus nihil perspiciatis atque expedita aut quo? Necessitatibus est iste sit, libero sit veritatis cumque similique dolore ex sunt similique illum molestiae. Voluptas rerum sed, ducimus eum possimus dignissimos et vel praesentium eum quisquam asperiores sit consequatur. Quas explicabo velit voluptatem rerum aliquid obcaecati ut sequi quia illo accusamus aut sit aut. A amet voluptates sed molestiae cupiditate est minus voluptates quidem in sapiente molestias aut maxime.
Aut qui, rerum quos libero voluptatem eos eligendi fugit sunt obcaecati dolor consequatur temporibus natus. Aut quia quis porro doloremque esse voluptatibus qui quaerat deleniti laborum aut ut vitae unde; doloribus molestiae atque autem aut dolorum nihil natus est libero dolorem minus ipsum modi sed? Dignissimos sit voluptas ut qui soluta fuga at iste natus et aut alias perspiciatis itaque. Cum repudiandae vel non ducimus sequi sed omnis aperiam nesciunt eligendi accusamus voluptas sunt dicta. Est vitae nihil minus, eos nobis distinctio velit perferendis tempore numquam necessitatibus vel obcaecati ab.', 4)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (2, N'Big Claus and little Claus', 3, 'Incidunt natus laborum, consectetur et omnis nulla magnam quam molestiae autem eos pariatur omnis ratione. Veniam voluptatum placeat maiores ut quasi et eligendi explicabo suscipit inventore deserunt omnis voluptatem ea. Vitae qui, unde et culpa aut omnis veritatis eos accusantium voluptatum iure et ullam autem? Quibusdam qui eligendi perspiciatis, aut natus debitis iure repellat unde non vel est architecto iste. Ea quis animi voluptates repellat sint ab dolorem dignissimos sapiente rerum voluptatem iusto voluptas optio! Facere libero sed ea inventore consequatur aut alias assumenda ut placeat quia sint dolores optio. Voluptatum aliquam sint quia id quis omnis aliquid aperiam unde aut in eos repudiandae quasi? Totam ullam quia laudantium error aut illum similique ipsum velit in voluptatem dicta aspernatur officiis. Saepe laborum et accusantium voluptatem dolores et aut inventore dolor inventore officia omnis laborum a? Et quas esse voluptatem et, voluptatem unde quis ut qui et error laboriosam eaque voluptates! Amet necessitatibus fuga sequi quo perspiciatis eum et accusantium eaque beatae necessitatibus fugiat impedit qui. Quas vel et omnis ut reprehenderit dolorem, assumenda quis rem sed provident iure aliquid et? Perferendis distinctio velit laborum enim tempora maiores officia nam voluptate voluptatem vitae aut sit velit. Maiores cumque modi eius, hic ratione porro quidem totam accusantium ea enim non quia sequi. Recusandae totam voluptas dignissimos labore harum odit et eligendi magni quaerat illo ad quibusdam libero! Porro ad, dignissimos officiis delectus sapiente molestiae eaque nihil commodi vel incidunt accusantium nisi ipsa.
Tempore tempora et sit dolores similique ut modi ratione optio sit quas animi eaque error. Veritatis eum error repellat unde, omnis saepe in quisquam delectus nostrum et deserunt possimus eveniet! Minima enim voluptatem, maiores in sit distinctio corrupti et facere eum iure quod nihil eum. Est fuga fugit, ipsam quod unde error esse aut enim aut delectus totam alias nulla. Voluptas qui illum totam qui iure perspiciatis qui sint non perferendis exercitationem est qui rerum? Dolorum sed, cum assumenda aut nobis animi non incidunt nobis consequuntur beatae qui quaerat eligendi! Eum qui magnam aut similique possimus qui unde sit, eaque sit quas voluptatem tenetur ea; sunt non natus omnis sapiente sed quia fugiat, qui ipsam consequatur voluptate consectetur perspiciatis ullam; accusamus perspiciatis quis distinctio omnis repudiandae dolorem sunt sit autem quasi, aut rerum sed iste? Voluptatum minima voluptas dicta dolores debitis illo quia omnis reiciendis possimus dolores reprehenderit eum aspernatur; quia optio sed aliquam nihil possimus molestias qui ea illum iure recusandae quia minima tempore. Facere omnis inventore illo error est aliquid, nulla sed magnam ex dolore iusto unde labore! Eligendi aut, consequuntur suscipit quas rerum ullam sed numquam sit animi iste quia ad qui. Aliquam quia voluptatem omnis deleniti qui similique architecto, ducimus nihil qui atque iste error rerum! Eaque aut quas pariatur et fugit enim doloribus exercitationem doloribus nulla voluptatem sit dolor dolorem. Numquam saepe ex impedit ea nostrum sapiente nobis at, quia nisi omnis sit tempora sed? Repellendus vero laudantium quia, modi est sed quia dolores provident molestiae laudantium molestias enim obcaecati. Rerum voluptatem quae molestias ea neque consectetur accusantium aut numquam blanditiis nihil ad quam odit...', 9)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (3, N'Wild Swans', 5, 'Adipisci doloribus et animi aut velit nobis tempore asperiores rem quia veniam voluptas a amet.', 4)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (4, N'Thumbnail', 5, 'Cupiditate ex, facilis qui est cumque et impedit exercitationem numquam perferendis obcaecati fugit ipsam voluptates. Placeat modi commodi unde vel tempora eum iste architecto assumenda eius dolor et magnam sed. Accusantium deserunt sit neque, sit facere ipsa qui ad sed modi quasi atque est qui; porro voluptates consequatur sed quas nostrum sed aut consequatur mollitia dolores natus eligendi vero architecto. Sit id quaerat nesciunt iusto, labore nulla aliquid vel non et in est quibusdam vel? Ea et molestiae quam vel non esse dolorem unde sit dolorem quo rerum delectus aut! Recusandae enim nihil enim quo aliquid omnis sit nemo natus est enim quam ipsum consequatur. Dolore quos doloremque est deleniti dignissimos, fugit sed molestias fugiat omnis et est sit et; ut voluptatibus in ut omnis officia et perspiciatis ab minus voluptatibus iste enim praesentium deleniti. Omnis inventore harum perspiciatis sed odit debitis ut reiciendis sint dignissimos consequatur omnis neque voluptatem. Vel a, maxime mollitia harum unde id temporibus exercitationem fugit odit rem et quia et. Rem et debitis excepturi minus vitae unde quia perspiciatis ipsa itaque perferendis quod quaerat dolorem; illum porro est inventore adipisci sequi nam, dignissimos sed amet quo accusantium quia et ipsum. Enim impedit, sed qui error adipisci impedit perspiciatis voluptatem ipsa ducimus natus magnam perspiciatis placeat. Repellat sit natus perspiciatis nemo sed dicta aut impedit quia odit similique ullam magni omnis. Est ex, quas sunt quos ut perferendis est ullam sit natus fugiat ipsa delectus dolorem...
Qui velit nobis aperiam non possimus atque nisi omnis odit laudantium et beatae cum rem.
Distinctio provident dolor voluptatem sunt natus, blanditiis rem laudantium ut sed ipsa delectus molestiae eligendi. Quibusdam amet quis sunt sed nemo quos autem sit saepe velit et eveniet est numquam! Cum sed impedit ut at et facilis repudiandae distinctio unde rerum nobis fugit est quisquam. Quae qui dolores ratione sunt sed eos quam est minima fuga quo magni aut quasi.', 8)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (5, N'Stork', 3, 'Impedit sed qui, perspiciatis enim sit minus ratione sit quae sed architecto libero voluptas voluptatem. Esse corporis eum id assumenda, expedita ex est quos consequuntur sit illo ut neque voluptatum. Et tempora voluptas est reiciendis dolor assumenda quo doloribus aut qui ut laborum omnis ullam? Et voluptatem, harum est facere consectetur saepe consequuntur et quas eos dignissimos laborum et consectetur. Magnam eveniet quod tenetur consequatur inventore aut ut fugit non incidunt aut ullam impedit nostrum. Officia dolores numquam veniam sed fuga error et asperiores alias suscipit culpa cum modi officia!
Sed non similique dicta cum fugiat voluptas porro ut aut consequuntur eos ut dolore veniam. Natus excepturi maxime quisquam qui sit unde iste esse deleniti aut ab quia distinctio reprehenderit? Eos voluptas debitis quae tempore error quaerat obcaecati non aut nostrum rem repellendus voluptas dicta! Alias provident, perferendis id quidem ut corrupti fugiat minus qui asperiores necessitatibus nihil est et. Ut est eaque porro, aut fuga numquam unde eum eos et eos repellat nostrum quibusdam. Et aut quas quod, voluptatem maiores totam sint ut assumenda quia reprehenderit veniam sed est. Alias aut, quod error iusto ex natus nisi qui ex dolor unde nostrum non ratione. Ipsum eum quo dolorem totam, quia vitae qui aut molestias nesciunt sint consequatur id consectetur! Voluptatem quaerat blanditiis, veniam iste pariatur suscipit eaque et error ea ducimus quasi voluptatum nesciunt. Quia necessitatibus quod ea praesentium cum aspernatur et, hic provident distinctio quia a ut architecto. Iste vel, ducimus unde commodi praesentium neque aut nemo veniam ut eius et recusandae incidunt. Impedit est mollitia omnis ullam unde placeat fugit sit quis, harum fugit omnis voluptas soluta. Sint et voluptatem repellendus labore magni velit mollitia, esse sit laboriosam maxime dolores ipsum sed. Et tempora ducimus repellendus molestiae consequatur autem obcaecati et quo doloremque sint ullam corporis ullam. Vel molestias distinctio ea doloribus eius fuga nesciunt blanditiis neque voluptas eius qui eius voluptatem. Et nihil quasi sed nihil similique vero quasi quia est et hic unde reiciendis odit.
Sunt tempore qui maxime nostrum aliquam omnis fugit temporibus quisquam consequatur eaque enim ipsum omnis. Eum numquam eligendi rem minus est natus odit reprehenderit sint error ratione tenetur nihil sequi. Ut recusandae iusto vel ea amet nobis ad qui molestias consequatur error incidunt tempora cupiditate. Architecto rerum odio est unde eum vel qui modi velit esse ullam optio maiores cupiditate! Hic dolores omnis sit cumque facilis ut vitae eos omnis nam et est perferendis incidunt. Molestiae animi error exercitationem eos ex voluptatem nihil ipsa voluptatem iure sequi omnis ipsa in. Natus rem voluptatem dignissimos, corporis perspiciatis aut natus dolor aut aliquid minus animi quia sunt!', 3)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (6, N'Flying chest', 1, 'Modi cum nulla asperiores consequatur id quibusdam eaque quia esse distinctio perspiciatis similique blanditiis ad. Dolorem vitae qui velit recusandae unde consectetur perferendis eveniet et qui obcaecati officia vitae cumque. Natus culpa perspiciatis doloremque facere et qui fuga quo ex tenetur quidem recusandae culpa rerum! Ex sit delectus autem et ut sapiente id ut reiciendis consequatur omnis sit corporis qui. Iste voluptatibus temporibus quas quia dolor ullam omnis aut officiis ut doloremque totam corporis et. Saepe voluptatum, ad autem praesentium sit et ipsa iste nisi non ea neque sint recusandae. Rerum aut non quia qui omnis, ipsum iusto quia dolor vero rerum rem mollitia distinctio! Enim accusantium magni qui, error libero error unde aliquam et perspiciatis similique vitae minus error. Sed architecto ut autem hic commodi consequatur eos vel saepe similique error quia qui est! Sit ea ut doloremque eos labore est eos cumque voluptas qui corrupti explicabo possimus omnis? A accusantium eaque officiis nisi molestiae facilis eaque voluptatem sit est iste iusto et ut. Ut enim nulla voluptas aut, totam veritatis distinctio perspiciatis dicta numquam ea voluptatem ullam expedita. Est aut cupiditate quae omnis velit voluptas, minima corrupti dicta non quaerat labore vero enim! Eveniet vel consequuntur animi nostrum tempora eaque temporibus praesentium laboriosam et enim consequatur tenetur dolores? Nihil ad aut, est tenetur rerum qui aut eum consequuntur illo laborum quidem molestiae quibusdam. Sapiente atque voluptates vero sit provident neque quis rerum quis quisquam, ipsum esse id sunt.', 10)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (7, N'Linen', 4, 'Eos corporis quas accusantium eos modi est nesciunt ut expedita labore asperiores est unde sunt. Temporibus deserunt unde quod sed ducimus qui deserunt rerum illo sequi qui ea quis incidunt. Ex in voluptatem, eum sit sed corporis dolorem inventore animi illum est sit vel iste! Similique ut beatae vel et earum quod et numquam ut non voluptas nobis voluptatem dicta. Nesciunt alias eum debitis dolorem fuga ut voluptates iure ea possimus dolorem accusamus aspernatur eius. Omnis similique officia id exercitationem quidem non necessitatibus unde fugit et sed impedit non et.', 4)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (8, N'Butterfly', 2, 'In saepe error quisquam sed ab est deleniti id dolorum natus aut temporibus doloremque minima. Modi praesentium quaerat consectetur aut enim eum dolor temporibus ratione qui dolor voluptatem aspernatur vel. Aliquam voluptatem magnam quia vitae facilis officia et culpa id velit magni enim tempore soluta. Modi et consequatur voluptatibus provident et iste qui quidem nihil suscipit fuga accusamus architecto aliquam? Voluptatum incidunt sunt, minima laboriosam iure aperiam reiciendis dignissimos expedita rem nihil alias explicabo suscipit. Eaque et explicabo, incidunt soluta tenetur et fuga sint fugit dolore repudiandae temporibus atque recusandae. Aut hic enim, hic nulla dolore voluptate unde id optio voluptate consequatur aut obcaecati odio. Sed quasi omnis et odit unde voluptatum labore, nihil sed nemo et voluptatem dolorem quasi! Hic quo nostrum, assumenda in molestiae sed rerum dignissimos odio et natus eaque error natus. Maiores dolore quod, et saepe blanditiis est natus nam corrupti ut tempora beatae voluptatem voluptate; et omnis, dolorum voluptate eveniet enim aut ut sequi atque eius quasi velit quia sed. Dolores eum, quasi beatae fugiat a sed et qui et quis aliquam dolor est exercitationem. Dolorum rem error sunt architecto accusamus a qui et ut fuga dolorem iure quo impedit. Error hic porro, et illo dolor illum sit error omnis numquam impedit velit distinctio in! Corporis officiis consequatur fuga aperiam libero tempore obcaecati dolorem dolor non et ea enim aut. Officia et perspiciatis optio dolorem est cumque sit temporibus omnis totam perspiciatis ut totam consequatur! Harum qui sit odit nisi aut et error odio enim ut voluptatem error recusandae debitis.
Fugiat delectus eum, ratione sed ad nostrum dicta sapiente perspiciatis rerum ipsam consectetur unde vitae. Id quasi dolores totam ipsum consequuntur vitae molestiae cupiditate nulla et quia quos suscipit obcaecati; velit perspiciatis natus accusantium atque explicabo et asperiores nostrum ut aut rerum velit amet quis. Et quia, nostrum earum voluptatum aut porro distinctio omnis error corporis tempora sapiente velit mollitia. Iure ipsum molestiae, eaque at perspiciatis perferendis aut enim officia suscipit omnis fugit aut ut! Perspiciatis culpa laboriosam in ea ut nesciunt qui in et sunt porro enim esse tempore; porro doloremque, saepe perferendis voluptatem consequatur nostrum amet perspiciatis voluptates perspiciatis ratione omnis perspiciatis quis. Iusto est minima voluptatum laborum aut nesciunt reprehenderit sed molestiae architecto pariatur dicta aut autem. Omnis repudiandae ab quis vel et deserunt et, rerum qui natus perspiciatis quia est excepturi. Odio ullam soluta facere error non id et perspiciatis id consectetur sit qui architecto vero? Pariatur sit provident, iste velit ipsum sit autem et beatae a omnis harum ducimus excepturi. Perspiciatis eos consequatur ipsam temporibus iste, dolore id nesciunt dolor delectus vero molestiae ut officiis! Commodi totam aliquam labore dolor accusantium impedit quisquam quasi esse dolorum totam deleniti obcaecati ex; enim sit ipsum natus esse, aut cupiditate vitae dicta sed unde perspiciatis ad laudantium unde. Vitae esse aliquid nobis rerum dolor cupiditate rerum nemo asperiores facere obcaecati, cum id magni.
Minus sunt aut sint ipsam minus officia quidem reiciendis dolores sint veritatis obcaecati cupiditate explicabo. Tenetur consequatur explicabo quis qui a ut magni iure et consequuntur neque est sunt molestias. Omnis minima excepturi similique temporibus quam consequuntur illum dolorum exercitationem aperiam atque tempore eveniet et. Quo ut et repellat minima ut culpa et nihil et molestiae, nemo atque ut sunt. Ut porro rerum ratione perspiciatis sapiente unde magni quis sunt omnis nemo in veritatis qui. Aliquam quasi voluptatem unde sed itaque nihil iste aspernatur distinctio aut obcaecati ipsa'
+ N' sit in. Ut corrupti voluptas voluptatem pariatur saepe amet minima modi unde modi qui labore reprehenderit molestiae.', 6)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (9, N'Pen and ink', 4, 'Vel perspiciatis ut eligendi quas, laudantium iusto sed consequatur provident vel non voluptatem dolor ut. Harum itaque labore in nam officia iste quisquam aut deleniti quo natus praesentium eum accusamus! Obcaecati iusto ipsa voluptas illo recusandae suscipit porro iste quam velit laborum explicabo est voluptatem. Earum in iste qui doloremque consequatur et minima unde deleniti illo expedita modi numquam sed...
Rerum qui voluptatibus sunt rem quia labore soluta odit autem consequuntur tempora unde sit cumque. Culpa asperiores ut repudiandae sed adipisci alias dolore minima maiores accusamus voluptatum iure libero ab. A dolor consequuntur totam, iusto harum ipsa ut expedita enim facere ut a nulla est? Atque voluptas ut quia delectus voluptatem quia dolores voluptatem et temporibus sequi quia numquam atque. Nihil ut veniam rem repellat quasi ad obcaecati ea ut quasi deleniti labore ut excepturi! Recusandae explicabo error sed eligendi sit aliquid doloremque velit sit quasi provident explicabo eligendi recusandae. Aspernatur ut assumenda doloribus nostrum sit commodi et doloremque veritatis vel architecto veniam ut et. Maiores quia sed dolorum, repellendus veritatis a voluptates consectetur sed aliquam voluptatem quasi incidunt qui. Nihil maiores eaque necessitatibus modi sunt ex ut, aut voluptate possimus nulla velit odio beatae.', 2)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (10, N'Shrek', 2, 'Autem sapiente fugit laudantium quae cumque ut rerum pariatur laudantium quisquam vero error voluptatem ut. Qui consectetur veniam beatae earum cum blanditiis debitis sunt unde omnis temporibus fuga necessitatibus ipsam! Nihil est non tempora repellat, earum debitis perspiciatis eveniet repellat quasi sed recusandae natus aut. Voluptate dolorem, quidem voluptas harum aut nostrum omnis sunt ullam dicta rerum pariatur sed eius...
Et aut nihil distinctio eum ab sit sed perferendis exercitationem et delectus aut similique et. Error facere sit necessitatibus architecto voluptas voluptatum mollitia et veniam iste ut optio ratione dolores. Voluptatum nulla exercitationem repellendus neque soluta odit dicta eaque vitae est aperiam corporis ipsam quidem.
Aut beatae expedita impedit voluptatem ut molestiae ea tempore voluptas magni sit omnis perspiciatis repudiandae. Iste ut, perferendis ab et minima soluta iure non eaque labore aut cumque sint et! Et voluptatem quidem qui fugit error suscipit quo molestiae incidunt sed soluta debitis sed eos. Dolor sint nulla aut rerum sapiente quia quod dolorem molestias iste quo quia facilis debitis. Quisquam minima inventore minima impedit aut dolorem, iste repellendus eaque eligendi a aut quia quo! Sequi qui sit incidunt ea est iste rerum sunt voluptatem natus ut molestiae aperiam ut. Architecto labore amet dolor nulla voluptas et fugiat molestias quaerat repellat perspiciatis iste officia voluptas. Ea delectus, sit rem consequatur dolorem magni vel voluptas omnis quia rerum esse qui consequatur! Exercitationem aperiam pariatur numquam officiis omnis laborum repellat obcaecati ea error quia sit et soluta. Porro labore facere sint totam officia atque ea veritatis voluptas vel et unde ut rerum! Sint quaerat dolorem omnis aut quaerat fugiat eos et aut consectetur aspernatur dolorem voluptatem quas; illo nisi, nulla voluptates error sunt qui sit voluptas omnis dolore commodi minima et eveniet. Enim vel enim harum aliquid quo voluptates ex et aliquam ut in quo qui quo. Ut commodi enim voluptas dolorum voluptas saepe magni aut laudantium maiores perspiciatis et architecto ea. Quam totam delectus, rerum alias et ad quod rem rerum et qui sunt sit veritatis.', 6)
GO
SET IDENTITY_INSERT dbo.Performance_TR OFF
GO

--
-- Inserting data into table dbo.PerformanceCreativeTeamMember_TR
--
SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember_TR ON
GO
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (1, N'Vice President', 5, 2)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (2, N'Secretary', 5, 4)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (3, N'Buying Agent', 4, 5)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (4, N'Sales Manager', 1, 2)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (5, N'Finance Manager', 3, 6)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (6, N'Buying Agent', 5, 7)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (7, N'Assistant Vice President', 4, 9)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (8, N'Chief Information Officer', 2, 7)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (9, N'Chief Technology Officer', 5, 8)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (10, N'Collection Manager', 3, 2)
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