import Paper from '@mui/material/Paper';
import Typography from '@mui/material/Typography';
import { useTranslation } from 'react-i18next';

export function DashboardPage() {
  const { t } = useTranslation();

  return (
    <Paper sx={{ p: 4 }}>
      <Typography variant="h4" gutterBottom>
        {t('dashboard.title')}
      </Typography>
      <Typography variant="body1" color="text.secondary">
        {t('dashboard.welcome')}
      </Typography>
    </Paper>
  );
}
