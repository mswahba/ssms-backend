import React from 'react'
import { useTranslation } from 'react-i18next'

function MediaLayout() {
  const { t } = useTranslation(['MediaHome'])
  return (
    <h3>{t('MediaHome:title', 'Missing Key')}</h3>
  )
}

export default MediaLayout
