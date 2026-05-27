import { createTheme } from '@mui/material/styles';

export const createAppTheme = (direction: 'ltr' | 'rtl') =>
  createTheme({
    direction,
    palette: {
      mode: 'light',
      primary: {
        main: '#1565c0',
      },
      secondary: {
        main: '#00838f',
      },
    },
    typography: {
      fontFamily: '"Roboto", "Helvetica", "Arial", sans-serif',
    },
  });
