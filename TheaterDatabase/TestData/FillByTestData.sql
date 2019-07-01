SET QUOTED_IDENTIFIER ON

DELETE dbo.Wishlist
DELETE dbo.Message
DELETE dbo.Account
DELETE dbo.Settings
DELETE dbo.NotificationFrequency
DELETE dbo.Event_TR
DELETE dbo.Language
DELETE dbo.Event

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



SET IDENTITY_INSERT dbo.Language ON
INSERT dbo.Language(LanguageId, LanguageCode) VALUES (1, 'en')
INSERT dbo.Language(LanguageId, LanguageCode) VALUES (2, 'uk')
SET IDENTITY_INSERT dbo.Language OFF

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
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (2, 1, 1, 1)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (3, 1, 1, 3)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (4, 2, 1, 4)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (5, 1, 1, 2)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (6, 2, 1, 1)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (7, 2, 1, 3)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (8, 1, 1, 4)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (9, 1, 1, 1)
INSERT dbo.Settings(SettingsId, LanguageId, DoesNotify, NotificationFrequencyId) VALUES (10, 2, 1,2)

SET IDENTITY_INSERT dbo.Settings OFF
GO
SET IDENTITY_INSERT dbo.Account ON

INSERT dbo.Account(AccountId, Password, Email, FirstName, LastName, Birthdate, PhoneIdentifier, SettingsId) VALUES (6, N'061A269220293916GY',									   N'Bolt@nowhere.com           ',	         N'Letha  ',     N'Wahl    ',   '1950-03-09', N'0d0ce684-3c5e-470d-b5c5-159802f9ed2e', 1)
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
GO

SET IDENTITY_INSERT dbo.Message ON

INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (1,  N'Mystery of the forest',        N'The best performance i have ever seen!',	N'Thank you for your message, it is important for us :)',6)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (2,  N'The road to Bethlehem',        N'Super!', N'Thank you for your message, it is important for us :)',10)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (3,  N'Тарас',                        N'Дуже цікава та пізнавальна вистава)', N'Дякуємо вам, надіюсь, ви гарно провели час)',2)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (4,  N'Cвяткові сни',                 N'Дуже цікава та пізнавальна вистава)', N'Дякуємо вам, надіюсь, ви гарно провели час)',1)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (5,  N'Cedar seedlings',              N'The best performance i have ever seen!',	N'Thank you, we do best for you)', 7)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (6,  N'Goat-Dereza',                  N'Amazing performance, I will come here again!', N'Thank you, we do best for you)',6)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (7,  N'Підкова на щастя',             N'Дякую за гарний проведений час, вистава була чудовою!' ,N'Дякуємо за відгук, ми завжди раді бачити задоволених клієнтів)',8)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (8,  N'Наш веселий колобок',          N'Дякую за гарний проведений час, вистава була чудовою!', N'Дякуємо за відгук, ми завжди раді бачити задоволених клієнтів)',9)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (9,  N'Chanterelle, Cat and Cockerel',N'Super!', N'Thank you for your message)',5)
INSERT dbo.Message(MessageId, Subject, MessageText, ReplyText, AccountId) VALUES (10, N'Кіт у чоботях ',               N'The best performance i have ever seen!',	N'Thank you for your message, it is important for us :)',9)

SET IDENTITY_INSERT dbo.Message OFF

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

SET IDENTITY_INSERT dbo.Wishlist ON
GO

INSERT dbo.Wishlist(WishPerformanceId, AccountId, PerformanceId) VALUES (1, 1, 66)
INSERT dbo.Wishlist(WishPerformanceId, AccountId, PerformanceId) VALUES (2, 2, 65)
INSERT dbo.Wishlist(WishPerformanceId, AccountId, PerformanceId) VALUES (3, 4, 176)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (4, 6, 9)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (5,7, 399)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (6, 9, 124)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (7, 3, 104)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (8, 5, 15)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (9, 8, 85)
INSERT dbo.Wishlist(WishPerformanceId ,AccountId, PerformanceId) VALUES (10,10, 149)
GO
SET IDENTITY_INSERT dbo.Wishlist OFF