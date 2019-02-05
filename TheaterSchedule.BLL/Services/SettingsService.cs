using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;

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
        public SettingsDTO LoadSettings(string phoneId)
        {
            SettingsDTO settingsRequest = null;
            Settings settings = settingsRepository.GetSettingsByPhoneId(phoneId);
            if (settings != null)
            {
                settingsRequest = new SettingsDTO() { LanguageName = settings.Language.LanguageName};
            }         
            return settingsRequest;
        }

        public void StoreSettings(string phoneId, SettingsDTO settingsRequest)
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
