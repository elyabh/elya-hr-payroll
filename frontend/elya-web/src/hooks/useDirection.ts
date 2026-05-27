import { useTranslation } from 'react-i18next';
import { isRtlLanguage } from '@/i18n';

export function useDirection(): 'ltr' | 'rtl' {
  const { i18n } = useTranslation();
  return isRtlLanguage(i18n.language) ? 'rtl' : 'ltr';
}
