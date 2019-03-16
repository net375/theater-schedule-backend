using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;
using System.Net;
using TheaterSchedule.Infrastructure;

namespace TheaterSchedule.BLL.Services
{
    public class SettingsService : ISettingsService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private ISettingsRepository settingsRepository;
        private IAccountRepository accountRepository;
        private ILanguageRepository languageRepository;


        public SettingsService(
            ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, 
            ISettingsRepository settingsRepository,
            IAccountRepository accountRepository, 
            ILanguageRepository languageRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.settingsRepository = settingsRepository;
            this.accountRepository = accountRepository;
            this.languageRepository = languageRepository;

        }
        public SettingsDTO LoadSettings(string phoneId)
        {
            SettingsDTO settingsRequest = null;
            Settings settings = settingsRepository.GetSettingsByPhoneId(phoneId);
            if (settings != null)
            {
                settingsRequest = new SettingsDTO()
                {
                    LanguageCode = settings.Language.LanguageCode
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

            Settings settings = settingsRepository.GetSettingsByPhoneId(phoneId);
            if (settings != null)
            {
                settings.Language = language;
            }
            else
            {
                Settings newSettings = new Settings { Language = language };
                settingsRepository.Add(newSettings);

                accountRepository.Add(new Account
                {
                    PhoneIdentifier = phoneId,
                    Settings = newSettings
                });
            }
            theaterScheduleUnitOfWork.Save();
        }
    }
}
