using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;
using System.Net;
using TheaterSchedule.Infrastructure;
using SettingsDTO = TheaterSchedule.BLL.DTO.SettingsDTO;

namespace TheaterSchedule.BLL.Services
{
    public class SettingsService : ISettingsService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private INotificationFrequencyRepository notificationFrequencyRepository;
        private ISettingsRepository settingsRepository;
        private IAccountRepository accountRepository;
        private ILanguageRepository languageRepository;


        public SettingsService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork,
            INotificationFrequencyRepository notificationFrequencyRepository,  
            ISettingsRepository settingsRepository,
            IAccountRepository accountRepository, 
            ILanguageRepository languageRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.notificationFrequencyRepository = notificationFrequencyRepository;
            this.settingsRepository = settingsRepository;
            this.accountRepository = accountRepository;
            this.languageRepository = languageRepository;

        }
        public SettingsDTO LoadSettings(string phoneId)
        {
            SettingsDTO settingsRequest = null;
            Entities.Models.Settings settings = settingsRepository.GetSettingsByPhoneId(phoneId);
            if (settings != null)
            {
                settingsRequest = new SettingsDTO()
                {
                    LanguageCode = settings.Language.LanguageCode,
                    DoesNotify = settings.DoesNotify,
                    NotificationFrequency = settings.NotificationFrequency.Frequency
                };
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Phone id [{phoneId}] doesn't exist");
            }
            return settingsRequest;
        }

        public void StoreSettings(string phoneId, SettingsDTO settingsRequest)
        {
            Language language = languageRepository.GetLanguageByName(settingsRequest.LanguageCode);
            if (language == null)
            {
                throw new HttpStatusCodeException(
                    HttpStatusCode.NotFound, 
                    $"Language [{settingsRequest.LanguageCode}] doesn't exist");
            }

            NotificationFrequency notificationFrequency =
                notificationFrequencyRepository.GetNotificationFrequencyByFrequency(settingsRequest.NotificationFrequency);

            if (notificationFrequency == null)
            {
                throw new HttpStatusCodeException(
                    HttpStatusCode.NotFound,
                    $"Notification frequency [{settingsRequest.NotificationFrequency}] doesn't exist");
            }

            Entities.Models.Settings settings = settingsRepository.GetSettingsByPhoneId(phoneId);
            if (settings != null)
            {
                settings.Language = language;
                settings.DoesNotify = settingsRequest.DoesNotify;
                settings.NotificationFrequency = notificationFrequency;
            }
            else
            {
                Entities.Models.Settings newSettings = new Entities.Models.Settings
                {
                    Language = language,
                    DoesNotify = true,
                    NotificationFrequency = notificationFrequency
                };

                settingsRepository.Add(newSettings);

                accountRepository.Add(new Account
                {
                    PhoneIdentifier = phoneId,
                    Settings = newSettings,
                    PasswordHash = "",
                    PasswordSalt = "",
                    Email = "",
                    FirstName = "",
                    City = ""
                });
            }
            theaterScheduleUnitOfWork.Save();
        }
    }
}
