import MenuItem from '@mui/material/MenuItem';
import Select from '@mui/material/Select';
import type { SelectChangeEvent } from '@mui/material/Select';
import { useTranslation } from 'react-i18next';
import { supportedLanguages, type SupportedLanguage } from '@/i18n';

export function LanguageSwitcher() {
  const { i18n, t } = useTranslation();

  const handleChange = (event: SelectChangeEvent) => {
    void i18n.changeLanguage(event.target.value as SupportedLanguage);
  };

  return (
    <Select
      size="small"
      value={i18n.language}
      onChange={handleChange}
      aria-label="Language"
    >
      {supportedLanguages.map((lang) => (
        <MenuItem key={lang} value={lang}>
          {t(`language.${lang}`)}
        </MenuItem>
      ))}
    </Select>
  );
}
