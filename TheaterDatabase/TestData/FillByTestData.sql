SET QUOTED_IDENTIFIER ON

DELETE dbo.Role_TR
DELETE dbo.Wishlist
DELETE dbo.PerformanceCreativeTeamMember_TR
DELETE dbo.Performance_TR
DELETE dbo.Message
DELETE dbo.HashTag_TR
DELETE dbo.HashTag_Performance
DELETE dbo.GalleryImage
DELETE dbo.Event_TR
DELETE dbo.CreativeTeamMember_TR
DELETE dbo.Account
DELETE dbo.Settings
DELETE dbo.Schedule
DELETE dbo.PerformanceCreativeTeamMember
DELETE dbo.Performance
DELETE dbo.Language
DELETE dbo.HashTag
DELETE dbo.Event
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

SET IDENTITY_INSERT dbo.[Event] ON
INSERT dbo.Event(EventId, Image, Date) VALUES (1, 0xB5469D005817D9000708A204E7A932601C29B1D8C534259D8510DC370407BEAF27F5D6F31132ADBBC00460267200F8CF03403BC889638B2FAA0358F207B6B8070A72BF44514B3195B60150BE5C7F7166A7095F089EBC39BF796982224A8D8A581F599C9C677D1F832A3B3E258F2209027E3B, '2023-12-11 16:13:25.590')
INSERT dbo.Event(EventId, Image, Date) VALUES (2, 0x2208410E1D0C0A24318E9CC9390D06E8DCD74F573C2D7699859AB72FEC0809EBA65E70F1, '2070-01-24 03:17:34.320')
INSERT dbo.Event(EventId, Image, Date) VALUES (3, 0x602E04B5F4F458AFB340FF53B1403321DB3F0EC05527F4131A07528AE6CB1429625A7575446E859C03EC4D5E109418DE988CD9, '2020-09-24 07:04:24.500')
INSERT dbo.Event(EventId, Image, Date) VALUES (4, 0x0492C91C023D47A1E7420A076631B76E722864856DB444601B6F799771E866BC29E0BB8AB74FDFB1A6003971C501B1E0394E5C, '2021-10-12 01:24:59.010')
INSERT dbo.Event(EventId, Image, Date) VALUES (5, 0x1839405872891551E7003F2E1CE30854760ACA03091D3B7B203C2F8627895B512D2977F1BFDABE3568020072FC1FC63C09E12BD8C7F51074C42AC7DBA500FEE28DB0C4380DE94D1E989AD58A045162E7A7C3EA9BB1226E08088C00021A11C2C6452BE3EA2B4683832542CA1E0A750924DA7D495753078CDB03E55A880A1762ED553411AF06D797989E06D630F10A99A5F7045F2CE606A15E8A02E187FF15, '2021-02-12 02:14:58.020')
INSERT dbo.Event(EventId, Image, Date) VALUES (6, 0x1603E6A66FCD070F0212E7411332F6458F82088B8029BDE40450BF63F823399D2E9563625703AD60FC1FE6CE89739408D20603DD27F40230A7BA4BBC804C, '2023-03-27 14:45:15.290')
INSERT dbo.Event(EventId, Image, Date) VALUES (7, 0x045506D306739C22E348CA9BBA9D5712FE1C3643A89E292B04038C294C42E128AFF449090526D52F6745C88FDC50041C68CE232ABFE736F96EB5DC06C508480231DECA1A8E44DF8398FB80E50DACE399BE274B1A85ABC4CE63, '2026-11-28 18:40:17.090')
INSERT dbo.Event(EventId, Image, Date) VALUES (8, 0x3160DD39FD2F58EE07E606C81056D532D7020258087F536A575A03D5C03689782F924232FF90A100E805220928B307E44B04FD7A057C4BC4245019A5A02E9AC2B3009B552B0362ABA189D7035C762EFBB8579F5DC161FDA104F175C74812A97C04001DA73405895DB0116ED16CFE33CC84696F4C07EE323B02CE7F005FCC5A07CF7DF20450A14FD90B5C0C6D071582D7221FC80B80F07E140427, '2025-02-01 18:09:36.280')
INSERT dbo.Event(EventId, Image, Date) VALUES (9, 0xB3CB017FAF32000601297223B240A76A7E909E0449E05D1A8E062683AA104FE1F6D77199B00278705D26DF22AEA6926B8677DE0C070000DA8C33EBEE49268FEE9E07088C8DFFB1CAD3A8B67504C62439A9, '2020-09-04 01:21:03.520')
INSERT dbo.Event(EventId, Image, Date) VALUES (10, 0x6DF23E3D52C2F9462FA07B43CF0F53A070DAE6592E5BE3F05206440C69EFD6D7495C59, '2021-05-22 17:16:52.150')
SET IDENTITY_INSERT dbo.[Event] OFF

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
INSERT dbo.Language(LanguageId, LanguageCode) VALUES (1, 'en')
INSERT dbo.Language(LanguageId, LanguageCode) VALUES (2, 'uk')
SET IDENTITY_INSERT dbo.Language OFF

