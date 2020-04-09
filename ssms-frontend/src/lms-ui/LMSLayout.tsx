import React from 'react'
import { useTranslation } from 'react-i18next'

function LMSLayout() {
  const { t } = useTranslation(['lmsHome'])
  return (
    <div>
      <h3>{t('lmsHome:title', 'Missing Key')}</h3>
    </div>
  )
}

export default LMSLayout
