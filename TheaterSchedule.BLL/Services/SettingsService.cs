using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Entities;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.BLL.Services
{
    public class SettingsService : ISettingsService
    {

        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IScheduleRepository scheduleRepository;
        private ISettingsRepository settingsRepository;
        private IAccountRepository accountRepository;
        private ILanguageRepository languageRepository;


        public SettingsService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, IScheduleRepository scheduleRepository, ISettingsRepository settingsRepository,
            IAccountRepository accountRepository, ILanguageRepository languageRepository)
        {
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            this.scheduleRepository = scheduleRepository;
            this.settingsRepository = settingsRepository;
            this.accountRepository = accountRepository;
            this.languageRepository = languageRepository;

        }
        public SettingsRequestDTO LoadSettings(string phoneId)
        {
            SettingsRequestDTO settingsRequest = new SettingsRequestDTO();
            Settings settings = settingsRepository.GetSettingsByPhoneId(phoneId);
            if (settings != null)
            {
                Language language = languageRepository.GetLanguageById(settings.LanguageId);
                settingsRequest.LanguageName = language.LanguageName;
            }
            else
            {
                settingsRequest = null;
            }
            return settingsRequest;
        }

        public void StoreSettings(string phoneId, SettingsRequestDTO settingsRequest)
        {
            Language language = languageRepository.GetLanguageByName(settingsRequest.LanguageName);
            if (language == null)
            {
                throw new ArgumentException("Invalid language");
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
                    AccountNavigation = newSettings
                });
            }

            theaterScheduleUnitOfWork.Save();
        }
    }
}