-- SET IDENTITY_INSERT dbo.Performance ON
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (176, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\lisovychok_resize.jpg', SINGLE_BLOB) image), 83, 65, 408, 8)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (399, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\doroga_resize.jpg', SINGLE_BLOB) image), 126, 61, 400, 2)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (104, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\Taras_resize.jpg', SINGLE_BLOB) image), 114, 50, 430, 4)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (85, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\sny_resize.jpg', SINGLE_BLOB) image), 180, 62, 478, 3)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (65, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\sadok_resize.jpg', SINGLE_BLOB) image), 165, 54, 305, 2)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (9, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\Koza_resize.jpg', SINGLE_BLOB) image), 61, 52, 360, 5)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (124, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\pidkova_resize.jpg', SINGLE_BLOB) image), 135, 66, 346, 5)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (15, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\kolobok_resize.jpg', SINGLE_BLOB) image), 71, 55, 386, 5)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (149, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\kotyk_pivnyk_resize.jpg', SINGLE_BLOB) image), 126, 56, 462, 9)
INSERT dbo.Performance(PerformanceId, MainImage, Duration, MinPrice, MaxPrice, MinimumAge) VALUES (66, (SELECT * FROM OPENROWSET(BULK N'$(FullScriptDir)\TheaterDatabase\TestData\MainImages\Cat_resize.jpg', SINGLE_BLOB) image), 159, 54, 340, 3)
--SET IDENTITY_INSERT dbo.Performance OFF


SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember ON

INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (10, 66, 1)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (5, 65, 2)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (1, 176, 3)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (6, 9, 4)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (2, 399, 5)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (7, 124, 6)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (3, 104, 7)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (8, 15, 8)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (4, 85, 9)
INSERT dbo.PerformanceCreativeTeamMember(CreativeTeamMemberId, PerformanceId, PerformanceCreativeTeamMemberId) VALUES (9, 149, 10)

SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember OFF

SET IDENTITY_INSERT dbo.Schedule ON

INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (1, '2019-03-13 14:13:15.880', 85)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (2, '2019-03-16 11:54:04.750', 104)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (3, '2019-03-14 13:52:12.790', 176)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (4, '2019-03-17 12:16:41.300', 124)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (5, '2019-03-19 17:49:23.260', 104)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (6, '2019-03-09 11:02:14.020', 15)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (7, '2019-03-03 22:53:09.750', 85)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (8, '2019-03-15 14:53:03.480', 15)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (9, '2019-03-18 23:10:31.780', 65)
INSERT dbo.Schedule(ScheduleId, Beginning, PerformanceId) VALUES (10,'2019-03-04 11:07:00.680', 399)

SET IDENTITY_INSERT dbo.Schedule OFF

SET IDENTITY_INSERT dbo.NotificationFrequency ON

INSERT dbo.NotificationFrequency(NotificationFrequencyId, Frequency) 
VALUES
(1, 3),
(2, 7),
(3, 14),
(4, 30)
																
SET IDENTITY_INSERT dbo.NotificationFrequency OFF

SET IDENTITY_INSERT dbo.Settings ON

INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (1, 2, 1, 2)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (2, 1, 1, 2)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (3, 1, 1, 2)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (4, 2, 1, 2)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (5, 1, 1, 2)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (6, 2, 1, 2)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (7, 2, 1, 2)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (8, 1, 1, 2)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (9, 1, 1, 2)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (10, 2, 1,2)

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

SET IDENTITY_INSERT dbo.Event_TR ON
INSERT dbo.Event_TR(Event_TRId, Title, ShortDescription, FullDescription, [Type], LanguageId, EventId) VALUES(1, N'Event № 1', N'Here is a short event description №1', N'There will be a full description of the event № 1', N'Excursion', 1, 1)
INSERT dbo.Event_TR(Event_TRId, Title, ShortDescription, FullDescription, [Type], LanguageId, EventId) VALUES(2, N'Подія № 2', N'Тут буде короткий опис події №2', N'Тут буде повний опис події № 2', N'Екскурсія', 2, 2)
INSERT dbo.Event_TR(Event_TRId, Title, ShortDescription, FullDescription, [Type], LanguageId, EventId) VALUES(3, N'Подія № 3', N'Тут буде короткий опис події №3', N'Тут буде повний опис події № 3', N'Екскурсія', 2, 3)
INSERT dbo.Event_TR(Event_TRId, Title, ShortDescription, FullDescription, [Type], LanguageId, EventId) VALUES(4, N'Event № 4', N'Here is a short event description №4', N'There will be a full description of the event № 4', N'Promo action', 1, 4)
INSERT dbo.Event_TR(Event_TRId, Title, ShortDescription, FullDescription, [Type], LanguageId, EventId) VALUES(5, N'Event № 5', N'Here is a short event description №5', N'There will be a full description of the event № 5', N'Promo action', 1, 5)
INSERT dbo.Event_TR(Event_TRId, Title, ShortDescription, FullDescription, [Type], LanguageId, EventId) VALUES(6, N'Подія № 6', N'Тут буде короткий опис події №6', N'Тут буде повний опис події № 6', N'Промо акція', 2, 6)
INSERT dbo.Event_TR(Event_TRId, Title, ShortDescription, FullDescription, [Type], LanguageId, EventId) VALUES(7, N'Подія № 7', N'Тут буде короткий опис події №7', N'Тут буде повний опис події № 7', N'Промо акція', 2, 7)
INSERT dbo.Event_TR(Event_TRId, Title, ShortDescription, FullDescription, [Type], LanguageId, EventId) VALUES(8, N'Event № 8', N'Here is a short event description №8', N'There will be a full description of the event № 8', N'Masterclass', 1, 8)
INSERT dbo.Event_TR(Event_TRId, Title, ShortDescription, FullDescription, [Type], LanguageId, EventId) VALUES(9, N'Event № 9', N'Here is a short event description №9', N'There will be a full description of the event № 9', N'Masterclass', 1, 9)
INSERT dbo.Event_TR(Event_TRId, Title, ShortDescription, FullDescription, [Type], LanguageId, EventId) VALUES(10, N'Подія № 10', N'Тут буде короткий опис події № 10', N'Тут буде повний опис події № 10', N'Майстер-клас', 2, 10)
SET IDENTITY_INSERT dbo.Event_TR OFF

SET IDENTITY_INSERT dbo.GalleryImage ON

INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (1, 0x06081A0B07C55EB32309648F63F42A8EF75CEA460190A0F3A81FD403381004ADFD6606866190450B1E599E032EC265, 104)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (2, 0xC0939EFEE3211C12B70D9BDD273FABCABAACD08FBEB9DBE4226301346239E298B2651402E2FD63C93B0E051867400B06F044050C40449101777E62B04FF47C, 104)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (3, 0x1494763EDD5E2E, 15)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (4, 0x1F8F7E03028BA45B2023509A356AFA150D4EDD06FCA6D9, 399)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (5, 0x929BBE9FCB6C7C1023D39B47DE1D, 66)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (6, 0x52DB030807D1505BE555CD9BC629472F092205DA4B1214944A5EBA3954F97093CD3B1725DC4145470FA804070992E21CAB, 9)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (7, 0xA4B18FB9231BB78B704EBD516183178F862F60BAE1BA094F068E3035A4BF269608C338955A2600BF1D04A219C8EE7F52CEB368E73FAE63381C390769A9491204A452D93080E8D0462F03070333E01BBE64CE7AE65209B836699D54AAFC48D102BFCBFD8F7431F7D5054FCBC20963525A1184A156F328FBC3AF62, 66)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (8, 0x0FC036E85E5AE8CF09C6BB8F022390C7D97E1FF00FE392C4164DB0D6AC2B11525F5106A1893D5862820002DA2875150F399CAF6607C279E837CD321D7E22C36C6206D37A01692D2656B0F6B4038C5E4D0608D4F64DC1AA2508BB124B004219F360FC9D196FA2815854, 15)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (9, 0x4A4626AE82B942343ED3D9F3208B0507E0248074AE15A63B44911E5358478373BC068EB42C40000EDC2C027EE6BDFE90069A, 149)
INSERT dbo.GalleryImage(GalleryImageId, Image, PerformanceId) VALUES (10, 0x079E5E51E35E08A9C4F6EBFCFE3DF3113527F2035817B235676A79B6E0E08A251E8A0960B031BC2263A2A507E9D7054FC9173D64219702436F56C04C05C72396F7EAF9644ACB3955606006CD00181BC1E489B0DC70BFE3194874A2045BE059E39DAC2E1B4B6697DE84038B40CE56F99005BB002F4CE868D937935D8697695BB600D81F3BB2FCF843A8AC79432DD037DE086BC691993783B306872E27F620169FA8C15479F5DDE24201CC77975176360D, NULL)

SET IDENTITY_INSERT dbo.GalleryImage OFF
SET IDENTITY_INSERT dbo.HashTag_Performance ON

INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (1, 9, 3)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (2, 85, 9)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (3, 9, 2)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (4, 104, 8)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (5, 15, 2)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (6, 65, 3)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (7, 104, 4)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (8, 65, 4)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (9, 9, 9)
INSERT dbo.HashTag_Performance(HashTagPerformanceID, PerformanceId, HashTagId) VALUES (10, 399, 1)

SET IDENTITY_INSERT dbo.HashTag_Performance OFF
SET IDENTITY_INSERT dbo.HashTag_TR ON

INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (1,  N'#for family viewing', 1, 10)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (2,  N'#підліткова вистава', 2, 10)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (3,  N'#art', 1, 1)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (4,  N'#арт', 2, 8)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (5,  N'#fairy tale', 1, 5)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (6,  N'#для сімейного перегляду', 2, 5)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (7,  N'#казка', 2, 7)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (8,  N'#culture of the world', 1, 5)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (9,  N'#казка', 2, 9)
INSERT dbo.HashTag_TR(HashTag_TRId, Tag, LanguageId, HashTagId) VALUES (10, N'#культури світу', 2, 4)

SET IDENTITY_INSERT dbo.HashTag_TR OFF
SET IDENTITY_INSERT dbo.Performance_TR ON

INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (1,  N'Mystery of the forest', 1,         N'The charming forest of foresters is very similar to man. There are also good and evil creatures among them. One thing is cool to freeze the baby and the other desperately saves her. Will a little girl lost in the winter forest find help to escape the bad weather conditions? Or just learn to distinguish the truth from honesty and hypocrisy and flattery? Find out what is really important and necessary in this life with the Girl, which only spoils and amuses.', 176)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (2,  N'The road to Bethlehem', 1,         N'The play "The Way to Bethlehem" is more than a story about the birth of Jesus. The fate of a donkey who wears a small boy on a bicycle is a story about how to become a human. The little donkey is looking for God and dreams of becoming a star. Will he understand his calling? The answer to this question can be searched by the whole family in the play "The Way to Bethlehem".', 399)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (3,  N'Тарас', 2,                         N'За однойменним твором Б. Стельмаха. Пропонуємо вашій увазі дуже контрастний і символічний спектакль "Тарас". Дитина, яка не мала і половини можливостей сучасних людей продемонструвала своїм прикладом, що означає боротьба. Це дійсно історія успіху хлопчика без якого не було б України. Чорне і біле в спектаклі підкреслює унікальність особистості Тараса Шевченка.', 104)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (4,  N'Cвяткові сни', 2,                  N'Від Романа до Йордана. Для сімейного перегляду - від 3 до 103 років. Очікувана ніч для всіх дітей ось-ось настане! Святкові і його сестричка Дзвінка в передчутті подарунків і інших святкових приємностей. Нарешті влаштувавшись в своїх ліжках, діти раптом помічають яскравий промінь світла і негайно біжать за ним. За кілька миттєвостей Святко і Дзвінка виявляються в казковому мареві, де обох чекають дивовижні пригоди і де обом доведеться проявити мудрість, відвагу і любов. Натомість діти отримують чарівні подарунки, які залишаться з ними назавжди. Вистава наповнена етнічними символами і баченнями, колядками і прекрасним святковим настроєм.', 85)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (5,  N'Cedar seedlings', 1,               N'The performance "The Cherry Seducer" is a visual celebration of the soul. Breathes in the spring and attracted by her vivid set design, which deepens the worldview of Taras Shevchenko. The energy of poetry fills the show with deep meaning, which becomes clear to everyone. You will be surprised by the animation of sand, which is delicate and combined with an unusual musical design. This spectacle will not remain indifferent to those who appreciate new faces on the way to understanding the works of T. Shevchenko.', 65)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (6,  N'Goat-Dereza', 1,                   N'Once, one very cunning Goat got into one very good family, where she was terribly loved by all. But most of all cares about her master. And it would have been nice if Goat was not such a "Dereza"! Despite the love of the family, Goza has been tricked, deceived and behaved very nicely with their masters. Do you know what happens with dishonest kits? This is a fairy tale telling you about it.', 9)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (7,  N'Підкова на щастя', 2,              N'Як важко побороти свою лінь! Коли маленький Віслючок не хоче працювати – він ладен на все, щоб його не займали. І, одного разу, таки тікає від Діда з Бабою до лісу. Та така приваблива свобода виявилась не такою вже й простою! Чи зможе ця важка подорож навчити нашого героя любити роботу та свою домівку?', 124)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (8,  N'Наш веселий колобок', 2,           N'Кожен знає стару-добру казку про Колобка та його подорож лісом. А що як цього разу Колобок знайде собі друга, який допоможе не потрапити в халепу? Тоді всі загрози, що спіткають маленьких героїв стануть цікавими пригодами. Приєднуйтесь до нашого веселого Колобка, познайомтесь з його новим другом та проведіть свій час в казковому лісі дуже весело та цікаво!', 15)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (9,  N'Chanterelle, Cat and Cockerel', 1, N'Cat and Cockerel lived for themselves. Together they managed and sing songs. But once the cunning Fox stole the Cockerel, and the brave Cat had to save him. However, such an accursed adventure went only in favor of the reckless Hive - he became brave and in all promised to obey his brother. We recommend this show for small viewers.', 149)
INSERT dbo.Performance_TR(Performance_TRId, Title, LanguageId, Description, PerformanceId) VALUES (10, N'Кіт у чоботях', 2,                 N'Вистава за казкою видатного французького письменника Шарля Перро “Кіт у Чоботях”. Лялькова вистава в стилі “бароко” розповідає про винахідливого Кота, справжню дружбу та про те, що немає недосяжних цілей, якщо є розум, наполегливість та віра в себе. Це музичне, динамічне, веселе дійство не залишить байдужим маленьких глядачів.', 66)

SET IDENTITY_INSERT dbo.Performance_TR OFF
SET IDENTITY_INSERT dbo.Role_TR ON

INSERT dbo.Role_TR (Role_TRId, Role, ROLE_KEY, LanguageId) VALUES (1,  N'Художник',  N'Painter', 2)
INSERT dbo.Role_TR (Role_TRId, Role, ROLE_KEY, LanguageId) VALUES (2,  N'Painter',  N'Painter', 1)
INSERT dbo.Role_TR (Role_TRId, Role, ROLE_KEY, LanguageId) VALUES (3,  N'Хореограф',  N'Choreographer', 2)
INSERT dbo.Role_TR (Role_TRId, Role, ROLE_KEY, LanguageId) VALUES (4,  N'Choreographer',  N'Choreographer', 1)
INSERT dbo.Role_TR (Role_TRId, Role, ROLE_KEY, LanguageId) VALUES (5,  N'Композитор',  N'Composer', 2)
INSERT dbo.Role_TR (Role_TRId, Role, ROLE_KEY, LanguageId) VALUES (6,  N'Composer',  N'Composer', 1)
INSERT dbo.Role_TR (Role_TRId, Role, ROLE_KEY, LanguageId) VALUES (7,  N'Автор',  N'Author', 2)
INSERT dbo.Role_TR (Role_TRId, Role, ROLE_KEY, LanguageId) VALUES (8,  N'Author',  N'Author', 1)

SET IDENTITY_INSERT dbo.Role_TR OFF
SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember_TR ON

INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role_TRId, PerformanceCreativeTeamMemberId) VALUES (1, 1, 1)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role_TRId, PerformanceCreativeTeamMemberId) VALUES (2, 2, 2)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role_TRId, PerformanceCreativeTeamMemberId) VALUES (3, 3, 3)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role_TRId, PerformanceCreativeTeamMemberId) VALUES (4, 4, 4)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role_TRId, PerformanceCreativeTeamMemberId) VALUES (5, 5, 5)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role_TRId, PerformanceCreativeTeamMemberId) VALUES (6, 6, 6)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role_TRId, PerformanceCreativeTeamMemberId) VALUES (7, 7, 7)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role_TRId, PerformanceCreativeTeamMemberId) VALUES (8, 8, 8)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role_TRId, PerformanceCreativeTeamMemberId) VALUES (9, 1, 9)
INSERT dbo.PerformanceCreativeTeamMember_TR(PerformanceCreativeTeamMember_TRId, Role_TRId, PerformanceCreativeTeamMemberId) VALUES (10,2, 10)

SET IDENTITY_INSERT dbo.PerformanceCreativeTeamMember_TR OFF

SET IDENTITY_INSERT dbo.Wishlist ON
GO

INSERT dbo.Wishlist(WishPerformanceId, AccountId, PerformanceId) VALUES (1, 1, 66)
INSERT dbo.Wishlist(WishPerformanceId, AccountId, PerformanceId) VALUES (2, 3, 65)
INSERT dbo.Wishlist(WishPerformanceId, AccountId, PerformanceId) VALUES (3, 6, 176)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (4, 8, 9)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (5,10, 399)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (6, 4, 124)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (7, 2, 104)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (8, 9, 15)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (9, 7, 85)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (10,5, 149)
GO
SET IDENTITY_INSERT dbo.Wishlist OFF
GO

