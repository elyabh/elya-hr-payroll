import { useMemo } from 'react';
import { CacheProvider } from '@emotion/react';
import createCache from '@emotion/cache';
import { prefixer } from 'stylis';
import rtlPlugin from 'stylis-plugin-rtl';
import { ThemeProvider as MuiThemeProvider } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import { useTranslation } from 'react-i18next';
import { isRtlLanguage } from '@/i18n';
import { createAppTheme } from './theme';

type Props = {
  children: React.ReactNode;
};

export function ThemeProvider({ children }: Props) {
  const { i18n } = useTranslation();
  const direction = isRtlLanguage(i18n.language) ? 'rtl' : 'ltr';

  const cache = useMemo(
    () =>
      createCache({
        key: direction === 'rtl' ? 'muirtl' : 'muiltr',
        stylisPlugins: direction === 'rtl' ? [prefixer, rtlPlugin] : [prefixer],
      }),
    [direction],
  );

  const theme = useMemo(() => createAppTheme(direction), [direction]);

  return (
    <CacheProvider value={cache}>
      <MuiThemeProvider theme={theme}>
        <CssBaseline />
        <div dir={direction}>{children}</div>
      </MuiThemeProvider>
    </CacheProvider>
  );
}
