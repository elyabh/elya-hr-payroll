import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Paper from '@mui/material/Paper';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import { useTranslation } from 'react-i18next';
import { Link as RouterLink } from 'react-router-dom';
import Link from '@mui/material/Link';

export function LoginPage() {
  const { t } = useTranslation();

  return (
    <Box
      sx={{
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        minHeight: '60vh',
      }}
    >
      <Paper elevation={2} sx={{ p: 4, width: '100%', maxWidth: 420 }}>
        <Typography variant="h5" gutterBottom>
          {t('login.title')}
        </Typography>
        <Typography variant="body2" color="text.secondary" sx={{ mb: 3 }}>
          {t('login.subtitle')}
        </Typography>
        <Box component="form" sx={{ display: 'flex', flexDirection: 'column', gap: 2 }}>
          <TextField label={t('login.email')} type="email" fullWidth disabled />
          <TextField label={t('login.password')} type="password" fullWidth disabled />
          <Button variant="contained" disabled>
            {t('login.submit')}
          </Button>
          <Link component={RouterLink} to="/dashboard" underline="hover">
            {t('nav.dashboard')}
          </Link>
        </Box>
      </Paper>
    </Box>
  );
}
