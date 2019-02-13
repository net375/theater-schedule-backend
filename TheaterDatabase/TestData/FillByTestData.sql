SET QUOTED_IDENTIFIER ON

DELETE dbo.Watchlist
DELETE dbo.PerformanceCreativeTeamMember_TR
DELETE dbo.Performance_TR
DELETE dbo.HashTag_TR
DELETE dbo.HashTag_Performance
DELETE dbo.GalleryImage
DELETE dbo.CreativeTeamMember_TR
DELETE dbo.Message
DELETE dbo.Account
DELETE dbo.Settings
DELETE dbo.Schedule
DELETE dbo.PerformanceCreativeTeamMember
DELETE dbo.Performance
DELETE dbo.Language
DELETE dbo.HashTag
DELETE dbo.CreativeTeamMember


SET IDENTITY_INSERT dbo.CreativeTeamMember ON
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
SET IDENTITY_INSERT dbo.CreativeTeamMember OFF

SET IDENTITY_INSERT dbo.HashTag ON
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

SET IDENTITY_INSERT dbo.HashTag OFF
SET IDENTITY_INSERT dbo.Language ON

INSERT dbo.Language(LanguageId, LanguageName, LanguageCode) VALUES (1, N'English', 'en')
INSERT dbo.Language(LanguageId, LanguageName, LanguageCode) VALUES (2, N'Українська', 'uk')

SET IDENTITY_INSERT dbo.Language OFF
SET IDENTITY_INSERT dbo.Performance ON

INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (1, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\lisovychok_resize.jpg', SINGLE_BLOB) image), 83, 65, 408, 8)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (2, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\doroga_resize.jpg', SINGLE_BLOB) image), 126, 61, 400, 2)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (3, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\Taras_resize.jpg', SINGLE_BLOB) image), 114, 50, 430, 4)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (4, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\sny_resize.jpg', SINGLE_BLOB) image), 180, 62, 478, 3)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (5, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\sadok_resize.jpg', SINGLE_BLOB) image), 165, 54, 305, 2)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (6, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\Koza_resize.jpg', SINGLE_BLOB) image), 61, 52, 360, 5)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (7, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\pidkova_resize.jpg', SINGLE_BLOB) image), 135, 66, 346, 5)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (8, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\kolobok_resize.jpg', SINGLE_BLOB) image), 71, 55, 386, 5)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (9, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\kotyk_pivnyk_resize.jpg', SINGLE_BLOB) image), 126, 56, 462, 9)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (10, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\Cat_resize.jpg', SINGLE_BLOB) image), 159, 54, 340, 3)

SET IDENTITY_INSERT dbo.Performance OFF
SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember ON

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

SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember OFF
SET IDENTITY_INSERT dbo.Schedule ON

INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (1, '2019-02-13 14:13:15.880', 4)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (2, '2019-03-26 11:54:04.750', 3)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (3, '2019-02-24 13:52:12.790', 1)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (4, '2019-02-27 12:16:41.300', 7)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (5, '2019-02-19 17:49:23.260', 3)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (6, '2019-02-09 11:02:14.020', 8)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (7, '2019-03-03 22:53:09.750', 4)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (8, '2019-03-15 14:53:03.480', 8)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (9, '2019-03-28 23:10:31.780', 5)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (10,'2019-03-04 11:07:00.680', 2)

SET IDENTITY_INSERT dbo.Schedule OFF
SET IDENTITY_INSERT dbo.Settings ON

INSERT dbo.Settings(SettingsId, LanguageId) VALUES (1, 2)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (2, 1)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (3, 1)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (4, 2)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (5, 1)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (6, 2)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (7, 2)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (8, 1)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (9, 1)
INSERT dbo.Settings(SettingsId, LanguageId) VALUES (10, 2)

SET IDENTITY_INSERT dbo.Settings OFF
SET IDENTITY_INSERT dbo.Account ON

INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier, SettingsId) VALUES (6, N'061A269220293916GY',									   N'Bolt@nowhere.com           ',	         N'Letha  ',     N'Wahl    ',   '1950-03-09', N'(459) 613-9467 ', 1)
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier, SettingsId) VALUES (10,N'D4G1H66LQ8SI15W457',									   N'Morehead@example.com       ',           N'Kraig  ',     N'Boucher ',   '1930-03-09', N'(730) 955-6764 ',2)
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier, SettingsId) VALUES (2, N'5115I09IOJ232X9E64WZ507C02627871M5U1V6',				   N'qpzre411@example.com       ',           N'Harlan ',     N'Ludwig  ',   '1981-09-13', N'(681) 747-0352 ',3)
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier, SettingsId) VALUES (7, N'NAMS722HRM8INU36V71KJ12T6S09DCX7JHN4N3USVDCUE720Y0KCZ',   N'Bray162@example.com        ',           N'Brad   ',     N'Craven  ',   '1978-10-25', N'(513) 643-0254 ',4)
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier, SettingsId) VALUES (3, N'D8257J9C9HT2W39O2QGSX55MD8WQ4V48JVFPP',				   N'Sidney_Agnew3@nowhere.com  ',           N'Enrique',     N'Sizemore',   '1951-03-23', N'(776) 960-1978 ',5)
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier, SettingsId) VALUES (8, N'74198D85DH',											   N'xmhz1900@nowhere.com       ',	     	 N'Bennie ',     N'Flowers ',   '1964-03-15', N'(943) 664-5705 ',6)
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier, SettingsId) VALUES (4, N'B1XLA34H7BP8U098SA9NB4RU5W92',						       N'Monroe.Rinehart@nowhere.com',           N'Francis',     N'Conway  ',   '1972-04-02', N'(282) 510-9326 ',7)
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier, SettingsId) VALUES (9, N'9SKKLJB914O9J5U80I57Q',								   N'Gutierrez73@example.com    ',           N'Nickie ',     N'Waite+  ',   '2002-03-09', N'(350) 234-6559 ',8)
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier, SettingsId) VALUES (5, N'UK311H1D5I0530I',								      	   N'FelipaAbernathy@nowhere.com',           N'Boyd   ',     N'Skaggs  ', NULL   , N'(157) 934-3116',9)
INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier, SettingsId) VALUES (1, N'83HED0WQMG0RNZ23CLW0U21',						     	   N'Adler@example.com          ',           N'Alonzo ',     N'Peacock ', '1944-10-28', N'(465) 454-8347'  ,10)

SET IDENTITY_INSERT dbo.Account OFF
SET IDENTITY_INSERT dbo.Message ON

INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (1,  N'Mystery of the forest',        N'The best performance i have ever seen!',	N'Thank you for your message, it is important for us :)',3)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (2,  N'The road to Bethlehem',        N'Super!', N'Thank you for your message, it is important for us :)',8)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (3,  N'Тарас',                        N'Дуже цікава та пізнавальна вистава)', N'Дякуємо вам, надіюсь, ви гарно провели час)',10)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (4,  N'Cвяткові сни',                 N'Дуже цікава та пізнавальна вистава)', N'Дякуємо вам, надіюсь, ви гарно провели час)',5)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (5,  N'Cedar seedlings',              N'The best performance i have ever seen!',	N'Thank you, we do best for you)', 8)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (6,  N'Goat-Dereza',                  N'Amazing performance, I will come here again!', N'Thank you, we do best for you)',6)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (7,  N'Підкова на щастя',             N'Дякую за гарний проведений час, вистава була чудовою!' ,N'Дякуємо за відгук, ми завжди раді бачити задоволених клієнтів)',9)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (8,  N'Наш веселий колобок',          N'Дякую за гарний проведений час, вистава була чудовою!', N'Дякуємо за відгук, ми завжди раді бачити задоволених клієнтів)',7)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (9,  N'Chanterelle, Cat and Cockerel',N'Super!', N'Thank you for your message)',9)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (10, N'Кіт у чоботях ',               N'The best performance i have ever seen!',	N'Thank you for your message, it is important for us :)',7)

SET IDENTITY_INSERT dbo.Message OFF
SET IDENTITY_INSERT dbo.CreativeTeamMember_TR ON

INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (1, 1, 1,   N'Conrad', N'Baumann')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (2, 2, 2,   N'Михайло', N'Ніколаєв')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (3, 1, 3,   N'Micheal', N'Neeley')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (4, 2, 4,   N'Василь', N'Стадник')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (5, 2, 5,   N'Микола', N'Старицький')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (6, 1, 6,   N'Stefani', N'Keenan')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (7, 1, 7,   N'Madelene', N'Neely')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (8, 2, 8,   N'Олег', N'Лисович')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (9, 2, 9,   N'Каріна', N'Чепурна')
INSERT dbo.CreativeTeamMember_TR(CreativeTeamMember_TRId, LanguageId, CreativeTeamMemberId, FistName, LastName) VALUES (10, 2, 10, N'Сергій', N'Ковальов')

SET IDENTITY_INSERT dbo.CreativeTeamMember_TR OFF
SET IDENTITY_INSERT dbo.GalleryImage ON

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

SET IDENTITY_INSERT dbo.GalleryImage OFF
SET IDENTITY_INSERT dbo.HashTag_Performance ON

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

SET IDENTITY_INSERT dbo.HashTag_Performance OFF
SET IDENTITY_INSERT dbo.HashTag_TR ON

INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (1,  N'#for family viewing', 1, 10)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (2,  N'#підліткова вистава', 2, 10)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (3,  N'#for family viewing', 1, 1)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (4,  N'#підліткова вистава', 2, 8)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (5,  N'#for family viewing', 1, 5)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (6,  N'#підліткова вистава', 2, 5)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (7,  N'#підліткова вистава', 2, 7)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (8,  N'#for family viewing', 1, 5)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (9,  N'#підліткова вистава', 2, 9)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (10, N'#підліткова вистава', 2, 4)

SET IDENTITY_INSERT dbo.HashTag_TR OFF
SET IDENTITY_INSERT dbo.Performance_TR ON

INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (1,  N'Mystery of the forest', 1,         N'The charming forest of foresters is very similar to man. There are also good and evil creatures among them. One thing is cool to freeze the baby and the other desperately saves her. Will a little girl lost in the winter forest find help to escape the bad weather conditions? Or just learn to distinguish the truth from honesty and hypocrisy and flattery? Find out what is really important and necessary in this life with the Girl, which only spoils and amuses.', 1)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (2,  N'The road to Bethlehem', 1,         N'The play "The Way to Bethlehem" is more than a story about the birth of Jesus. The fate of a donkey who wears a small boy on a bicycle is a story about how to become a human. The little donkey is looking for God and dreams of becoming a star. Will he understand his calling? The answer to this question can be searched by the whole family in the play "The Way to Bethlehem".', 2)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (3,  N'Тарас', 2,                         N'За однойменним твором Б. Стельмаха. Пропонуємо вашій увазі дуже контрастний і символічний спектакль "Тарас". Дитина, яка не мала і половини можливостей сучасних людей продемонструвала своїм прикладом, що означає боротьба. Це дійсно історія успіху хлопчика без якого не було б України. Чорне і біле в спектаклі підкреслює унікальність особистості Тараса Шевченка.', 3)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (4,  N'Cвяткові сни', 2,                  N'Від Романа до Йордана. Для сімейного перегляду - від 3 до 103 років. Очікувана ніч для всіх дітей ось-ось настане! Святкові і його сестричка Дзвінка в передчутті подарунків і інших святкових приємностей. Нарешті влаштувавшись в своїх ліжках, діти раптом помічають яскравий промінь світла і негайно біжать за ним. За кілька миттєвостей Святко і Дзвінка виявляються в казковому мареві, де обох чекають дивовижні пригоди і де обом доведеться проявити мудрість, відвагу і любов. Натомість діти отримують чарівні подарунки, які залишаться з ними назавжди. Вистава наповнена етнічними символами і баченнями, колядками і прекрасним святковим настроєм.', 4)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (5,  N'Cedar seedlings', 1,               N'The performance "The Cherry Seducer" is a visual celebration of the soul. Breathes in the spring and attracted by her vivid set design, which deepens the worldview of Taras Shevchenko. The energy of poetry fills the show with deep meaning, which becomes clear to everyone. You will be surprised by the animation of sand, which is delicate and combined with an unusual musical design. This spectacle will not remain indifferent to those who appreciate new faces on the way to understanding the works of T. Shevchenko.', 5)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (6,  N'Goat-Dereza', 1,                   N'Once, one very cunning Goat got into one very good family, where she was terribly loved by all. But most of all cares about her master. And it would have been nice if Goat was not such a "Dereza"! Despite the love of the family, Goza has been tricked, deceived and behaved very nicely with their masters. Do you know what happens with dishonest kits? This is a fairy tale telling you about it.', 6)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (7,  N'Підкова на щастя', 2,              N'Як важко побороти свою лінь! Коли маленький Віслючок не хоче працювати – він ладен на все, щоб його не займали. І, одного разу, таки тікає від Діда з Бабою до лісу. Та така приваблива свобода виявилась не такою вже й простою! Чи зможе ця важка подорож навчити нашого героя любити роботу та свою домівку?', 7)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (8,  N'Наш веселий колобок', 2,           N'Кожен знає стару-добру казку про Колобка та його подорож лісом. А що як цього разу Колобок знайде собі друга, який допоможе не потрапити в халепу? Тоді всі загрози, що спіткають маленьких героїв стануть цікавими пригодами. Приєднуйтесь до нашого веселого Колобка, познайомтесь з його новим другом та проведіть свій час в казковому лісі дуже весело та цікаво!', 8)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (9,  N'Chanterelle, Cat and Cockerel', 1, N'Cat and Cockerel lived for themselves. Together they managed and sing songs. But once the cunning Fox stole the Cockerel, and the brave Cat had to save him. However, such an accursed adventure went only in favor of the reckless Hive - he became brave and in all promised to obey his brother. We recommend this show for small viewers.', 9)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (10, N'Кіт у чоботях', 2,                 N'Вистава за казкою видатного французького письменника Шарля Перро “Кіт у Чоботях”. Лялькова вистава в стилі “бароко” розповідає про винахідливого Кота, справжню дружбу та про те, що немає недосяжних цілей, якщо є розум, наполегливість та віра в себе. Це музичне, динамічне, веселе дійство не залишить байдужим маленьких глядачів.', 10)

SET IDENTITY_INSERT dbo.Performance_TR OFF
SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember_TR ON

INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (1,  N'Художник', 2, 1)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (2,  N'Композитор', 2, 2)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (3,  N'Choreographer', 1, 3)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (4,  N'Producer', 1, 4)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (5,  N'Composer', 1, 5)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (6,  N'Художник', 2, 6)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (7,  N'Хореограф', 2, 7)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (8,  N'Композитор', 2, 8)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (9,  N'Choreographer', 1, 9)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role, LanguageId, PerformanceCreativeTeamMemberId) VALUES (10, N'Composer', 1, 10)

SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember_TR OFF

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

