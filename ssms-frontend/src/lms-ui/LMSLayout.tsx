import React from 'react'
import { useTranslation } from 'react-i18next'

function LMSLayout() {
  const { t } = useTranslation(['LMSHome'])
  return (
    <h3>{t('LMSHome:title', 'Missing Key')}</h3>
  )
}

export default LMSLayout
