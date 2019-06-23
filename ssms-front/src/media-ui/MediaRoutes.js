import React from 'react'
import { Switch, Route, Redirect } from 'react-router-dom'

const renderRoutes = routes => {
  return routes.map((link, i) => {
    if (link.component)
      return <Route key={i + 1} path={link.path} component={link.component} />
    if (link.children)
      return renderRoutes(link.children)
  }).flatten()
}

function MediaRoutes ({ navLinks, defaultPath }) {
  return (
    <main>
      <Switch>
        {renderRoutes(navLinks)}
        <Redirect to={defaultPath} />
      </Switch>
    </main>
  )
}

export default MediaRoutes
